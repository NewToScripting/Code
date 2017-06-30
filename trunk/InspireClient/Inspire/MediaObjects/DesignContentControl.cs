using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire.Commands;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;


namespace Inspire.MediaObjects
{
    public class DesignContentControl : ContentControl , IDesignContentControl, IWeakEventListener
    {
        
        #region Const
        /// <summary>
        /// DesignContentControl constructor.
        /// </summary>
        public DesignContentControl()
        {

            IsEditable = false;
            VerticalAlignment = VerticalAlignment.Stretch;
            BorderBrush = Brushes.Black;

            //Color color = new Color();
            //color.A = 1;
            //color.B = 0;
            //color.G = 0;
            //color.R = 0;
            //color.ScA = float.Parse("0.003921569");
            //color.ScB = 0;
            //color.ScG = 0;
            //color.ScR = 0;
            ContentBackground = Brushes.Transparent;//new SolidColorBrush(color);
            InnerGlowColor = Brushes.Transparent.Color;//color;
            //Height = 200;
            //Width = 200;
            SnapsToDevicePixels = true;
            
            MouseDoubleClickEventHandler.AddListener(this, this);
            
           // DefaultStyleKey = typeof(DesignContentControl);
            SizeChanged += ClippingBorder_SizeChanged;

            DataContext = this;
            InspireApp.SelectedContext = this;

            LoadedEventManager.AddListener(this, this);

            MouseDownEventHandler.AddListener(this, this);
        }

        #endregion

        #region Dependency Properties
  

        // Using a DependencyProperty as the backing store for IsTouchEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTouchEnabledProperty =
            DependencyProperty.Register("IsTouchEnabled", typeof(bool), typeof(DesignContentControl), new UIPropertyMetadata(false));



        /// <summary>
        /// The style content property.
        /// </summary>
        public static readonly DependencyProperty ContentStyleProperty =
            DependencyProperty.Register("ContentStyle", typeof(Style), typeof(DesignContentControl),
                                        new PropertyMetadata(new PropertyChangedCallback(ContentStyle_Changed)));

        /// <summary>
        /// The clip content property.
        /// </summary>
        public static readonly DependencyProperty ClipContentProperty =
            DependencyProperty.Register("ClipContent", typeof(bool), typeof(DesignContentControl),
                                        new PropertyMetadata(new PropertyChangedCallback(ClipContent_Changed)));

        /// <summary>
        /// The corner radius property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(DesignContentControl),
                                        new PropertyMetadata(new PropertyChangedCallback(CornerRadius_Changed)));

        /// <summary>
        /// The content z-index property.
        /// </summary>
        public static readonly DependencyProperty ContentZIndexProperty =
            DependencyProperty.Register("ContentZIndex", typeof(int), typeof(DesignContentControl), null);

        /// <summary>
        /// The glass corner radius property.
        /// </summary>
        public static readonly DependencyProperty GlassCornerRadiusProperty =
            DependencyProperty.Register("GlassCornerRadius", typeof(CornerRadius), typeof(DesignContentControl), null);

        /// <summary>
        /// The flass opacity property.
        /// </summary>
        public static readonly DependencyProperty GlassOpacityProperty =
            DependencyProperty.Register("GlassOpacity", typeof(double), typeof(DesignContentControl), null);

        /// <summary>
        /// The flass opacity property.
        /// </summary>
        public static readonly DependencyProperty ContentBackgroundProperty =
            DependencyProperty.Register("ContentBackground", typeof(Brush), typeof(DesignContentControl), null);

        /// <summary>
        /// The inner glow opacity property.
        /// </summary>
        public static readonly DependencyProperty InnerGlowOpacityProperty =
            DependencyProperty.Register("InnerGlowOpacity", typeof(double), typeof(DesignContentControl), null);

        /// <summary>
        /// The inner glow size property.
        /// </summary>
        public static readonly DependencyProperty InnerGlowSizeProperty =
            DependencyProperty.Register("InnerGlowSize", typeof(Thickness), typeof(DesignContentControl), new PropertyMetadata(new PropertyChangedCallback(InnerGlowSize_Changed)));

