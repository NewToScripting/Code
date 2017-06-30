using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using EffectLibrary.Interfaces;

namespace EffectLibrary.Effects
{
    public class WaveShaderEffect : ShaderEffect , ICustomEffect
    {
        Dispatcher dispatcher;
        public WaveShaderEffect()
        {
            dispatcher = Dispatcher.CurrentDispatcher;
            PixelShader = _shader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(Val0Property);

            DoubleAnimation val0animation = new DoubleAnimation();
            val0animation.From = 0;
            val0animation.To = 1;
            val0animation.Duration = new Duration(TimeSpan.FromSeconds(15));
            val0animation.RepeatBehavior = RepeatBehavior.Forever;

            BeginAnimation(WaveShaderEffect.Val0Property, val0animation);
        }



        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(WaveShaderEffect), 0);


        public double Val0
        {
            get { return (float)GetValue(Val0Property); }
            set { SetValue(Val0Property, value); }
        }

        // Using a DependencyProperty as the backing store for Val.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Val0Property = DependencyProperty.Register("Val0", typeof(double), typeof(WaveShaderEffect),
            new UIPropertyMetadata(0.0, PixelShaderConstantCallback(0)));

        private static PixelShader _shader =
           new PixelShader() { UriSource = Global.MakePackUri("ShaderSource/WaveEffect.ps") };


        #region ICustomEffect Members

        public System.Windows.Controls.UserControl GetEffectGrid(UIElement uiElement)
        {
            return null;
        }

        #endregion
    }
}
