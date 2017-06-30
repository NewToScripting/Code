// <copyright file="ChromaKeyAlphaEffect.cs" company="Microsoft Corporation">
// Copyright (c) 2009 Microsoft Corporation All Rights Reserved
// </copyright>
// <summary>Color Key Alpha Pixel Effect for Silverlight 3</summary>

namespace EffectLibrary.Effects
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Effects;
    using EffectLibrary;
    using EffectLibrary.Interfaces;
    using EffectLibrary.PropertyGrids;

    /// <summary>
    /// Color Key alpha effect for Silverlight 3
    /// </summary>
    [Description("Chroma Key Alpha effect with tolerance")]
    public class ChromaKeyAlphaEffect : ShaderEffect , ICustomEffect
    {
        #region Fields

        /// <summary>
        /// This property is mapped to the InputColor variable within the pixel shader.
        /// </summary>
        public static readonly DependencyProperty ColorKeyProperty = DependencyProperty.Register("ColorKey", typeof(Color), typeof(ChromaKeyAlphaEffect), new PropertyMetadata(Colors.Green, PixelShaderConstantCallback(0)));

        /// <summary>
        /// This is the tolerance 0=exact 1=full
        /// </summary>
        public static readonly DependencyProperty ToleranceProperty = DependencyProperty.Register("Tolerance", typeof(double), typeof(ChromaKeyAlphaEffect), new PropertyMetadata(0.1, PixelShaderConstantCallback(1)));

        /// <summary>
        /// The explict input for this pixel shader.
        /// </summary>
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ChromaKeyAlphaEffect), 0);

        /// <summary>
        /// A reference to the pixel shader used.
        /// </summary>
        private static PixelShader pixelShader;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes static members of the ChromaKeyAlphaEffect class.
        /// </summary>
        static ChromaKeyAlphaEffect()
        {
            pixelShader = new PixelShader();

            pixelShader.UriSource = Global.MakePackUri("ShaderSource/ChromaKeyAlpha.ps");
        }

        /// <summary>
        /// Initializes a new instance of the ChromaKeyAlphaEffect class.
        /// </summary>
        public ChromaKeyAlphaEffect()
        {
            this.PixelShader = pixelShader;

            UpdateShaderValue(ColorKeyProperty);
            UpdateShaderValue(ToleranceProperty);
            UpdateShaderValue(InputProperty);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the InputColor variable within the shader.
        /// </summary>
        public Color ColorKey
        {
            get 
            { 
                return (Color)GetValue(ColorKeyProperty); 
            }

            set 
            { 
                SetValue(ColorKeyProperty, value); 
            }
        }

        /// <summary>
        /// Gets or sets the exactness by which the color must match (0=exact, 1=all colors)
        /// </summary>
        public double Tolerance
        {
            get
            {
                return (double)GetValue(ToleranceProperty);
            }

            set
            {
                if (value >= 0.0 && value <= 1.0)
                {
                    SetValue(ToleranceProperty, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Input of shader.
        /// </summary>
        [Description("Gets or sets the input of the shader")]
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }
        #endregion

        #region ICustomEffect Members

        public System.Windows.Controls.UserControl GetEffectGrid(UIElement uiElement)
        {
            return new ChromaKeyAlphaEffectGrid(uiElement);
        }

        #endregion
    }
}
