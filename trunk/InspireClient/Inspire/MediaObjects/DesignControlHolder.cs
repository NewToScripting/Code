using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;

namespace Inspire.MediaObjects
{
    public class DesignControlHolder : ContentControl, IDesignContentControl, ISelectable, ILockable, IWeakEventListener
    {
        private RotateTransform rotate;

        public DesignControlHolder(DesignContentControl control)
        {
            var rotateTransform = control.RotateTransform;
            Width = control.Width;
            Height = control.Height;

            MinHeight = 10;
            MinWidth = 10;

            GUID = Guid.NewGuid().ToString();

            control.Width = double.NaN;
            control.Height = double.NaN;
            control.RotateTransform = new RotateTransform(0);
            control.VerticalAlignment = VerticalAlignment.Stretch;
            control.HorizontalAlignment = HorizontalAlignment.Stretch;

            rotate = rotateTransform;

            int zIndex = Canvas.GetZIndex(control);

            Canvas.SetZIndex(this,zIndex);

            if (control.Visibility == System.Windows.Visibility.Collapsed)
                Visibility = System.Windows.Visibility.Visible;
            else
                Visibility = control.Visibility;

            IsLocked = control.IsLocked;
            IsRotatable = control.IsRotatable;
            VerticalAlignment = VerticalAlignment.Top;
            IsSelected = false;
            IsHitTestVisible = control.IsHitTestVisible;
            //Width = 200;
            //Height = 200;
            Content = control;

            //if(IsLocked)
            //    IsHitTestVisible = false;

            LoadedEventManager.AddListener(this, this);
        }

        private TransformGroup trGrp;
        private SkewTransform trSkw;
        private RotateTransform trRot;
        private ScaleTransform trScale;
        private TranslateTransform trTrans;

        public bool IsRotatable { get; set; }

        public double Left { get; set; }
        public double Top { get; set; }
        public double StartOpacity { get; set; }
        public double BeginScaleX { get; set;}
        public double BeginScaleY { get; set; }
        public string GUID { get; set; }

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
                    trTrans = new TranslateTransform(0, 0);
                    return trTrans;
                }
                return trTrans;
            }
            set { trTrans = value; }
        }

        private void OnDesignContentControlLoaded(object sender, EventArgs e)
        {
            trGrp = new TransformGroup();

            if (ScaleTransform == null)
                ScaleTransform = new ScaleTransform(1, 1);
            trGrp.Children.Add(ScaleTransform);

            if (SkewTransform == null)
                SkewTransform = new SkewTransform(0, 0);
            trGrp.Children.Add(SkewTransform);

            if (rotate == null)
            {
                RotateTransform = new RotateTransform(0);
                trGrp.Children.Add(RotateTransform);
            }
            else
            {
                RotateTransform = rotate;
                trGrp.Children.Add(rotate);
            }

            if (TranslateTransform == null)
                TranslateTransform = new TranslateTransform(0, 0);
            trGrp.Children.Add(TranslateTransform);

            // if (RenderTransform.ToString() == "Identity")
            RenderTransform = trGrp;

            if(InspireApp.IsPlayer || InspireApp.IsPreviewMode)
            {
                if(Parent != null)
                {
                    var parentSize = new Size(((FrameworkElement)Parent).Width, ((FrameworkElement)Parent).Height);
                    AnimationLibrary.AnimationManager.ApplyAnimations(this, parentSize);
                }
            }
        }

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
                                       typeof(DesignControlHolder),
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
                               typeof(DesignControlHolder),
                               new FrameworkPropertyMetadata(false));

        

        #endregion

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            //if (managerType == typeof(MouseDoubleClickEventHandler))
            //{
            //    contentControl_MouseDoubleClick(sender, e);
            //    return true;
            //}
            if (managerType == typeof(LoadedEventManager))
            {
                OnDesignContentControlLoaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
