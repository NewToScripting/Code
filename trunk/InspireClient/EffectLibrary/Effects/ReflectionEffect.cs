using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using EffectLibrary.Interfaces;

namespace EffectLibrary.Effects
{
    public class ReflectionEffect : ShaderEffect, ICustomEffect
    {
        #region Constructors

        static ReflectionEffect()
        {
            _pixelShader.UriSource = Global.MakePackUri("ShaderSource/ReflectionEffect.ps");
        }

        public ReflectionEffect()
        {
            this.PixelShader = _pixelShader;

            // Update each DependencyProperty that's registered with a shader register.  This
            // is needed to ensure the shader gets sent the proper default value.
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(CenterXProperty);
            UpdateShaderValue(LeftAngleProperty);
            UpdateShaderValue(RightAngleProperty);
        }

        #endregion

        #region Dependency Properties

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        // Brush-valued properties turn into sampler-property in the shader.
        // This helper sets "ImplicitInput" as the default, meaning the default
        // sampler is whatever the rendering of the element it's being applied to is.
        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ReflectionEffect), 0);

        public double InputHeight
        {
            get { return (double)GetValue(InputHeightProperty); }
            set { SetValue(InputHeightProperty, value); }
        }

        public static readonly DependencyProperty InputHeightProperty =
            DependencyProperty.Register("InputHeight", typeof(double), typeof(ReflectionEffect),
                new UIPropertyMetadata(
                    new PropertyChangedCallback(
                        (DependencyObject o, DependencyPropertyChangedEventArgs e) =>
                        {
                            ((ReflectionEffect)o).PaddingBottom = (double)e.NewValue;
                        }
                    )
                )
            );

        public double CenterX
        {
            get { return (double)GetValue(CenterXProperty); }
            set { SetValue(CenterXProperty, value); }
        }

        public static readonly DependencyProperty CenterXProperty =
            DependencyProperty.Register("CenterX", typeof(double), typeof(ReflectionEffect),
                new UIPropertyMetadata(0.5, PixelShaderConstantCallback(0)));

        public double LeftAngle
        {
            get { return (double)GetValue(LeftAngleProperty); }
            set { SetValue(LeftAngleProperty, value); }
        }

        public static readonly DependencyProperty LeftAngleProperty =
            DependencyProperty.Register("LeftAngle", typeof(double), typeof(ReflectionEffect),
                new UIPropertyMetadata(0.0, PixelShaderConstantCallback(1)));

        public double RightAngle
        {
            get { return (double)GetValue(RightAngleProperty); }
            set { SetValue(RightAngleProperty, value); }
        }

        public static readonly DependencyProperty RightAngleProperty =
            DependencyProperty.Register("RightAngle", typeof(double), typeof(ReflectionEffect),
                new UIPropertyMetadata(0.0, PixelShaderConstantCallback(2)));

        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(double), typeof(ReflectionEffect),
                new UIPropertyMetadata(0.0, PixelShaderConstantCallback(3)));

        #endregion

        #region Member Data

        private static PixelShader _pixelShader = new PixelShader();

        #endregion

        public UserControl GetEffectGrid(UIElement uiElement)
        {
            return new UserControl();
        }
    }
}
