using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire;
using Inspire.Services.WeakEventHandlers;

namespace RSSModule
{
    public class RSSControlHolder : ContentControl , IWeakEventListener, IDisposable
    {
        bool _hasLoaded;

        public RSSControlHolder()
        {
            if (RSSItems == null)
                RSSItems = new ListBox();

            LoadedEventManager.AddListener(this,this);
        }

        void RSSControlHolderLoaded(object sender, EventArgs e)
        {
            if (!_hasLoaded)
            {
                switch (RSSPanelType)
                {
                    case ("Panel"):
                        Content = new RSSFeedPanel(this, (InspireApp.IsPlayer || InspireApp.IsPreviewMode));
                        break;
                    default:
                        Content = new RSSContentControl(this, (InspireApp.IsPlayer || InspireApp.IsPreviewMode));
                        break;
                }

                //Content = new RSSContentControl(this, (InspireApp.IsPlayer || InspireApp.IsPreviewMode));
                _hasLoaded = true;
            }
        }


        public ListBox RSSItems { get; set; }

        public static DependencyProperty RSSHolderTitleForegroundProperty = DependencyProperty.Register(
            "RSSHolderTitleForeground", typeof(Brush), typeof(RSSControlHolder));

        public static DependencyProperty RSSHolderTitleFontFamilyProperty = DependencyProperty.Register(
            "RSSHolderTitleFontFamily", typeof(FontFamily), typeof(RSSControlHolder));

        public static DependencyProperty RSSHolderTitleFontSizeProperty = DependencyProperty.Register(
            "RSSHolderTitleFontSize", typeof(double), typeof(RSSControlHolder));

        public static DependencyProperty RSSHolderDescriptionForegroundProperty = DependencyProperty.Register(
            "RSSHolderDescriptionForeground", typeof(Brush), typeof(RSSControlHolder));

        public static DependencyProperty RSSHolderDescriptionFontFamilyProperty = DependencyProperty.Register(
            "RSSHolderDescriptionFontFamily", typeof(FontFamily), typeof(RSSControlHolder));

        public static DependencyProperty RSSHolderDescriptionFontSizeProperty = DependencyProperty.Register(
            "RSSHolderDescriptionFontSize", typeof(double), typeof(RSSControlHolder));

        public static DependencyProperty RSSHolderFeedSpeedProperty = DependencyProperty.Register(
            "RSSHolderFeedSpeed", typeof(int), typeof(RSSControlHolder));

        public string RSSPanelType { get; set; }

        public RSSControlHolder(IEnumerable<string> list, int speed, TextBlock title, TextBlock description, bool isTouchPanel) : this()
        {
            foreach (var feed in list)
                RSSItems.Items.Add(feed);

            if (isTouchPanel)
                RSSPanelType = "Panel";

            RSSHolderFeedSpeed = speed;
            RSSHolderTitleForeground = title.Foreground;
            RSSHolderTitleFontSize = title.FontSize;
            RSSHolderTitleFontFamily = title.FontFamily;
            RSSHolderDescriptionForeground = description.Foreground;
            RSSHolderDescriptionFontSize = description.FontSize;
            RSSHolderDescriptionFontFamily = description.FontFamily;

           // _hasLoaded = true;
        }

        public double RSSHolderTitleFontSize
        {
            get
            {
                return (double)GetValue(RSSHolderTitleFontSizeProperty);
            }
            set
            {
                SetValue(RSSHolderTitleFontSizeProperty, value);
                if (Content != null)
                if(Content is IRSSControl)
                {
                    IRSSControl rssContentControl = Content as IRSSControl;
                    if (rssContentControl != null) rssContentControl.RSSTitleFontSize = value;
                }
            }
        }

        public int RSSHolderFeedSpeed
        {
            get { return (int)GetValue(RSSHolderFeedSpeedProperty); }
            set
            {
                SetValue(RSSHolderFeedSpeedProperty, value);
                if (Content != null)
                if (Content is IRSSControl)
                {
                    IRSSControl IRSSControl = Content as IRSSControl;
                    if (IRSSControl != null) IRSSControl.RSSFeedSpeed = value;
                }
            }
        }

        public Brush RSSHolderTitleForeground
        {
            get { return (Brush)GetValue(RSSHolderTitleForegroundProperty); }
            set
            {
                SetValue(RSSHolderTitleForegroundProperty, value);
                if (Content != null)
                if (Content is IRSSControl)
                {
                    IRSSControl IRSSControl = Content as IRSSControl;
                    if (IRSSControl != null) IRSSControl.RSSTitleForeground = value;
                }
            }
        }

        public FontFamily RSSHolderTitleFontFamily
        {
            get
            { return (FontFamily)GetValue(RSSHolderTitleFontFamilyProperty); }
            set
            {
                SetValue(RSSHolderTitleFontFamilyProperty, value);
                if (Content != null)
                if (Content is IRSSControl)
                {
                    IRSSControl IRSSControl = Content as IRSSControl;
                    if (IRSSControl != null) IRSSControl.RSSTitleFontFamily = value;
                }
            }

        }

        public double RSSHolderDescriptionFontSize
        {
            get { return (double)GetValue(RSSHolderDescriptionFontSizeProperty); }
            set
            {
                SetValue(RSSHolderDescriptionFontSizeProperty, value);
                if (Content != null)
                if (Content is IRSSControl)
                {
                    IRSSControl IRSSControl = Content as IRSSControl;
                    if (IRSSControl != null) IRSSControl.RSSDescriptionFontSize = value;
                }

            }
        }

        public Brush RSSHolderDescriptionForeground
        {
            get { return (Brush)GetValue(RSSHolderDescriptionForegroundProperty); }
            set
            {
                SetValue(RSSHolderDescriptionForegroundProperty, value);
                if (Content != null)
                if (Content is IRSSControl)
                {
                    IRSSControl IRSSControl = Content as IRSSControl;
                    if (IRSSControl != null) IRSSControl.RSSDescriptionForeground = value;
                }
            }
        }

        public FontFamily RSSHolderDescriptionFontFamily
        {
            get { return (FontFamily)GetValue(RSSHolderDescriptionFontFamilyProperty); }
            set
            {
                SetValue(RSSHolderDescriptionFontFamilyProperty, value);
                if (Content != null)
                if (Content is IRSSControl)
                {
                    IRSSControl IRSSControl = Content as IRSSControl;
                    if (IRSSControl != null) IRSSControl.RSSDescriptionFontFamily = value;
                }
            }
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                RSSControlHolderLoaded(sender, e);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            if (Content != null)
            {
                ((IRSSControl) Content).Dispose();
                Content = null;
                RSSItems.Items.Clear();
                RSSItems = null;
            }
        }
    }

}
