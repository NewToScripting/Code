using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ActiproSoftware.Windows.Controls.Ribbon.Controls;
using ActiproSoftware.Windows.Controls.Ribbon.Input;
using ActiproSoftware.Windows.Controls.Ribbon.UI;
using Inspire.Commands;
using Inspire.MediaObjects;
using Brush=System.Windows.Media.Brush;
using Brushes=System.Windows.Media.Brushes;
using DrawingGroup=System.Windows.Media.DrawingGroup;
using DrawingImage=System.Windows.Media.DrawingImage;
using GeometryDrawing=System.Windows.Media.GeometryDrawing;
using RectangleGeometry=System.Windows.Media.RectangleGeometry;

namespace Inspire.Common.MediaObjects
{
    public class DesignTextBox : RichTextBox , IDisposable
    {

        private MemoryStream previewStream;

        public static readonly DependencyProperty DocumentUriProperty = DependencyProperty.Register("DocumentUri", typeof(Uri), typeof(DesignTextBox), new FrameworkPropertyMetadata(null, OnDocumentUriPropertyValueChanged));



        static DesignTextBox()
        {
            AcceptsReturnProperty.OverrideMetadata(typeof(DesignTextBox), new FrameworkPropertyMetadata(true));
            AcceptsTabProperty.OverrideMetadata(typeof(DesignTextBox), new FrameworkPropertyMetadata(true));
            HorizontalScrollBarVisibilityProperty.OverrideMetadata(typeof(DesignTextBox),
                                                                   new FrameworkPropertyMetadata(
                                                                       ScrollBarVisibility.Hidden));
            VerticalScrollBarVisibilityProperty.OverrideMetadata(typeof(DesignTextBox),
                                                                 new FrameworkPropertyMetadata(
                                                                     ScrollBarVisibility.Hidden));
        }

        public DesignTextBox()
        {
            // Add command bindings
            CommandBindings.Add(new CommandBinding(EditingCommands.AlignCenter, null, OnAlignCenterCanExecute));
            CommandBindings.Add(new CommandBinding(EditingCommands.AlignJustify, null, OnAlignJustifyCanExecute));
            CommandBindings.Add(new CommandBinding(EditingCommands.AlignLeft, null, OnAlignLeftCanExecute));
            CommandBindings.Add(new CommandBinding(EditingCommands.AlignRight, null, OnAlignRightCanExecute));
            CommandBindings.Add(new CommandBinding(InspireCommands.ApplyBackground, OnApplyBackgroundExecute, OnApplyBackgroundCanExecute));
            CommandBindings.Add(new CommandBinding(InspireCommands.ApplyDefaultBackground, OnApplyDefaultBackgroundExecute));
            CommandBindings.Add(new CommandBinding(InspireCommands.ApplyDefaultForeground, OnApplyDefaultForegroundExecute));
            CommandBindings.Add(new CommandBinding(InspireCommands.ApplyForeground, OnApplyForegroundExecute, OnApplyForegroundCanExecute));
            CommandBindings.Add(new CommandBinding(InspireCommands.ClearFormatting, OnClearFormattingExecute));
            CommandBindings.Add(new CommandBinding(InspireCommands.FontFamily, OnFontFamilyExecute, OnFontFamilyCanExecute));
            CommandBindings.Add(new CommandBinding(InspireCommands.FontSize, OnFontSizeExecute, OnFontSizeCanExecute));
            CommandBindings.Add(new CommandBinding(EditingCommands.ToggleBold, null, OnToggleBoldCanExecute));
            CommandBindings.Add(new CommandBinding(EditingCommands.ToggleItalic, null, OnToggleItalicCanExecute));
            CommandBindings.Add(new CommandBinding(InspireCommands.ToggleStrikethrough, OnToggleStrikethroughExecute, OnToggleStrikethroughCanExecute));
            CommandBindings.Add(new CommandBinding(EditingCommands.ToggleSubscript, null, OnToggleSubscriptCanExecute));
            CommandBindings.Add(new CommandBinding(EditingCommands.ToggleSuperscript, null, OnToggleSuperscriptCanExecute));
            CommandBindings.Add(new CommandBinding(EditingCommands.ToggleUnderline, null, OnToggleUnderlineCanExecute));

            Focusable = true;
            IsHitTestVisible = true;
           // LostKeyboardFocus += richTextBox_LostKeyboardFocus;
        }

