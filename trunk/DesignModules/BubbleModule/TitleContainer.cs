using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BubbleModule
{
    public class TitleContainer : UserControl
    {
        static TitleContainer()
        {
            //register dependency property
            FrameworkPropertyMetadata md = new FrameworkPropertyMetadata("Title", HeaderTitlePropertyChanged);
            HeaderTitleProperty = DependencyProperty.Register("HeaderTitle", typeof(string), typeof(TitleContainer), md);

            FrameworkPropertyMetadata md1 = new FrameworkPropertyMetadata(Double.Parse("30"), TitleSizePropertyChanged);
            TitleSizeProperty = DependencyProperty.Register("TitleSize", typeof(double), typeof(TitleContainer), md1);

            //register dependency property
            FrameworkPropertyMetadata md2 = new FrameworkPropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9A000000")), ColorPropertyChanged);
            ColorProperty = DependencyProperty.Register("Color", typeof(SolidColorBrush), typeof(TitleContainer), md2);

            //register dependency property
            FrameworkPropertyMetadata md3 = new FrameworkPropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#33000000")), BackgroundColorPropertyChanged);
            BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(SolidColorBrush), typeof(TitleContainer), md3);

            //register dependency property
            FrameworkPropertyMetadata md4 = new FrameworkPropertyMetadata(HorizontalAlignment.Left, TitleAlignmentPropertyChanged);
            TitleAlignmentProperty = DependencyProperty.Register("TitleAlignment", typeof(HorizontalAlignment), typeof(TitleContainer), md4);
        }

        #region HeaderTitle dependency property

        /// <summary>
        /// Description
        /// </summary>
        public static readonly DependencyProperty HeaderTitleProperty;

        /// <summary>
        /// A property wrapper for the <see cref="HeaderTitleProperty"/>
        /// dependency property:<br/>
        /// Description
        /// </summary>
        public string HeaderTitle
        {
            get { return (string)GetValue(HeaderTitleProperty); }
            set { SetValue(HeaderTitleProperty, value); }
        }


        /// <summary>
        /// Handles changes on the <see cref="HeaderTitleProperty"/> dependency property. As
        /// WPF internally uses the dependency property system and bypasses the
        /// <see cref="HeaderTitle"/> property wrapper, updates should be handled here.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void HeaderTitlePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TitleContainer owner = (TitleContainer)d;
            string newValue = (string)e.NewValue;

            owner.HeaderTitle = newValue;

            //TODO provide implementation
            //throw new NotImplementedException("Change event handler for dependency property Title not implemented.");
        }

        #endregion
  
        #region TitleSize dependency property

        /// <summary>
        /// Description
        /// </summary>
        public static readonly DependencyProperty TitleSizeProperty;

        /// <summary>
        /// A property wrapper for the <see cref="TitleSizeProperty"/>
        /// dependency property:<br/>
        /// Description
        /// </summary>
        public double TitleSize
        {
            get { return (double)GetValue(TitleSizeProperty); }
            set { SetValue(TitleSizeProperty, value); }
        }


        /// <summary>
        /// Handles changes on the <see cref="TitleSizeProperty"/> dependency property. As
        /// WPF internally uses the dependency property system and bypasses the
        /// <see cref="TitleSize"/> property wrapper, updates should be handled here.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void TitleSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TitleContainer owner = (TitleContainer)d;
            double newValue = (double)e.NewValue;

            owner.TitleSize = newValue;
        }

        #endregion

        #region Color dependency property

        /// <summary>
        /// Description
        /// </summary>
        public static readonly DependencyProperty ColorProperty;


        /// <summary>
        /// A property wrapper for the <see cref="ColorProperty"/>
        /// dependency property:<br/>
        /// Description
        /// </summary>
        public SolidColorBrush Color
        {
            get { return (SolidColorBrush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }


        /// <summary>
        /// Handles changes on the <see cref="ColorProperty"/> dependency property. As
        /// WPF internally uses the dependency property system and bypasses the
        /// <see cref="Color"/> property wrapper, updates should be handled here.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void ColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TitleContainer owner = (TitleContainer)d;
            SolidColorBrush newValue = (SolidColorBrush)e.NewValue;

            owner.Color = newValue;
        }

        #endregion

        #region BackgroundColor dependency property

        /// <summary>
        /// Description
        /// </summary>
        public static readonly DependencyProperty BackgroundColorProperty;


        /// <summary>
        /// A property wrapper for the <see cref="ColorProperty"/>
        /// dependency property:<br/>
        /// Description
        /// </summary>
        public SolidColorBrush BackgroundColor
        {
            get { return (SolidColorBrush)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }


        /// <summary>
        /// Handles changes on the <see cref="ColorProperty"/> dependency property. As
        /// WPF internally uses the dependency property system and bypasses the
        /// <see cref="Color"/> property wrapper, updates should be handled here.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void BackgroundColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TitleContainer owner = (TitleContainer)d;
            SolidColorBrush newValue = (SolidColorBrush)e.NewValue;

            owner.BackgroundColor = newValue;
        }

        #endregion

        #region TitleAlignment dependency property

        /// <summary>
        /// Description
        /// </summary>
        public static readonly DependencyProperty TitleAlignmentProperty;


        /// <summary>
        /// A property wrapper for the <see cref="ColorProperty"/>
        /// dependency property:<br/>
        /// Description
        /// </summary>
        public HorizontalAlignment TitleAlignment
        {
            get { return (HorizontalAlignment)GetValue(TitleAlignmentProperty); }
            set { SetValue(TitleAlignmentProperty, value); }
        }


        /// <summary>
        /// Handles changes on the <see cref="ColorProperty"/> dependency property. As
        /// WPF internally uses the dependency property system and bypasses the
        /// <see cref="Color"/> property wrapper, updates should be handled here.
        /// </summary>
        /// <param name="d">The currently processed owner of the property.</param>
        /// <param name="e">Provides information about the updated property.</param>
        private static void TitleAlignmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TitleContainer owner = (TitleContainer)d;
            HorizontalAlignment newValue = (HorizontalAlignment)e.NewValue;

            owner.TitleAlignment = newValue;
        }

        #endregion

    }
}