        /// <summary>
        /// The inner glow color.
        /// </summary>
        public static readonly DependencyProperty InnerGlowColorProperty =
            DependencyProperty.Register("InnerGlowColor", typeof(Color), typeof(DesignContentControl), new PropertyMetadata(new PropertyChangedCallback(InnerGlowColor_Changed)));

        #endregion

        #region Prop

        public string AssemblyInfo { get; set; }

        public MediaType Type { get; set; }

        public string GUID { get; set; }

        public bool IsCopyable { get; set; }

        public string SlideID { get; set; }

        public new string Name { get; set; }

        public string Description { get; set; }

        public bool IsEditable { get; set; }

        public bool IsNew { get; set; }

        public bool IsRotatable { get; set; }

        public string ButtonName { get; set; }

        public bool IsTouchEnabled
        {
            get { return (bool)GetValue(IsTouchEnabledProperty); }
            set { SetValue(IsTouchEnabledProperty, value); }
        }

        public RotateTransform RotateTransform
        {
            get
            {
                if (RenderTransform.ToString() == "Identity")
                {
                    trRot = new RotateTransform(0, 0, 0);
                    return trRot;
                }
                return trRot;
            }
            set { trRot = value; }
        }

        public SkewTransform SkewTransform
        {
            get
            {
                if (RenderTransform.ToString() == "Identity")
                {
                    trSkw = new SkewTransform(0, 0);
                    return trSkw;
                }
                return trSkw;
            }
            set { trSkw = value; }
        }

        public ScaleTransform ScaleTransform
        {
            get
            {
                if (RenderTransform.ToString() == "Identity")
                {
                    trScale = new ScaleTransform(1, 1);
                    return trScale;
                }
                return trScale;
            }
            set { trScale = value; }
        }

        public TranslateTransform TranslateTransform
        {
            get
            {
                if (RenderTransform.ToString() == "Identity")
                {
                    trTrans = new TranslateTransform(0,0);
                    return trTrans;
                }
                return trTrans;
            }
            set { trTrans = value; }
        }

        /// <summary>
        /// Gets or sets the border corner radius.
        /// This is a thickness, as there is a problem parsing CornerRadius types.
        /// </summary>
        [Category("Appearance"), Description("Sets the corner radius on the border.")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }

