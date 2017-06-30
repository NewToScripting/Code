using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Inspire.Commands;
using Inspire.Interfaces;
using Inspire.MediaObjects;
using Inspire.Services.WeakEventHandlers;

namespace Inspire
{
    /// <summary>
    /// Interaction logic for PropertyBase.xaml
    /// </summary>
    public partial class PropertyBase : IWeakEventListener, IDisposable
    {
        private bool hasLoaded;

        private bool firstLoad;
        private bool firstLoad2;

        private delegate void OneArgDelegate(double arg);

        public PropertyBase()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this,this);
            //DataContextChanged += new DependencyPropertyChangedEventHandler(PropertyBase_DataContextChanged);
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                OnDesignContentControlLoaded(sender, e);
                return true;
            }
            return false;
        }

        private void OnDesignContentControlLoaded(object sender, EventArgs e)
        {
            if (!hasLoaded)
            {
                SetDataContext();
                hasLoaded = true;
            }
        }

        public void SetDataContext()
        {
            if(InspireApp.SelectedContext == null)
            {
                ClearBindings();
                return;
            }

            var contentControl = ((ContentControl)InspireApp.SelectedContext).Content as DesignContentControl;

            var designControlHolder = (DesignControlHolder)InspireApp.SelectedContext;

            DataContext = contentControl;

            tbMain1.DataContext = designControlHolder;
            tbMain2.DataContext = designControlHolder;
            tbMain3.DataContext = designControlHolder;
            tbMain4.DataContext = designControlHolder;
            
            if (contentControl != null)
            {
                tbMargin.DataContext = contentControl;
                effectSelector.DataContext = contentControl;
                
                OneArgDelegate setSkewXDelegate = SetSkewX;
                Dispatcher.BeginInvoke(setSkewXDelegate, contentControl.SkewTransform.AngleX);
                //SetSkewX(contentControl.SkewTransform.AngleX);

                OneArgDelegate setSkewYDelegate = SetSkewY;
                Dispatcher.BeginInvoke(setSkewYDelegate, contentControl.SkewTransform.AngleY);

                //OneArgDelegate setScaleXDelegate = SetScaleX;
                //Dispatcher.BeginInvoke(setScaleXDelegate, contentControl.ScaleTransform.ScaleX);
                //SetSkewX(contentControl.SkewTransform.AngleX);

                //OneArgDelegate setScaleYDelegate = SetScaleY;
                //Dispatcher.BeginInvoke(setScaleYDelegate, contentControl.ScaleTransform.ScaleY);
                //SetSkewY(contentControl.SkewTransform.AngleY);

                //OneArgDelegate setScaleXDelegate = SetScale;
                //Dispatcher.BeginInvoke(setScaleXDelegate, contentControl.ScaleTransform.ScaleX);
                    

                backgroundButton.Fill = contentControl.ContentBackground;
                borderBackgroundButton.Fill = contentControl.BorderBrush;
            }
        }

        private void ClearBindings()
        {
            tbMain1.Text = string.Empty;
            tbMain2.Text = string.Empty;
            tbMain3.Text = string.Empty;
            tbMain4.Text = string.Empty;
            tbMargin.Text = string.Empty;
            effectSelector.DataContext = null;
            backgroundButton.DataContext = null;
            borderBackgroundButton.Fill = null;
        }

        private void SetSkewY(double angleY)
        {
            sliderSkewY.Value = angleY;
        }

        private void SetSkewX(double angleX)
        {
            sliderSkewX.Value = angleX;
        }

        //private void SetScaleY(double angleY)
        //{
        //    sliderScaleY.Value = angleY;
        //}

        //private void SetScaleX(double angleX)
        //{
        //    sliderScaleX.Value = angleX;
        //}

        //private void SetScale(double scale)
        //{
        //    sliderScale.Value = scale;
        //}


        private void ChangeBackgroundColor_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DesignContentControl contentControl = DataContext as DesignContentControl;

            if (contentControl != null)
            {
                SolidColorBrush fontBrush = (SolidColorBrush)contentControl.ContentBackground;

                ColorPickerDialog cPicker = new ColorPickerDialog();

                cPicker.StartingColor = fontBrush.Color;
                //cPicker.Owner = this;

                bool? dialogResult = cPicker.ShowDialog();
                if (dialogResult != null && (bool) dialogResult)
                {

                    SolidColorBrush bgColor = new SolidColorBrush(cPicker.SelectedColor);

                    var command = new ChangeBackgroundColorCommand(contentControl, fontBrush,
                                                                                        bgColor);

                    if (((IDragCanvas)((FrameworkElement)contentControl.Parent).DataContext).UndoService != null)
                    {
                        ((IDragCanvas)((FrameworkElement)contentControl.Parent).DataContext).UndoService.Execute(command);
                    }
                    else
                    {
                        command.Execute();
                        backgroundButton.Fill = contentControl.ContentBackground;
                    }

                    //contentControl.ContentBackground = bgColor;
                    
                }
            }
            e.Handled = true;
        }

        private void ChangeBorderBackgroundColor_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DesignContentControl contentControl = DataContext as DesignContentControl;

            if (contentControl != null)
            {
                ColorPickerDialog cPicker = new ColorPickerDialog();

                SolidColorBrush fontBrush = (SolidColorBrush)contentControl.BorderBrush;

                cPicker.StartingColor = fontBrush.Color;
                //cPicker.Owner = this;

                bool? dialogResult = cPicker.ShowDialog();
                if (dialogResult != null && (bool) dialogResult)
                {

                    SolidColorBrush bgColor = new SolidColorBrush(cPicker.SelectedColor);

                    var command = new ChangeBorderColorCommand(contentControl, fontBrush,
                                                                                        bgColor);

                    if (((IDragCanvas)((FrameworkElement)contentControl.Parent).DataContext).UndoService != null)
                    {
                        ((IDragCanvas)((FrameworkElement)contentControl.Parent).DataContext).UndoService.Execute(command);
                    }
                    else
                    {
                        command.Execute();
                        borderBackgroundButton.Fill = contentControl.BorderBrush;
                    }
                }
            }
            e.Handled = true;
        }

        private void sliderSkewY_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetSkewY(0);
        }

        private void sliderSkewX_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetSkewX(0);
        }

        private void OnSkewChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            DesignContentControl contentControl = DataContext as DesignContentControl;

            if (contentControl != null)
            {
                //contentControl.SkewTransform.AngleX = sliderSkewX.Value;
                //contentControl.SkewTransform.AngleY = sliderSkewY.Value;

                double oldXval = 0d;
                double oldYval = 0d;
                double newXval = 0d;
                double newYval = 0d;

                if(((Slider)sender).Name == sliderSkewY.Name)
                {
                    oldXval = sliderSkewX.Value;
                    oldYval = e.OldValue;
                    newXval = sliderSkewX.Value;
                    newYval = e.NewValue;
                }
                else
                {
                    oldXval = e.OldValue;
                    oldYval = sliderSkewY.Value;
                    newXval = e.NewValue;
                    newYval = sliderSkewY.Value;
                }

                var command = new ChangeSkewCommand(contentControl, oldXval, oldYval, newYval, newXval);

                if (((IDragCanvas)((FrameworkElement)contentControl.Parent).DataContext).UndoService != null)
                {
                    ((IDragCanvas)((FrameworkElement)contentControl.Parent).DataContext).UndoService.Execute(command);
                }
                else
                {
                    command.Execute();
                }
            }
            
        }

        private void ChangeInnerGlowColor_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DesignContentControl contentControl = DataContext as DesignContentControl;

            if (contentControl != null)
            {
                ColorPickerDialog cPicker = new ColorPickerDialog();

               // SolidColorBrush fontBrush = (SolidColorBrush)contentControl.InnerGlowColor;

                cPicker.StartingColor = contentControl.InnerGlowColor;
                //cPicker.Owner = this;

                bool? dialogResult = cPicker.ShowDialog();
                if (dialogResult != null && (bool)dialogResult)
                {
                    var command = new ChangeInnerGlowColorCommand(contentControl, contentControl.InnerGlowColor,
                                                                                        cPicker.SelectedColor);

                    if (((IDragCanvas)((FrameworkElement)contentControl.Parent).DataContext).UndoService != null)
                    {
                        ((IDragCanvas)((FrameworkElement)contentControl.Parent).DataContext).UndoService.Execute(command);
                    }
                    else
                    {
                        command.Execute();
                    }
                    innerGlowButton.Fill = new SolidColorBrush(cPicker.SelectedColor);
                }
            }
            e.Handled = true;
        }

        private void OnScaleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (firstLoad && firstLoad2)
            {
                DesignContentControl contentControl = DataContext as DesignContentControl;

                if (contentControl != null)
                {
                    //contentControl.SkewTransform.AngleX = sliderSkewX.Value;
                    //contentControl.SkewTransform.AngleY = sliderSkewY.Value;

                    double oldXval = 0d;
                    double oldYval = 0d;
                    double newXval = 0d;
                    double newYval = 0d;

                    //if (((Slider)sender).Name == sliderScaleY.Name)
                    //{
                    //    oldXval = sliderScaleX.Value;
                    //    oldYval = e.OldValue;
                    //    newXval = sliderScaleX.Value;
                    //    newYval = e.NewValue;
                    //}
                    //else
                    //{
                    //    oldXval = e.OldValue;
                    //    oldYval = sliderScaleY.Value;
                    //    newXval = e.NewValue;
                    //    newYval = sliderScaleY.Value;
                    //}

                    var command = new ChangeScaleCommand(contentControl, oldXval, oldYval, newYval, newXval);

                    if (((IDragCanvas)((FrameworkElement)contentControl.Parent).DataContext).UndoService != null)
                    {
                        ((IDragCanvas)((FrameworkElement)contentControl.Parent).DataContext).UndoService.Execute(command);
                    }
                    else
                    {
                        command.Execute();
                    }
                }
            }
            else
            {
                if (firstLoad)
                    firstLoad2 = true;
                else
                {
                    firstLoad = true;
                }
            }
        }

        //private void sliderScaleX_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    SetScaleY(1);
        //}

        //private void sliderScaleY_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    SetScaleX(1);
        //}

        //private void OnScaleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    DesignContentControl contentControl = DataContext as DesignContentControl;

        //    if (contentControl != null)
        //    {
        //        contentControl.ScaleTransform.ScaleX = sliderScale.Value;
        //        contentControl.ScaleTransform.CenterX = contentControl.ActualWidth/2;
        //        contentControl.ScaleTransform.ScaleY = sliderScale.Value;
        //        contentControl.ScaleTransform.CenterY = contentControl.ActualHeight / 2;
        //    }
        //}

        //private void sliderZoomMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    SetScale(1);
        //}

        public void Dispose()
        {
            BindingOperations.ClearAllBindings(tbInnerGlowSize);
            BindingOperations.ClearAllBindings(tbMain1);
            BindingOperations.ClearAllBindings(tbMain2);
            BindingOperations.ClearAllBindings(tbMain3);
            BindingOperations.ClearAllBindings(tbMain4);
            BindingOperations.ClearAllBindings(tbMain5);
            BindingOperations.ClearAllBindings(tbMain6);
            BindingOperations.ClearAllBindings(tbMargin);
            BindingOperations.ClearAllBindings(tbZIndex);
            BindingOperations.ClearAllBindings(txtBorderThickness);
            BindingOperations.ClearAllBindings(sliderGlassOpacity);
            BindingOperations.ClearAllBindings(sliderInnerGlowOpacity);
            BindingOperations.ClearAllBindings(sliderOpacity);
            BindingOperations.ClearAllBindings(sliderSkewX);
            BindingOperations.ClearAllBindings(sliderSkewY);
            BindingOperations.ClearAllBindings(borderBackgroundButton);
            BindingOperations.ClearAllBindings(backgroundButton);

            //BindingOperations.ClearBinding(tbInnerGlowSize, TextBlock.TextProperty);
            //BindingOperations.ClearBinding(tbMain1, TextBlock.TextProperty);
            //BindingOperations.ClearBinding(tbMain2, TextBlock.TextProperty);
            //BindingOperations.ClearBinding(tbMain3, TextBlock.TextProperty);
            //BindingOperations.ClearBinding(tbMain4, TextBlock.TextProperty);
            //BindingOperations.ClearBinding(tbMain5, TextBlock.TextProperty);
            //BindingOperations.ClearBinding(tbMain6, TextBlock.TextProperty);
            //BindingOperations.ClearBinding(tbZIndex, TextBlock.TextProperty);
            //BindingOperations.ClearBinding(txtBorderThickness, TextBlock.TextProperty);
            //BindingOperations.ClearBinding(sliderGlassOpacity, Slider.ValueProperty);
            //BindingOperations.ClearBinding(sliderInnerGlowOpacity, Slider.ValueProperty);
            //BindingOperations.ClearBinding(sliderOpacity, Slider.ValueProperty);
            //BindingOperations.ClearBinding(sliderSkewX, Slider.ValueProperty);
            //BindingOperations.ClearBinding(sliderSkewY, Slider.ValueProperty);
        }
    }
}
