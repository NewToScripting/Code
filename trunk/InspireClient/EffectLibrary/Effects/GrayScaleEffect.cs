using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Windows;
using EffectLibrary.Interfaces;


namespace EffectLibrary.Effects
{
    /// <summary>
    /// Greyscale effect.
    /// </summary>
    public class GrayscaleEffect : ShaderEffect, ICustomEffect
    {
        /// <summary>
        /// Dependency property for Input.
        /// </summary>
        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GrayscaleEffect), 0 /* assigned to sampler register S0 */);

        /// <summary>
        /// PixelShader for this effect.
        /// </summary>
        private static PixelShader pixelShader;

        /// <summary>
        /// Static constructor - Create a PixelShader for all GreyscaleEffect instances. 
        /// </summary>
        static GrayscaleEffect()
        {
            pixelShader = new PixelShader();
            pixelShader.UriSource = Global.MakePackUri("ShaderSource/Greyscale.ps");
        }

        /// <summary>
        /// Constructor - Assign the PixelShader property and set the shader parameters to default values.
        /// </summary>
        public GrayscaleEffect()
        {
            this.PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
        }

        /// <summary>
        /// Gets or sets Input properties. 
        /// </summary>
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        #region ICustomEffect Members

        public System.Windows.Controls.UserControl GetEffectGrid(UIElement uiElement)
        {
            return null;
        }

        #endregion
    }
}