        //void richTextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        //{
        //    DesignTextBox designTextBox = (DesignTextBox)sender;
        //    designTextBox.IsHitTestVisible = false;
        //    designTextBox.Margin = new Thickness(5);
        //}

        #region ActiPro Text Command Handlers

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // COMMAND HANDLERS
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnAlignCenterCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ICheckableCommandParameter parameter = e.Parameter as ICheckableCommandParameter;
            if (parameter != null)
            {
                parameter.Handled = true;
                parameter.IsChecked = SelectionAlignCenter;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnAlignJustifyCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ICheckableCommandParameter parameter = e.Parameter as ICheckableCommandParameter;
            if (parameter != null)
            {
                parameter.Handled = true;
                parameter.IsChecked = SelectionAlignJustify;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnAlignLeftCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ICheckableCommandParameter parameter = e.Parameter as ICheckableCommandParameter;
            if (parameter != null)
            {
                parameter.Handled = true;
                parameter.IsChecked = SelectionAlignLeft;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnAlignRightCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ICheckableCommandParameter parameter = e.Parameter as ICheckableCommandParameter;
            if (parameter != null)
            {
                parameter.Handled = true;
                parameter.IsChecked = SelectionAlignRight;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnApplyBackgroundCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            BrushValueCommandParameter parameter = e.Parameter as BrushValueCommandParameter;
            if ((parameter != null) && (!IsPreviewModeActive))
            {
                parameter.UpdatedValue = SelectionBackground;
                parameter.Handled = true;
            }
            e.CanExecute = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnApplyBackgroundExecute(object sender, ExecutedRoutedEventArgs e)
        {
            BrushValueCommandParameter parameter = e.Parameter as BrushValueCommandParameter;
            if (parameter != null)
            {
                switch (parameter.Action)
                {
                    case ValueCommandParameterAction.CancelPreview:
                        DeactivatePreviewMode(true);
                        break;
                    case ValueCommandParameterAction.Commit:
                        DeactivatePreviewMode(false);
                        SelectionBackground = parameter.Value;
                        UpdateApplyDefaultBackgroundSmallImageSource(parameter.Value);
                        break;
                    case ValueCommandParameterAction.Preview:
                        ActivatePreviewMode();
                        SelectionBackground = parameter.PreviewValue;
                        break;
                }
            }
            else
            {
                SelectionBackground = null;
                UpdateApplyDefaultBackgroundSmallImageSource(null);
            }
            e.Handled = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnApplyDefaultBackgroundExecute(object sender, ExecutedRoutedEventArgs e)
        {
            SelectionBackground = InspireCommands.ApplyDefaultBackground.Tag as Brush;
            e.Handled = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnApplyDefaultForegroundExecute(object sender, ExecutedRoutedEventArgs e)
        {
            SelectionForeground = InspireCommands.ApplyDefaultForeground.Tag as Brush;
            e.Handled = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnApplyForegroundCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            BrushValueCommandParameter parameter = e.Parameter as BrushValueCommandParameter;
            if ((parameter != null) && (!IsPreviewModeActive))
            {
                parameter.UpdatedValue = SelectionForeground;
                parameter.Handled = true;
            }
            e.CanExecute = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnApplyForegroundExecute(object sender, ExecutedRoutedEventArgs e)
        {
            BrushValueCommandParameter parameter = e.Parameter as BrushValueCommandParameter;
            if (parameter != null)
            {
                switch (parameter.Action)
                {
                    case ValueCommandParameterAction.CancelPreview:
                        DeactivatePreviewMode(true);
                        break;
                    case ValueCommandParameterAction.Commit:
                        DeactivatePreviewMode(false);
                        SelectionForeground = parameter.Value;
                        UpdateApplyDefaultForegroundSmallImageSource(parameter.Value);
                        break;
                    case ValueCommandParameterAction.Preview:
                        ActivatePreviewMode();
                        SelectionForeground = parameter.PreviewValue;
                        break;
                }
            }
            else
            {
                SelectionForeground = null;
                UpdateApplyDefaultForegroundSmallImageSource(null);
            }
            e.Handled = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnClearFormattingExecute(object sender, ExecutedRoutedEventArgs e)
        {
            Selection.ClearAllProperties();
            e.Handled = true;
        }

        /// <summary>
        /// Occurs when the <see cref="DocumentUriProperty"/> value is changed.
        /// </summary>
        /// <param name="obj">The <see cref="DependencyObject"/> whose property is changed.</param>
        /// <param name="e">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        private static void OnDocumentUriPropertyValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            DesignTextBox control = (DesignTextBox)obj;
            try
            {
                control.Document = Application.LoadComponent(control.DocumentUri) as FlowDocument;
            }
            catch { }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnFontFamilyCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            FontFamilyValueCommandParameter parameter = e.Parameter as FontFamilyValueCommandParameter;
            if ((parameter != null) && (!IsPreviewModeActive))
            {
                parameter.UpdatedValue = SelectionFontFamily;
                parameter.Handled = true;
            }
            e.CanExecute = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnFontFamilyExecute(object sender, ExecutedRoutedEventArgs e)
        {
            FontFamilyValueCommandParameter parameter = e.Parameter as FontFamilyValueCommandParameter;
            if (parameter != null)
            {
                if ((parameter.Value != null) && (!FontFamilyComboBox.IsValidFontFamilyName(parameter.Value.Source)))
                    MessageBox.Show(String.Format("The font family '{0}' does not exist.", parameter.Value), "Invalid Font Family", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else
                {
                    switch (parameter.Action)
                    {
                        case ValueCommandParameterAction.CancelPreview:
                            DeactivatePreviewMode(true);
                            break;
                        case ValueCommandParameterAction.Commit:
                            DeactivatePreviewMode(false);
                            SelectionFontFamily = parameter.Value;
                            break;
                        case ValueCommandParameterAction.Preview:
                            ActivatePreviewMode();
                            SelectionFontFamily = parameter.PreviewValue;
                            break;
                    }
                }
                e.Handled = true;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnFontSizeCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            DoubleValueCommandParameter parameter = e.Parameter as DoubleValueCommandParameter;
            if ((parameter != null) && (!IsPreviewModeActive))
            {
                parameter.UpdatedValue = SelectionFontSize;
                parameter.Handled = true;
            }
            e.CanExecute = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnFontSizeExecute(object sender, ExecutedRoutedEventArgs e)
        {
            DoubleValueCommandParameter parameter = e.Parameter as DoubleValueCommandParameter;
            if (parameter != null)
            {
                if (parameter.ConversionException != null)
                    MessageBox.Show(parameter.ConversionException.Message, "Invalid Font Size", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else
                {
                    switch (parameter.Action)
                    {
                        case ValueCommandParameterAction.CancelPreview:
                            DeactivatePreviewMode(true);
                            break;
                        case ValueCommandParameterAction.Commit:
                            DeactivatePreviewMode(false);
                            SelectionFontSize = parameter.Value;
                            break;
                        case ValueCommandParameterAction.Preview:
                            ActivatePreviewMode();
                            SelectionFontSize = parameter.PreviewValue;
                            break;
                    }
                }
                e.Handled = true;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnToggleBoldCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ICheckableCommandParameter parameter = e.Parameter as ICheckableCommandParameter;
            if (parameter != null)
            {
                parameter.Handled = true;
                parameter.IsChecked = SelectionBold;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnToggleItalicCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ICheckableCommandParameter parameter = e.Parameter as ICheckableCommandParameter;
            if (parameter != null)
            {
                parameter.Handled = true;
                parameter.IsChecked = SelectionItalic;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnToggleStrikethroughCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ICheckableCommandParameter parameter = e.Parameter as ICheckableCommandParameter;
            if (parameter != null)
            {
                parameter.Handled = true;
                parameter.IsChecked = SelectionStrikethrough;
            }
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An <see cref="ExecutedRoutedEventArgs"/> that contains the event data.</param>
        private void OnToggleStrikethroughExecute(object sender, ExecutedRoutedEventArgs e)
        {
            SelectionStrikethrough = !SelectionStrikethrough;
            e.Handled = true;
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnToggleSubscriptCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ICheckableCommandParameter parameter = e.Parameter as ICheckableCommandParameter;
            if (parameter != null)
            {
                parameter.Handled = true;
                parameter.IsChecked = SelectionSubscript;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnToggleSuperscriptCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ICheckableCommandParameter parameter = e.Parameter as ICheckableCommandParameter;
            if (parameter != null)
            {
                parameter.Handled = true;
                parameter.IsChecked = SelectionSuperscript;
            }
        }

        /// <summary>
        /// Occurs when the <see cref="RoutedCommand"/> needs to determine whether it can execute.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A <see cref="CanExecuteRoutedEventArgs"/> that contains the event data.</param>
        private void OnToggleUnderlineCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ICheckableCommandParameter parameter = e.Parameter as ICheckableCommandParameter;
            if (parameter != null)
            {
                parameter.Handled = true;
                parameter.IsChecked = SelectionUnderline;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // NON-PUBLIC PROCEDURES
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Coerces a setting to a nullable boolean value.
        /// </summary>
        /// <param name="value">The setting value.</param>
        /// <param name="trueValue">The true value.</param>
        /// <returns>A nullable boolean value.</returns>
        private bool? CoerceBooleanValue(object value, object trueValue)
        {
            if (value == null)
                return null;
            if (value.Equals(trueValue))
                return true;
            if (value == DependencyProperty.UnsetValue)
                return null;
            return false;
        }

        /// <summary>
        /// Updates the <see cref="ImageSource"/> for the <c>ApplicationCommands.ApplyDefaultForeground</c> command.
        /// </summary>
        /// <param name="brush">The <see cref="Brush"/> to set as default.</param>
        private void UpdateApplyDefaultForegroundSmallImageSource(Brush brush)
        {
            // The default brush is stored in the Tag, quit if it is already there
            if (InspireCommands.ApplyDefaultForeground.Tag == brush)
                return;

            // Store the brush in the Tag
            InspireCommands.ApplyDefaultForeground.Tag = brush;

            // Create a DrawingImage
            DrawingImage image = new DrawingImage();

            DrawingGroup group = new DrawingGroup();
            image.Drawing = group;

            ImageDrawing imageDrawing = new ImageDrawing(
                new BitmapImage(new Uri("pack://application:,,,/Inspire.Client;component/Resources/Images/FontColor.png")), new Rect(0, 0, 16, 16));
            group.Children.Add(imageDrawing);

            GeometryDrawing geomDrawing = new GeometryDrawing();
            geomDrawing.Brush = (brush ?? Brushes.Transparent);
            group.Children.Add(geomDrawing);
            RectangleGeometry rectGeom = new RectangleGeometry(new Rect(0, 12, 16, 4));
            geomDrawing.Geometry = rectGeom;

            InspireCommands.ApplyDefaultForeground.ImageSourceSmall = image;
        }

        /// <summary>
        /// Updates the <see cref="ImageSource"/> for the <c>ApplicationCommands.ApplyDefaultBackground</c> command.
        /// </summary>
        /// <param name="brush">The <see cref="Brush"/> to set as default.</param>
        private void UpdateApplyDefaultBackgroundSmallImageSource(Brush brush)
        {
            // The default brush is stored in the Tag, quit if it is already there
            if (InspireCommands.ApplyDefaultBackground.Tag == brush)
                return;

            // Store the brush in the Tag
            InspireCommands.ApplyDefaultBackground.Tag = brush;

            // Create a DrawingImage
            DrawingImage image = new DrawingImage();

            DrawingGroup group = new DrawingGroup();
            image.Drawing = group;

            //ImageDrawing imageDrawing = new ImageDrawing(
            //    new BitmapImage(new Uri("Resources/Images/TextHighlight.png",UriKind.RelativeOrAbsolute)), new Rect(0, 0, 16, 16));
            //group.Children.Add(imageDrawing);

            GeometryDrawing geomDrawing = new GeometryDrawing();
            geomDrawing.Brush = (brush ?? Brushes.Transparent);
            group.Children.Add(geomDrawing);
            RectangleGeometry rectGeom = new RectangleGeometry(new Rect(0, 12, 16, 4));
            geomDrawing.Geometry = rectGeom;

            InspireCommands.ApplyDefaultBackground.ImageSourceSmall = image;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // PUBLIC PROCEDURES
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Activates preview mode.
        /// </summary>
        public void ActivatePreviewMode()
        {
            if (previewStream == null)
            {
                if (Selection.IsEmpty)
                {
                    // When the selection is empty, we need to select something for the preview stream functionality to work correctly
                    if (Selection.End != Selection.End.DocumentEnd)
                        EditingCommands.SelectRightByCharacter.Execute(null, this);
                    else if (Selection.Start != Selection.Start.DocumentStart)
                        EditingCommands.SelectRightByCharacter.Execute(null, this);
                }

                previewStream = new MemoryStream();
                Selection.Save(previewStream, DataFormats.Xaml);
            }
        }

        /// <summary>
        /// Deactivates preview mode.
        /// </summary>
        /// <param name="restoreOldSettings">Whether to restore the old settings.</param>
        public void DeactivatePreviewMode(bool restoreOldSettings)
        {
            if (previewStream != null)
            {
                if (restoreOldSettings)
                    Selection.Load(previewStream, DataFormats.Xaml);
                previewStream.Dispose();
                previewStream = null;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Uri"/> indicating the location of the <see cref="FlowDocument"/> to load.
        /// </summary>
        /// <value>A <see cref="Uri"/> indicating the location of the <see cref="FlowDocument"/> to load.</value>
        public Uri DocumentUri
        {
            get
            {
                return (Uri)GetValue(DocumentUriProperty);
            }
            set
            {
                SetValue(DocumentUriProperty, value);
            }
        }

        /// <summary>
        /// Loads the document text.
        /// </summary>
        /// <param name="text">The text to load.</param>
        public void LoadDocument(string text)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(text);
                writer.Flush();
                stream.Position = 0;
                TextRange range = new TextRange(Document.ContentStart, Document.ContentEnd);
                range.Load(stream, DataFormats.Rtf);
                stream.Dispose();
            }
        }

        /// <summary>
        /// Gets whether preview mode is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if preview mode is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsPreviewModeActive
        {
            get
            {
                return (previewStream != null);
            }
        }

        /// <summary>
        /// Invoked when an unhandled <see cref="UIElement.MouseUp"/> routed event is raised on this element. 
        /// Implement this method to add class handling for this event. 
        /// </summary>
        /// <param name="e">The event data for the <see cref="UIElement.MouseUp"/> event.</param>
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            // Call the base method
            base.OnMouseUp(e);

            // If a selection was just made with the mouse and we are not in an XBAP...
            if ((e.ChangedButton == MouseButton.Left) && (!Selection.IsEmpty) && (!BrowserInteropHelper.IsBrowserHosted))
            {
                // Show the mini-toolbar
                var miniToolBar = new RichTextMiniToolBar();
                miniToolBar.DataContext = this;
                MiniToolBarService.Show(miniToolBar,
                    this, e.GetPosition(this));
            }
        }

        /// <summary>
        /// Called when the rendered size of a control changes. 
        /// </summary>
        /// <param name="sizeInfo">Specifies the size changes.</param>
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            // Call the base method
            base.OnRenderSizeChanged(sizeInfo);

            // Adjust the document's page width (since there is a WPF bug when used within a parent ScrollViewer with horizontal scroll capabilities)
            if (Document != null)
                Document.PageWidth = ActualWidth - BorderThickness.Left - Padding.Left - BorderThickness.Right - Padding.Right;
        }

        /// <summary>
        /// Gets or sets whether the selected text is aligned center.
        /// </summary>
        /// <value>
        /// <c>true</c> if the selected text is aligned center; otherwise, <c>false</c>.
        /// </value>
        public bool? SelectionAlignCenter
        {
            get
            {
                return CoerceBooleanValue(Selection.GetPropertyValue(TextBlock.TextAlignmentProperty), TextAlignment.Center);
            }
            set
            {
                if ((value.HasValue) && (value.Value))
                    Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty, TextAlignment.Center);
            }
        }

        /// <summary>
        /// Gets or sets whether the selected text is aligned justify.
        /// </summary>
        /// <value>
        /// <c>true</c> if the selected text is aligned justify; otherwise, <c>false</c>.
        /// </value>
        public bool? SelectionAlignJustify
        {
            get
            {
                return CoerceBooleanValue(Selection.GetPropertyValue(TextBlock.TextAlignmentProperty), TextAlignment.Justify);
            }
            set
            {
                if ((value.HasValue) && (value.Value))
                    Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty, TextAlignment.Justify);
            }
        }

        /// <summary>
        /// Gets or sets whether the selected text is aligned left.
        /// </summary>
        /// <value>
        /// <c>true</c> if the selected text is aligned left; otherwise, <c>false</c>.
        /// </value>
        public bool? SelectionAlignLeft
        {
            get
            {
                return CoerceBooleanValue(Selection.GetPropertyValue(TextBlock.TextAlignmentProperty), TextAlignment.Left);
            }
            set
            {
                if ((value.HasValue) && (value.Value))
                    Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty, TextAlignment.Left);
            }
        }

        /// <summary>
        /// Gets or sets whether the selected text is aligned right.
        /// </summary>
        /// <value>
        /// <c>true</c> if the selected text is aligned right; otherwise, <c>false</c>.
        /// </value>
        public bool? SelectionAlignRight
        {
            get
            {
                return CoerceBooleanValue(Selection.GetPropertyValue(TextBlock.TextAlignmentProperty), TextAlignment.Right);
            }
            set
            {
                if ((value.HasValue) && (value.Value))
                    Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            }
        }

        /// <summary>
        /// Gets or sets the selected background.
        /// </summary>
        /// <value>The selected background.</value>
        public Brush SelectionBackground
        {
            get
            {
                object value = Selection.GetPropertyValue(TextElement.BackgroundProperty);
                if (value == DependencyProperty.UnsetValue)
                    return null;
                return (Brush)value;
            }
            set
            {
                Selection.ApplyPropertyValue(TextElement.BackgroundProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets whether the selected text is bold.
        /// </summary>
        /// <value>
        /// <c>true</c> if the selected text is bold; otherwise, <c>false</c>.
        /// </value>
        public bool? SelectionBold
        {
            get
            {
                return CoerceBooleanValue(Selection.GetPropertyValue(TextElement.FontWeightProperty), FontWeights.Bold);
            }
            set
            {
                Selection.ApplyPropertyValue(TextElement.FontWeightProperty, (value != false ? FontWeights.Bold : FontWeights.Normal));
            }
        }

        /// <summary>
        /// Gets or sets the selected font family.
        /// </summary>
        /// <value>The selected font family.</value>
        public FontFamily SelectionFontFamily
        {
            get
            {
                object value = Selection.GetPropertyValue(TextElement.FontFamilyProperty);
                if (value == DependencyProperty.UnsetValue)
                    return null;
                return (FontFamily)value;
            }
            set
            {
                if (value != null)
                    Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected font size.
        /// </summary>
        /// <value>The selected font size.</value>
        public double SelectionFontSize
        {
            get
            {
                object value = Selection.GetPropertyValue(TextElement.FontSizeProperty);
                if (value == DependencyProperty.UnsetValue)
                    return double.NaN;
                return (double)value;
            }
            set
            {
                if (!value.Equals(double.NaN))
                    Selection.ApplyPropertyValue(TextElement.FontSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected foreground.
        /// </summary>
        /// <value>The selected foreground.</value>
        public Brush SelectionForeground
        {
            get
            {
                object value = Selection.GetPropertyValue(TextElement.ForegroundProperty);
                if (value == DependencyProperty.UnsetValue)
                    return null;
                return (Brush)value;
            }
            set
            {
                Selection.ApplyPropertyValue(TextElement.ForegroundProperty, (value != null ? value : Brushes.Black));
            }
        }

        /// <summary>
        /// Gets or sets whether the selected text is italic.
        /// </summary>
        /// <value>
        /// <c>true</c> if the selected text is italic; otherwise, <c>false</c>.
        /// </value>
        public bool? SelectionItalic
        {
            get
            {
                return CoerceBooleanValue(Selection.GetPropertyValue(TextElement.FontStyleProperty), FontStyles.Italic);
            }
            set
            {
                Selection.ApplyPropertyValue(TextElement.FontStyleProperty, (value != false ? FontStyles.Italic : FontStyles.Normal));
            }
        }

        /// <summary>
        /// Gets or sets whether the selected text has a strike-through.
        /// </summary>
        /// <value>
        /// <c>true</c> if the selected text has a strike-through; otherwise, <c>false</c>.
        /// </value>
        public bool? SelectionStrikethrough
        {
            get
            {
                return CoerceBooleanValue(Selection.GetPropertyValue(TextBlock.TextDecorationsProperty), TextDecorations.Strikethrough);
            }
            set
            {
                Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty, (value != false ? TextDecorations.Strikethrough : null));
            }
        }

        /// <summary>
        /// Gets or sets whether the selected text is subscript.
        /// </summary>
        /// <value>
        /// <c>true</c> if the selected text is subscript; otherwise, <c>false</c>.
        /// </value>
        public bool? SelectionSubscript
        {
            get
            {
                return CoerceBooleanValue(Selection.GetPropertyValue(Typography.VariantsProperty), FontVariants.Subscript);
            }
            set
            {
                Selection.ApplyPropertyValue(Typography.VariantsProperty, (value != false ? FontVariants.Subscript : FontVariants.Normal));
            }
        }

        /// <summary>
        /// Gets or sets whether the selected text is superscript.
        /// </summary>
        /// <value>
        /// <c>true</c> if the selected text is superscript; otherwise, <c>false</c>.
        /// </value>
        public bool? SelectionSuperscript
        {
            get
            {
                return CoerceBooleanValue(Selection.GetPropertyValue(Typography.VariantsProperty), FontVariants.Superscript);
            }
            set
            {
                Selection.ApplyPropertyValue(Typography.VariantsProperty, (value != false ? FontVariants.Superscript : FontVariants.Normal));
            }
        }

        /// <summary>
        /// Gets or sets whether the selected text is underlined.
        /// </summary>
        /// <value>
        /// <c>true</c> if the selected text is underlined; otherwise, <c>false</c>.
        /// </value>
        public bool? SelectionUnderline
        {
            get
            {
                return CoerceBooleanValue(Selection.GetPropertyValue(TextBlock.TextDecorationsProperty), TextDecorations.Underline);
            }
            set
            {
                Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty, (value != false ? TextDecorations.Underline : null));
            }
        }
        #endregion

        public void Dispose()
        {
            if(previewStream != null)
                previewStream.Dispose();
            previewStream = null;
        }
    }
}