            set
            {
                SetValue(CornerRadiusProperty, value);

                var glassCornerRadius = new CornerRadius(
                    Math.Max(0, value.TopLeft - 1),
                    Math.Max(0, value.TopRight - 1),
                    0,
                    0);
                SetValue(GlassCornerRadiusProperty, glassCornerRadius);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the content is clipped.
        /// </summary>
        [Category("Appearance"), Description("Sets whether the content is clipped or not.")]
        public bool ClipContent
        {
            get { return (bool)GetValue(ClipContentProperty); }
            set { SetValue(ClipContentProperty, value); }
        }

        /// <summary>
        /// Gets or sets the content z-index. 0 for behind the glass, 1 for in-front.
        /// </summary>
        [Category("Appearance"), Description("Set 0 for behind the shadow, 1 for in front.")]
        public int ContentZIndex
        {
            get { return (int)GetValue(ContentZIndexProperty); }
            set { SetValue(ContentZIndexProperty, value); }
        }

        /// <summary>
        /// Gets or sets the inner glow opacity.
        /// </summary>
        [Category("Appearance"), Description("The inner glow opacity.")]
        public double GlassOpacity
        {
            get { return (double)GetValue(GlassOpacityProperty); }
            set { SetValue(GlassOpacityProperty, value); }
        }

        /// <summary>
        /// Gets or sets the ContentBackground color.
        /// </summary>
        [Category("Appearance"), Description("The Content Background color.")]
        public Brush ContentBackground
        {
            get { return (Brush)GetValue(ContentBackgroundProperty); }
            set { SetValue(ContentBackgroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets the inner glow opacity.
        /// </summary>
        [System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The inner glow opacity.")]
        public double InnerGlowOpacity
        {
            get { return (double)GetValue(InnerGlowOpacityProperty); }
            set { SetValue(InnerGlowOpacityProperty, value); }
        }

        /// <summary>
        /// Gets or sets the inner glow color.
        /// </summary>
        [System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The inner glow color.")]
        public Color InnerGlowColor
        {
            get
            {
                return (Color)GetValue(InnerGlowColorProperty);
            }

            set
            {
                SetValue(InnerGlowColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the inner glow size.
        /// </summary>
        [System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The inner glow size.")]
        public Thickness InnerGlowSize
        {
            get
            {
                return (Thickness)GetValue(InnerGlowSizeProperty);
            }

            set
            {
                SetValue(InnerGlowSizeProperty, value);
                this.UpdateGlowSize(value);
            }
        }

        #endregion

        #region private

        private TransformGroup trGrp;
        private SkewTransform trSkw;
        private RotateTransform trRot;
        private ScaleTransform trScale;
        private TranslateTransform trTrans;
        private bool _isLoaded;

        /// <summary>
        /// Stores the main border.
        /// </summary>
        private Border border;

        private Border styleBorder;

        /// <summary>
        /// Stores the clip responsible for clipping the bottom left corner.
        /// </summary>
        private RectangleGeometry bottomLeftClip;


        /// <summary>
        /// Stores the bottom left content control.
        /// </summary>
        private ContentControl bottomLeftContentControl;

        /// <summary>
        /// Stores the clip responsible for clipping the bottom right corner.
        /// </summary>
        private RectangleGeometry bottomRightClip;

        /// <summary>
        /// Stores the bottom right content control.
        /// </summary>
        private ContentControl bottomRightContentControl;

        /// <summary>
        /// Stores the clip responsible for clipping the top left corner.
        /// </summary>
        private RectangleGeometry topLeftClip;

        /// <summary>
        /// Stores the top left content control.
        /// </summary>
        private ContentControl topLeftContentControl;

        /// <summary>
        /// Stores the clip responsible for clipping the top right corner.
        /// </summary>
        private RectangleGeometry topRightClip;

        /// <summary>
        /// Stores the top right content control.
        /// </summary>
        private ContentControl topRightContentControl;

        /// <summary>
        /// Stores the left glow border.
        /// </summary>
        private Border leftGlow;

        /// <summary>
        /// Stores the top glow border.
        /// </summary>
        private Border topGlow;

        /// <summary>
        /// Stores the right glow border.
        /// </summary>
        private Border rightGlow;

        /// <summary>
        /// Stores the bottom glow border.
        /// </summary>
        private Border bottomGlow;

        /// <summary>
        /// Stores the left glow stop 0;
        /// </summary>
        private GradientStop leftGlowStop0;

        /// <summary>
        /// Stores the left glow stop 1;
        /// </summary>
        private GradientStop leftGlowStop1;

        /// <summary>
        /// Stores the top glow stop 0;
        /// </summary>
        private GradientStop topGlowStop0;

        /// <summary>
        /// Stores the top glow stop 1;
        /// </summary>
        private GradientStop topGlowStop1;

        /// <summary>
        /// Stores the right glow stop 0;
        /// </summary>
        private GradientStop rightGlowStop0;

        /// <summary>
        /// Stores the right glow stop 1.
        /// </summary>
        private GradientStop rightGlowStop1;

        /// <summary>
        /// Stores the bottom glow stop 0;
        /// </summary>
        private GradientStop bottomGlowStop0;

        /// <summary>
        /// Stores the bottom glow stop 1.
        /// </summary>
        private GradientStop bottomGlowStop1;

        #endregion

        #region Implementation

        /// <summary>
        /// Gets the UI elements out of the template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            border = GetTemplateChild("PART_Border") as Border;
            if (IsTouchEnabled || InspireApp.IsPreviewMode || InspireApp.IsPlayer)
                if (border != null) border.IsHitTestVisible = true;
            styleBorder = GetTemplateChild("PART_StyleBorder") as Border;
            topLeftContentControl = GetTemplateChild("PART_TopLeftContentControl") as ContentControl;
            topRightContentControl = GetTemplateChild("PART_TopRightContentControl") as ContentControl;
            bottomRightContentControl = GetTemplateChild("PART_BottomRightContentControl") as ContentControl;
            bottomLeftContentControl = GetTemplateChild("PART_BottomLeftContentControl") as ContentControl;

            if (topLeftContentControl != null)
            {
                topLeftContentControl.SizeChanged += ContentControl_SizeChanged;
            }

            topLeftClip = GetTemplateChild("PART_TopLeftClip") as RectangleGeometry;
            topRightClip = GetTemplateChild("PART_TopRightClip") as RectangleGeometry;
            bottomRightClip = GetTemplateChild("PART_BottomRightClip") as RectangleGeometry;
            bottomLeftClip = GetTemplateChild("PART_BottomLeftClip") as RectangleGeometry;

            leftGlow = GetTemplateChild("PART_LeftGlow") as Border;
            topGlow = GetTemplateChild("PART_TopGlow") as Border;
            rightGlow = GetTemplateChild("PART_RightGlow") as Border;
            bottomGlow = GetTemplateChild("PART_BottomGlow") as Border;

            leftGlowStop0 = GetTemplateChild("PART_LeftGlowStop0") as GradientStop;
            leftGlowStop1 = GetTemplateChild("PART_LeftGlowStop1") as GradientStop;
            topGlowStop0 = GetTemplateChild("PART_TopGlowStop0") as GradientStop;
            topGlowStop1 = GetTemplateChild("PART_TopGlowStop1") as GradientStop;
            rightGlowStop0 = GetTemplateChild("PART_RightGlowStop0") as GradientStop;
            rightGlowStop1 = GetTemplateChild("PART_RightGlowStop1") as GradientStop;
            bottomGlowStop0 = GetTemplateChild("PART_BottomGlowStop0") as GradientStop;
            bottomGlowStop1 = GetTemplateChild("PART_BottomGlowStop1") as GradientStop;

            UpdateGlowColor(InnerGlowColor);
            UpdateGlowSize(InnerGlowSize);

            UpdateClipContent(ClipContent);

            UpdateCornerRadius(CornerRadius);
        }

        public Border GetBorderofTemplate()
        {
            return GetTemplateChild("PART_Border") as Border;
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (Content is IResizable)
            {
                ((IResizable)Content).RePopulateBasedOnSize(sizeInfo);
            }
        }

        /// <summary>
        /// Sets the corner radius.
        /// </summary>
        /// <param name="newCornerRadius">The new corner radius.</param>
        internal void UpdateCornerRadius(CornerRadius newCornerRadius)
        {
            if (border != null)
            {
                border.CornerRadius = newCornerRadius;

            }

            if (topLeftClip != null)
            {
                topLeftClip.RadiusX =
                    topLeftClip.RadiusY =
                    newCornerRadius.TopLeft - (Math.Min(BorderThickness.Left, BorderThickness.Top)/2);
            }

            if (topRightClip != null)
            {
                topRightClip.RadiusX =
                    topRightClip.RadiusY =
                    newCornerRadius.TopRight - (Math.Min(BorderThickness.Top, BorderThickness.Right)/2);
            }

            if (bottomRightClip != null)
            {
                bottomRightClip.RadiusX =
                    bottomRightClip.RadiusY =
                    newCornerRadius.BottomRight - (Math.Min(BorderThickness.Right, BorderThickness.Bottom)/2);
            }

            if (bottomLeftClip != null)
            {
                bottomLeftClip.RadiusX =
                    bottomLeftClip.RadiusY =
                    newCornerRadius.BottomLeft - (Math.Min(BorderThickness.Bottom, BorderThickness.Left)/2);
            }
            if(border != null)
                UpdateClipSize(new Size(border.ActualWidth, border.ActualHeight));//ActualWidth, ActualHeight));
            else
                UpdateClipSize(new Size(ActualWidth, ActualHeight));
        }



        /// <summary>
        /// Updates whether the content is clipped.
        /// </summary>
        /// <param name="clipContent">Whether the content is clipped.</param>
        internal void UpdateClipContent(bool clipContent)
        {
            if (clipContent)
            {
                if (topLeftContentControl != null)
                {
                    topLeftContentControl.Clip = topLeftClip;
                }

                if (topRightContentControl != null)
                {
                    topRightContentControl.Clip = topRightClip;
                }

                if (bottomRightContentControl != null)
                {
                    bottomRightContentControl.Clip = bottomRightClip;
                }

                if (bottomLeftContentControl != null)
                {
                    bottomLeftContentControl.Clip = bottomLeftClip;
                }

                if(border != null)
                    UpdateClipSize(new Size(border.ActualWidth, border.ActualHeight));//ActualWidth, ActualHeight));
                else
                    UpdateClipSize(new Size(ActualWidth, ActualHeight));
            }
            else
            {
                if (topLeftContentControl != null)
                {
                    topLeftContentControl.Clip = null;
                }

                if (topRightContentControl != null)
                {
                    topRightContentControl.Clip = null;
                }

                if (bottomRightContentControl != null)
                {
                    bottomRightContentControl.Clip = null;
                }

                if (bottomLeftContentControl != null)
                {
                    bottomLeftContentControl.Clip = null;
                }
            }
        }

        /// <summary>
        /// Updates the corner radius.
        /// </summary>
        /// <param name="dependencyObject">The clipping border.</param>
        /// <param name="eventArgs">Dependency Property Changed Event Args</param>
        private static void CornerRadius_Changed(DependencyObject dependencyObject,
                                                 DependencyPropertyChangedEventArgs eventArgs)
        {
            var clippingBorder = (DesignContentControl)dependencyObject;
            clippingBorder.UpdateCornerRadius((CornerRadius) eventArgs.NewValue);
        }

        /// <summary>
        /// Updates the content style.
        /// </summary>
        /// <param name="dependencyObject">The style border.</param>
        /// <param name="eventArgs">Dependency Property Changed Event Args</param>
        private static void ContentStyle_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var sBorder = (DesignContentControl)dependencyObject;
            sBorder.UpdateContentStyle((Style)eventArgs.NewValue);
        }

        private void UpdateContentStyle(Style style)
        {
            if (styleBorder != null)
                styleBorder.Style = style;
        }

        /// <summary>
        /// Updates the content clipping.
        /// </summary>
        /// <param name="dependencyObject">The clipping border.</param>
        /// <param name="eventArgs">Dependency Property Changed Event Args</param>
        private static void ClipContent_Changed(DependencyObject dependencyObject,
                                                DependencyPropertyChangedEventArgs eventArgs)
        {
            var clippingBorder = (DesignContentControl)dependencyObject;
            clippingBorder.UpdateClipContent((bool) eventArgs.NewValue);
        }

        /// <summary>
        /// Updates the clips.
        /// </summary>
        /// <param name="sender">The clipping border</param>
        /// <param name="e">Size Changed Event Args.</param>
        private void ClippingBorder_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ClipContent)
            {
                UpdateClipSize(e.NewSize);
            }
        }

        /// <summary>
        /// Updates the clip size.
        /// </summary>
        /// <param name="sender">A content control.</param>
        /// <param name="e">Size Changed Event Args</param>
        private void ContentControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ClipContent)
            {
                if(border != null)
                    UpdateClipSize(new Size(border.ActualWidth, border.ActualHeight));//ActualWidth, ActualHeight));
                else
                    UpdateClipSize(new Size(ActualWidth, ActualHeight));
            }
        }

        /// <summary>
        /// Updates the clip size.
        /// </summary>
        /// <param name="size">The control size.</param>
        private void UpdateClipSize(Size size)
        {
            if (size.Width > 0 || size.Height > 0)
            {
                double contentWidth = Math.Max(0, size.Width - BorderThickness.Left - BorderThickness.Right);
                double contentHeight = Math.Max(0, size.Height - BorderThickness.Top - BorderThickness.Bottom);

                if (topLeftClip != null)
                {
                    topLeftClip.Rect = new Rect(0, 0, contentWidth + (CornerRadius.TopLeft*2),
                                                contentHeight + (CornerRadius.TopLeft*2));
                }

                if (topRightClip != null)
                {
                    topRightClip.Rect = new Rect(0 - CornerRadius.TopRight, 0, contentWidth + CornerRadius.TopRight,
                                                 contentHeight + CornerRadius.TopRight);
                }

                if (bottomRightClip != null)
                {
                    bottomRightClip.Rect = new Rect(0 - CornerRadius.BottomRight, 0 - CornerRadius.BottomRight,
                                                    contentWidth + CornerRadius.BottomRight,
                                                    contentHeight + CornerRadius.BottomRight);
                }

                if (bottomLeftClip != null)
                {
                    bottomLeftClip.Rect = new Rect(0, 0 - CornerRadius.BottomLeft,
                                                   contentWidth + CornerRadius.BottomLeft,
                                                   contentHeight + CornerRadius.BottomLeft);
                }
            }
        }

        /// <summary>
        /// Updates the inner glow color.
        /// </summary>
        /// <param name="color">The new color.</param>
        internal void UpdateGlowColor(Color color)
        {
            if (this.leftGlowStop0 != null)
            {
                this.leftGlowStop0.Color = color;
            }

            if (this.leftGlowStop1 != null)
            {
                this.leftGlowStop1.Color = Color.FromArgb(
                    0,
                    color.R,
                    color.G,
                    color.B);
            }

            if (this.topGlowStop0 != null)
            {
                this.topGlowStop0.Color = color;
            }

            if (this.topGlowStop1 != null)
            {
                this.topGlowStop1.Color = Color.FromArgb(
                    0,
                    color.R,
                    color.G,
                    color.B);
            }

            if (this.rightGlowStop0 != null)
            {
                this.rightGlowStop0.Color = color;
            }

            if (this.rightGlowStop1 != null)
            {
                this.rightGlowStop1.Color = Color.FromArgb(
                    0,
                    color.R,
                    color.G,
                    color.B);
            }

            if (this.bottomGlowStop0 != null)
            {
                this.bottomGlowStop0.Color = color;
            }

            if (this.bottomGlowStop1 != null)
            {
                this.bottomGlowStop1.Color = Color.FromArgb(
                    0,
                    color.R,
                    color.G,
                    color.B);
            }
        }

        /// <summary>
        /// Sets the glow size.
        /// </summary>
        /// <param name="newGlowSize">The new glow size.</param>
        internal void UpdateGlowSize(Thickness newGlowSize)
        {
            if (this.leftGlow != null)
            {
                this.leftGlow.Width = Math.Abs(newGlowSize.Left);
            }

            if (this.topGlow != null)
            {
                this.topGlow.Height = Math.Abs(newGlowSize.Top);
            }

            if (this.rightGlow != null)
            {
                this.rightGlow.Width = Math.Abs(newGlowSize.Right);
            }

            if (this.bottomGlow != null)
            {
                this.bottomGlow.Height = Math.Abs(newGlowSize.Bottom);
            }
        }

        /// <summary>
        /// Updates the inner glow color when the DP changes.
        /// </summary>
        /// <param name="dependencyObject">The inner glow border.</param>
        /// <param name="eventArgs">The new property event args.</param>
        private static void InnerGlowColor_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            DesignContentControl innerGlowBorder = (DesignContentControl)dependencyObject;
            innerGlowBorder.UpdateGlowColor((Color)eventArgs.NewValue);
        }

        /// <summary>
        /// Updates the glow size.
        /// </summary>
        /// <param name="dependencyObject">The inner glow border.</param>
        /// <param name="eventArgs">Dependency Property Changed Event Args</param>
        private static void InnerGlowSize_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            DesignContentControl innerGlowBorder = (DesignContentControl)dependencyObject;
            innerGlowBorder.UpdateGlowSize((Thickness)eventArgs.NewValue);
        }

        private void OnDesignContentControlLoaded(object sender, EventArgs e)
        {
            if (!_isLoaded)
            {

                trGrp = new TransformGroup();

                if (ScaleTransform == null)
                    ScaleTransform = new ScaleTransform(1, 1);
                trGrp.Children.Add(ScaleTransform);

                if (SkewTransform == null)
                    SkewTransform = new SkewTransform(0, 0);
                trGrp.Children.Add(SkewTransform);

                if (RotateTransform == null)
                    RotateTransform = new RotateTransform(0);
                trGrp.Children.Add(RotateTransform);

                if (TranslateTransform == null)
                    TranslateTransform = new TranslateTransform(0, 0);
                trGrp.Children.Add(TranslateTransform);

                // if (RenderTransform.ToString() == "Identity")
                RenderTransform = trGrp;

                // int zIndex = Canvas.GetZIndex(this);
                //double top = Canvas.GetTop(this);

                // Canvas.SetZIndex(this, zIndex);
                // Canvas.SetLeft(this, left);
                // Canvas.SetTop(this, top);


                if (InspireApp.IsPlayer || InspireApp.IsPreviewMode)
                {
                    //AnimationLibrary.AnimationManager.ApplyAnimations(this, PlayingMonitor.PlayingEvent, PlayingMonitor.StopEvent);

                    PlayingMonitor.RaisePlayingEvent(this);
                }
                _isLoaded = true;
            }
        }

        private void contentControl_MouseDown(object sender, EventArgs eventArgs)
        {
            if(IsVisible && IsTouchEnabled && (InspireApp.IsPlayer || InspireApp.IsPreviewMode))
            {
                InspireCommands.TouchNavigateCommand.Execute(GUID, null);
            }
        }

        void contentControl_MouseDoubleClick(object sender, EventArgs e)
        {
            if(InspireApp.IsPlaying || InspireApp.IsPlayer || InspireApp.IsPreviewMode) return;

            DesignContentControl designContentControl = (DesignContentControl)sender;

            if (IsEditable)
            {
                Assembly assembly = Assembly.Load(AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory + designContentControl.AssemblyInfo + ".dll"));

                foreach (Type type in assembly.GetTypes())
                {
                    // Pick up a class
                    if (type.IsClass)
                    {
                        // If it does not implement the IMediaModule Interface, skip it
                        if (type.GetInterface("IMediaModule") == null)
                        {
                            continue;
                        }

                        IMediaModule imediaModule = (IMediaModule)Activator.CreateInstance(type);

                        designContentControl.Content = imediaModule.EditControl(designContentControl).Content;
                    }
                }
            }
        }

        public void SetPlayerTransform()
        {
            RotateTransform.CenterX = Canvas.GetLeft(this) + .5 * Width;
            RotateTransform.CenterY = Canvas.GetTop(this) + .5 * Height;
        }

        public void SetDesignerTransform()
        {
            RotateTransform.CenterX = 0;
            RotateTransform.CenterY = 0;
        }

        #endregion

        #region Old Properties

        //public ScaleTransform ScaleTransform
        //{
        //    get
        //    {
        //        if (RenderTransform.ToString() == "Identity")
        //        {
        //            trScl = new ScaleTransform(1, 1);
        //            return trScl;
        //        }
        //        return trScl;
        //    }
        //    set { trScl = value; }
        //}

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(MouseDoubleClickEventHandler))
            {
                contentControl_MouseDoubleClick(sender, e);
                return true;
            }
            if (managerType == typeof(LoadedEventManager))
            {
                OnDesignContentControlLoaded(sender, e);
                return true;
            }
            if (managerType == typeof(MouseDownEventHandler))
            {
                contentControl_MouseDown(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        #region ISelectable Members

        public bool IsSelected
        {
            get
            {
                return (bool)GetValue(IsSelectedProperty);
            }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }

        public static readonly DependencyProperty IsSelectedProperty =
          DependencyProperty.Register("IsSelected",
                                       typeof(bool),
                                       typeof(DesignContentControl),
                                       new FrameworkPropertyMetadata(false));

        #endregion

        #region ILockable Members

        public bool IsLocked
        {
            get
            {
                return (bool)GetValue(IsLockedProperty);
            }
            set
            {
                SetValue(IsLockedProperty, value);
            }
        }

        public void Lock()
        {
            IsLocked = true;
            //IsHitTestVisible = false;
        }

        public bool UnLock()
        {
            IsLocked = false;
            //IsHitTestVisible = true;
            return true;
        }

        public static readonly DependencyProperty IsLockedProperty =
            DependencyProperty.Register("IsLocked",
                               typeof(bool),
                               typeof(DesignContentControl),
                               new FrameworkPropertyMetadata(false));



        #endregion

    }

}
