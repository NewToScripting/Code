﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.


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
    public class FadeTransitionEffect : TransitionEffect
    {
        #region Dependency Properties

        /// <summary>
        /// Creates an instance of the shader.
        /// </summary>
        public FadeTransitionEffect()
        {
            PixelShader shader = new PixelShader();
            shader.UriSource = Global.MakePackUri("ShaderSource/FadeTransitionEffect.ps");
            PixelShader = shader;
        }

        #endregion
    }
}