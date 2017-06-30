using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transitionals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Media.Effects;
    using System.Windows;

    /// <summary>
    /// This is the implementation of an extensible framework ShaderEffect which loads
    /// a shader model 2 pixel shader. Dependecy properties declared in this class are mapped
    /// to registers as defined in the *.ps file being loaded below.
    /// </summary>
    public class RippleTransitionEffect : TransitionEffect
    {
        /// <summary>
        /// Creates an instance of the shader.
        /// </summary>
        public RippleTransitionEffect()
        {
            PixelShader shader = new PixelShader();
            shader.UriSource = Global.MakePackUri("ShaderSource/RippleTransitionEffect.ps");
            PixelShader = shader;
        }
    }
}
