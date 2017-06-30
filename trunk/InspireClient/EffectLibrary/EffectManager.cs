using System.Collections.Generic;
using System.Windows.Media.Effects;
using System.Windows.Controls;
using EffectLibrary.Interfaces;
using EffectLibrary.PropertyGrids;
using EffectLibrary.Effects;
using System.Windows;

namespace EffectLibrary
{
    public static class EffectManager
    {
        static EffectManager()
        {
            CustomEffects = new List<string>();
            
            CustomEffects.Add("Banded Swirl");
            CustomEffects.Add("Bloom");
            CustomEffects.Add("Blur");
            CustomEffects.Add("Bright Extract");
            CustomEffects.Add("Chroma Key Alpha");
            CustomEffects.Add("Color Tone");
            CustomEffects.Add("Contrast Adjust");
            CustomEffects.Add("Directional Blur");
            CustomEffects.Add("DropShadow");
            CustomEffects.Add("Gloom");
            CustomEffects.Add("Embossed");
            CustomEffects.Add("GrayScale");
            CustomEffects.Add("Growable Poisson Disk");
            CustomEffects.Add("Hatching");
            CustomEffects.Add("Invert Color");
            CustomEffects.Add("Light Streak");
            CustomEffects.Add("Magnify");
            CustomEffects.Add("Monochrome");
            CustomEffects.Add("Pinch");
            CustomEffects.Add("Pixelate");
           // CustomEffects.Add("Reflection Effect");
            CustomEffects.Add("Ripple");
            CustomEffects.Add("Sharpen");
            CustomEffects.Add("Smooth Magnify");
            CustomEffects.Add("Swirl");
            CustomEffects.Add("Tone Mapping");
            CustomEffects.Add("Toon Shader");
            CustomEffects.Add("Wave");
            CustomEffects.Add("Zoom Blur");
        }

        static readonly List<string> CustomEffects;

        public static List<string> GetEffectNames()
        {
            return CustomEffects;
        }

        public static UserControl GetPropertyGridForEffect(UIElement uiElement)
        {
            Effect effect = uiElement.Effect;

            var userControl = new UserControl();

            if (effect is ICustomEffect)
                userControl = ((ICustomEffect)effect).GetEffectGrid(uiElement);
            else
            {
                if (uiElement.Effect.GetType() == typeof(DropShadowEffect))
                    userControl = new DropShadowGrid(uiElement);
                if (uiElement.Effect.GetType() == typeof(BlurEffect))
                    userControl = new BlurGrid(uiElement);
            }
            return userControl;
        }

        private static UIElement ApplyEffect(UIElement uiElement, Effect shaderEffect)
        {
            uiElement.Effect = shaderEffect;

            return GetPropertyGridForEffect(uiElement);
        }

        public static UIElement ApplyEffectGetPropertyGrid(string effectName, UIElement uiElement)
        {
            //Rectangle rectangle = new Rectangle() { Width=20, Height=20, Fill = Brushes.Green };

            switch (effectName)
            {
                case ("Banded Swirl"): return ApplyEffect(uiElement, new BandedSwirlEffect());
                case ("Bloom"): return ApplyEffect(uiElement, new BloomEffect());
                case ("Blur"): return ApplyEffect(uiElement, new BlurEffect());
                case ("Bright Extract"): return ApplyEffect(uiElement, new BrightExtractEffect());
                case ("Chroma Key Alpha"): return ApplyEffect(uiElement, new ChromaKeyAlphaEffect());
                case ("Color Tone"): return ApplyEffect(uiElement, new ColorToneEffect());
                case ("Contrast Adjust"): return ApplyEffect(uiElement, new ContrastAdjustEffect());
                case ("Directional Blur"): return ApplyEffect(uiElement, new DirectionalBlurEffect());
                case ("DropShadow"): return ApplyEffect(uiElement, new DropShadowEffect());
                case ("Embossed"): return ApplyEffect(uiElement, new EmbossedEffect());
                case ("Gloom"): return ApplyEffect(uiElement, new GloomEffect());
                case ("GrayScale"): return ApplyEffect(uiElement, new GrayscaleEffect());
                case ("Growable Poisson Disk"): return ApplyEffect(uiElement, new GrowablePoissonDiskEffect());
                case ("Hatching"): return ApplyEffect(uiElement, new HatchingEffect());
                case ("Invert Color"): return ApplyEffect(uiElement, new InvertColorEffect());
                case ("Light Streak"): return ApplyEffect(uiElement, new LightStreakEffect());
                case ("Magnify"): return ApplyEffect(uiElement, new MagnifyEffect());
                case ("Monochrome"): return ApplyEffect(uiElement, new MonochromeEffect());
                case ("Pinch"): return ApplyEffect(uiElement, new PinchEffect());
                case ("Pixelate"): return ApplyEffect(uiElement, new PixelateEffect());
                //case ("Reflection Effect"): return ApplyEffect(uiElement, new ReflectionEffect());
                case ("Ripple"): return ApplyEffect(uiElement, new RippleEffect());
                case ("Sharpen"): return ApplyEffect(uiElement, new SharpenEffect());
                case ("Smooth Magnify"): return ApplyEffect(uiElement, new SmoothMagnifyEffect());
                case ("Swirl"): return ApplyEffect(uiElement, new SwirlEffect());
                case ("Tone Mapping"): return ApplyEffect(uiElement, new ToneMappingEffect());
                case ("Toon Shader"): return ApplyEffect(uiElement, new ToonShaderEffect());
                case ("Wave"): return ApplyEffect(uiElement, new WaveShaderEffect());
                case ("Zoom Blur"): return ApplyEffect(uiElement, new ZoomBlurEffect());
                default:
                    return ApplyEffect(uiElement, new DropShadowEffect());
            }
        }

        public static int GetEffectIndex(UIElement uiElement)
        {
            switch (uiElement.Effect.GetType().Name)
            {
                case ("BandedSwirlEffect"): return 0;
                case ("BloomEffect"): return 1;
                case ("BlurEffect"): return 2;
                case ("BrightExtractEffect"): return 3;
                case ("ChromaKeyAlphaEffect"): return 4;
                case ("ColorToneEffect"): return 5;
                case ("ContrastAdjustEffect"): return 6;
                case ("DirectionalBlurEffect"): return 7;
                case ("DropShadowEffect"): return 8;
                case ("EmbossedEffect"): return 9;
                case ("GloomEffect"): return 10;
                case ("GrayscaleEffect"): return 11;
                case ("GrowablePoissonDiskEffect"): return 12;
                case ("HatchingEffect"): return 13;
                case ("InvertColorEffect"): return 14;
                case ("LightStreakEffect"): return 15;
                case ("MagnifyEffect"): return 16;
                case ("MonochromeEffect"): return 17;
                case ("PinchEffect"): return 18;
                case ("PixelateEffect"): return 19;
               // case ("ReflectionEffect"): return 20;
                case ("RippleEffect"): return 20;
                case ("SharpenEffect"): return 21;
                case ("SmoothMagnifyEffect"): return 22;
                case ("SwirlEffect"): return 23;
                case ("ToneMappingEffect"): return 24;
                case ("ToonShaderEffect"): return 25;
                case ("WaveShaderEffect"): return 26;
                case ("ZoomBlurEffect"): return 27;
                default:
                    return -1;
            }
        }
    }
}
