using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ShapesModule
{
 public class ShapeBase : UserControl
 {
     static ShapeBase()
     {
         //register dependency property
         FrameworkPropertyMetadata borderColor = new FrameworkPropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9A000000")), BorderColorPropertyChanged);
         BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(SolidColorBrush), typeof(ShapeBase), borderColor);

         //register dependency property
         FrameworkPropertyMetadata bgColor = new FrameworkPropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#33000000")), BackgroundColorPropertyChanged);
         BackgroundColorProperty = DependencyProperty.Register("BackgroundColor", typeof(SolidColorBrush), typeof(ShapeBase), bgColor);

         //register dependency property
         FrameworkPropertyMetadata bdWidth = new FrameworkPropertyMetadata(1.0, BorderWidthPropertyChanged);
         BorderWidthProperty = DependencyProperty.Register("BorderWidth", typeof(Double), typeof(ShapeBase), bdWidth);

     }

    

     #region BorderColor dependency property

     /// <summary>
     /// Description
     /// </summary>
     public static readonly DependencyProperty BorderColorProperty;


     /// <summary>
     /// A property wrapper for the <see cref="ColorProperty"/>
     /// dependency property:<br/>
     /// Description
     /// </summary>
     public SolidColorBrush BorderColor
     {
         get { return (SolidColorBrush)GetValue(BorderColorProperty); }
         set { SetValue(BorderColorProperty, value); }
     }


     /// <summary>
     /// Handles changes on the <see cref="BorderColorProperty"/> dependency property. As
     /// WPF internally uses the dependency property system and bypasses the
     /// <see cref="Color"/> property wrapper, updates should be handled here.
     /// </summary>
     /// <param name="d">The currently processed owner of the property.</param>
     /// <param name="e">Provides information about the updated property.</param>
     private static void BorderColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
     {
         ShapeBase owner = (ShapeBase)d;
         SolidColorBrush newValue = (SolidColorBrush)e.NewValue;

         owner.BorderColor = newValue;
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
         ShapeBase owner = (ShapeBase)d;
         SolidColorBrush newValue = (SolidColorBrush)e.NewValue;

         owner.BackgroundColor = newValue;
     }

     #endregion

     #region BorderWidth dependency property

     /// <summary>
     /// Description
     /// </summary>
     public static readonly DependencyProperty BorderWidthProperty;


     /// <summary>
     /// A property wrapper for the <see cref="BorderWidthProperty"/>
     /// dependency property:<br/>
     /// Description
     /// </summary>
     public double BorderWidth
     {
         get { return (double)GetValue(BorderWidthProperty); }
         set { SetValue(BorderWidthProperty, value); }
     }


     /// <summary>
     /// Handles changes on the <see cref="BorderColorProperty"/> dependency property. As
     /// WPF internally uses the dependency property system and bypasses the
     /// <see cref="Color"/> property wrapper, updates should be handled here.
     /// </summary>
     /// <param name="d">The currently processed owner of the property.</param>
     /// <param name="e">Provides information about the updated property.</param>
     private static void BorderWidthPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
     {
         ShapeBase owner = (ShapeBase)d;
         Double newValue = (double)e.NewValue;

         owner.BorderWidth = newValue;
     }

     #endregion

 }
}
