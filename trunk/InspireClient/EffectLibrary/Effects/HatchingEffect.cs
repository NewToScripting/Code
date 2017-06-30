using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using EffectLibrary.Interfaces;
using EffectLibrary.PropertyGrids;

namespace EffectLibrary.Effects
{
    public class HatchingEffect : ShaderEffect, ICustomEffect
    {
        #region Constructors

        static HatchingEffect()
        {
            pixelShader.UriSource = Global.MakePackUri("ShaderSource/HatchingEffect.ps");
        }

        public HatchingEffect()
        {
            this.PixelShader = pixelShader;

            LightToneTexture = this.LoadImageBrush("Textures/LightToneTexture.png");
            MiddleToneTexture = this.LoadImageBrush("Textures/MiddleToneTexture.png");
            DarkToneTexture = this.LoadImageBrush("Textures/DarkToneTexture.png");

            // Update each DependencyProperty that's registered with a shader register.  This
            // is needed to ensure the shader gets sent the proper default value.
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(LightToneTextureProperty);
            UpdateShaderValue(MiddleToneTextureProperty);
            UpdateShaderValue(DarkToneTextureProperty);

            UpdateShaderValue(TransparentToneThresholdProperty);
            UpdateShaderValue(LightToneThresholdProperty);
            UpdateShaderValue(MiddleToneThresholdProperty);
            UpdateShaderValue(DarkToneThresholdProperty);
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
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(HatchingEffect), 0);

        public Brush LightToneTexture
        {
            get { return (Brush)GetValue(LightToneTextureProperty); }
            set { SetValue(LightToneTextureProperty, value); }
        }

        // Brush-valued properties turn into sampler-property in the shader.
        // This helper sets "ImplicitInput" as the default, meaning the default
        // sampler is whatever the rendering of the element it's being applied to is.
        public static readonly DependencyProperty LightToneTextureProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("LightToneTexture", typeof(HatchingEffect), 1);

        public Brush MiddleToneTexture
        {
            get { return (Brush)GetValue(MiddleToneTextureProperty); }
            set { SetValue(MiddleToneTextureProperty, value); }
        }

        // Brush-valued properties turn into sampler-property in the shader.
        // This helper sets "ImplicitInput" as the default, meaning the default
        // sampler is whatever the rendering of the element it's being applied to is.
        public static readonly DependencyProperty MiddleToneTextureProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("MiddleToneTexture", typeof(HatchingEffect), 2);

        public Brush DarkToneTexture
        {
            get { return (Brush)GetValue(DarkToneTextureProperty); }
            set { SetValue(DarkToneTextureProperty, value); }
        }

        // Brush-valued properties turn into sampler-property in the shader.
        // This helper sets "ImplicitInput" as the default, meaning the default
        // sampler is whatever the rendering of the element it's being applied to is.
        public static readonly DependencyProperty DarkToneTextureProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("DarkToneTexture", typeof(HatchingEffect), 3);

        //////////////////////////////////////////////////////////////////////////
        // Thresholds 
        //////////////////////////////////////////////////////////////////////////

        public double TransparentToneThreshold
        {
            get { return (double)GetValue(TransparentToneThresholdProperty); }
            set { SetValue(TransparentToneThresholdProperty, value); }
        }

        // Scalar-valued properties turn into shader constants with the register
        // number sent into PixelShaderConstantCallback().
        public static readonly DependencyProperty TransparentToneThresholdProperty =
            DependencyProperty.Register("TransparentToneThreshold", typeof(double), typeof(HatchingEffect),
                    new PropertyMetadata(4.0, PixelShaderConstantCallback(0)));

        public double LightToneThreshold
        {
            get { return (double)GetValue(LightToneThresholdProperty); }
            set { SetValue(LightToneThresholdProperty, value); }
        }

        // Scalar-valued properties turn into shader constants with the register
        // number sent into PixelShaderConstantCallback().
        public static readonly DependencyProperty LightToneThresholdProperty =
            DependencyProperty.Register("LightToneThreshold", typeof(double), typeof(HatchingEffect),
                    new PropertyMetadata(3.0, PixelShaderConstantCallback(1)));

        public double MiddleToneThreshold
        {
            get { return (double)GetValue(MiddleToneThresholdProperty); }
            set { SetValue(MiddleToneThresholdProperty, value); }
        }

        // Scalar-valued properties turn into shader constants with the register
        // number sent into PixelShaderConstantCallback().
        public static readonly DependencyProperty MiddleToneThresholdProperty =
            DependencyProperty.Register("MiddleToneThreshold", typeof(double), typeof(HatchingEffect),
                    new PropertyMetadata(2.0, PixelShaderConstantCallback(2)));

        public double DarkToneThreshold
        {
            get { return (double)GetValue(DarkToneThresholdProperty); }
            set { SetValue(DarkToneThresholdProperty, value); }
        }

        // Scalar-valued properties turn into shader constants with the register
        // number sent into PixelShaderConstantCallback().
        public static readonly DependencyProperty DarkToneThresholdProperty =
            DependencyProperty.Register("DarkToneThreshold", typeof(double), typeof(HatchingEffect),
                    new PropertyMetadata(1.0, PixelShaderConstantCallback(3)));

        #endregion

        #region Member Data

        private static PixelShader pixelShader = new PixelShader();

        ImageBrush LoadImageBrush(string imageSource)
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(Global.MakePackUri(imageSource));
            return brush;
        }

        #endregion

        #region ICustomEffect Members

        public System.Windows.Controls.UserControl GetEffectGrid(UIElement uiElement)
        {
            return new HatchingGrid(uiElement);
        }

        #endregion

    }

}
