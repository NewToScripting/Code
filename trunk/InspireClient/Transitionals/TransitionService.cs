using System;
using System.Collections.Generic;
using System.Windows;
using Transitionals.Transitions;

namespace Transitionals
{
    public class TransitionService
    {
        //static FadeTransition fadeTransition = new FadeTransition();

        static TransitionService()
        {
            TransitionList.Add("None");
            TransitionList.Add("Banded Swirl FX");
            TransitionList.Add("Blinds FX");
            TransitionList.Add("Blood Transition FX");
            TransitionList.Add("Checkerboard");
            TransitionList.Add("Circle Blur FX");
            TransitionList.Add("Circle Reveal FX");
            TransitionList.Add("Circle Stretch FX");
            TransitionList.Add("Cloud Reveal FX");
            TransitionList.Add("Crumble FX");
            TransitionList.Add("Diagnal Wipe");
            TransitionList.Add("Diamonds");
            TransitionList.Add("Disolve FX");
            TransitionList.Add("Door");
            TransitionList.Add("Dots");
            TransitionList.Add("Double Rotate Wipe");
            TransitionList.Add("Drop Fade FX");
            TransitionList.Add("Fade and Blur");
            TransitionList.Add("Fade and Grow");
            TransitionList.Add("Fade");
            TransitionList.Add("Fade FX");
            TransitionList.Add("Flip");
            TransitionList.Add("Horizontal Blinds");
            TransitionList.Add("Horizontal Wipe");
            TransitionList.Add("Least Bright FX");
            TransitionList.Add("Line Reveal FX");
            TransitionList.Add("Melt");
            TransitionList.Add("Most Bright FX");
            TransitionList.Add("Page");
            TransitionList.Add("Pixelate FX");
            TransitionList.Add("Pixelate In FX");
            TransitionList.Add("Pixelate Out FX");
            TransitionList.Add("Radial Blur FX");
            TransitionList.Add("Radial Wiggle FX");
            TransitionList.Add("Random Circle Reveal FX");
            TransitionList.Add("Ripple FX");
            TransitionList.Add("Roll");
            TransitionList.Add("Rotate Crumble FX");
            TransitionList.Add("Rotate Up");
            TransitionList.Add("Rotate Down");
            TransitionList.Add("Rotate Left");
            TransitionList.Add("Rotate Right");
            TransitionList.Add("Rotate Wipe");
            TransitionList.Add("Saturate FX");
            TransitionList.Add("Shrink FX");
            TransitionList.Add("Slide In FX");
            TransitionList.Add("Slide Out Left In Right");
            TransitionList.Add("Slide Out Right In Left");
            TransitionList.Add("Slide Out-In Right");
            TransitionList.Add("Slide Out-In Left");
            TransitionList.Add("Slide Out-In Bottom");
            TransitionList.Add("Slide Out-In Top");
            TransitionList.Add("Slide Out Bottom In Top");
            TransitionList.Add("Slide Out Top In Bottom");
            TransitionList.Add("Smooth Swirl Grid FX");
            TransitionList.Add("Star");
            TransitionList.Add("Swirl FX");
            TransitionList.Add("Swirl Grid FX");
            TransitionList.Add("Translate");
            TransitionList.Add("Turn Over Up");
            TransitionList.Add("Turn Over Down");
            TransitionList.Add("Turn Over Left");
            TransitionList.Add("Turn Over Right");
            TransitionList.Add("Vertical Blinds");
            TransitionList.Add("Vertical Wipe");
            TransitionList.Add("Wave FX");
            //TransitionList.Add("Zoom In");
        }

        #region Sets Page Transition

        public static List<string> TransitionList = new List<string>();

       // private static Transition transition;

        public static Transition SetTransition(string transition)
        {
            if (!string.IsNullOrEmpty(transition))
            {
                switch (transition)
                {
                    case ("None"):
                        {
                            return new NoTransition();
                        }
                    case ("Banded Swirl FX"):
                        {
                            return new BandedSwirlTransitionFX();
                        }
                    case ("Blinds FX"):
                        {
                            return new BlindsTransitionFX();
                        }
                    case ("Blood Transition FX"):
                        {
                            return new BloodTransitionFX();
                        }
                    case ("Circle Blur FX"):
                        {
                            return new CircleBlurTransitionFX();
                        }
                    case ("Circle Reveal FX"):
                        {
                            return new CircleRevealTransitionFX();
                        }
                    case ("Circle Stretch FX"):
                        {
                            return new CircleStretchTransitionFX();
                        }
                    case ("Cloud Reveal FX"):
                        {
                            return new CloudRevealTransitionFX();
                        }
                    case ("Crumble FX"):
                        {
                            return new CrumbleTransitionFX();
                        }
                    case ("Checkerboard"):
                        {
                            return new CheckerboardTransition();
                        }
                    case ("Diagnal Wipe"):
                        {
                            return new DiagonalWipeTransition();
                        }
                    case ("Diamonds"):
                        {
                            return new DiamondsTransition();
                        }
                    case ("Disolve FX"):
                        {
                            return new DisolveTransitionFX();
                        }
                    case ("Door"):
                        {
                            return new DoorTransition();
                        }
                    case ("Dots"):
                        {
                            return new DotsTransition();
                        }
                    case ("Double Rotate Wipe"):
                        {
                            return new DoubleRotateWipeTransition();
                        }
                    case ("Drop Fade FX"):
                        {
                            return new DropFadeTransitionFX();
                        }
                    case ("Fade and Blur"):
                        {
                            return new FadeAndBlurTransition();
                        }
                    case ("Fade and Grow"):
                        {
                            return new FadeAndGrowTransition();
                        }
                    case ("Fade"):
                        {
                            return new FadeTransition();
                            //return fadeTransition;
                        }
                    case ("Fade FX"):
                        {
                            return new FadeTransitionFX();
                        }
                    case ("Flip"):
                        {
                            return new FlipTransition();
                        }
                    case ("Horizontal Blinds"):
                        {
                            return new HorizontalBlindsTransition();
                        }
                    case ("Horizontal Wipe"):
                        {
                            return new HorizontalWipeTransition();
                        }
                    case ("Least Bright FX"):
                        {
                            return new LeastBrightTransitionFX();
                        }
                    case ("Line Reveal FX"):
                        {
                            return new LineRevealTransitionFX();
                        }
                    case ("Melt"):
                        {
                            return new MeltTransition();
                        }
                    case ("Most Bright FX"):
                        {
                            return new MostBrightTransitionFX();
                        }
                    case ("Page"):
                        {
                            return new PageTransition();
                        }
                    case ("Pixelate FX"):
                        {
                            return new PixelateTransitionFX();
                        }
                    case ("Pixelate In FX"):
                        {
                            return new PixelateInTransitionFX();
                        }
                    case ("Pixelate Out FX"):
                        {
                            return new PixelateOutTransitionFX();
                        }
                    case ("Radial Blur FX"):
                        {
                            return new RadialBlurTransitionFX();
                        }
                    case ("Radial Wiggle FX"):
                        {
                            return new RadialWiggleTransitionFX();
                        }
                    case ("Random Circle Reveal FX"):
                        {
                            return new RandomCircleRevealTransitionFX();
                        }
                    case ("Ripple FX"):
                        {
                            return new RippleTransitionFX();
                        }
                    case ("Roll"):
                        {
                            return new RollTransition();
                        }
                    case ("Rotate Crumble FX"):
                        {
                            return new RotateCrumbleTransitionFX();
                        }
                    case ("Rotate Up"):
                        {
                            return new RotateUpTransition();
                        }
                    case ("Rotate Down"):
                        {
                            return new RotateDownTransition();
                        }
                    case ("Rotate Left"):
                        {
                            return new RotateTransition();

                        }
                    case ("Rotate Right"):
                        {
                            return new RotateRightTransition();
                        }
                    case ("Rotate Wipe"):
                        {
                            return new RotateWipeTransition();
                        }
                    case ("Saturate FX"):
                        {
                            return new SaturateTransitionFX();
                        }
                    case ("Shrink FX"):
                        {
                            return new ShrinkTransitionFX();
                        }
                    case ("Slide Out Right In Left"):
                        {
                            return new SlideOutRightInLeft();
                        }
                    case ("Slide Out Left In Right"):
                        {
                            return new SlideOutLeftInRight();
                        }
                    case ("Slide Out-In Right"):
                        {
                            return new SlideOutInRightTransition();
                        }
                    case ("Slide Out-In Left"):
                        {
                            return new SlideOutInLeftTransition();
                        }
                    case ("Slide Out-In Bottom"):
                        {
                            return new SlideOutInBottomTransition();
                        }
                    case ("Slide Out-In Top"):
                        {
                            return new SlideOutInTopTransition();
                        }
                    case ("Slide Out Top In Bottom"):
                        {
                            return new SlideOutTopInBottom();
                        }
                    case ("Slide Out Bottom In Top"):
                        {
                            return new SlideOutBottomInTop();
                        }
                    case ("Star"):
                        {
                            return new StarTransition();
                        }
                    case ("Swirl FX"):
                        {
                            return new SwirlTransitionFX();
                        }
                    case ("Swirl Grid FX"):
                        {
                            return new SwirlGridTransitionFX();
                        }
                    case ("Translate"):
                        {
                            var translateTransform = new TranslateTransition();
                            translateTransform.Duration = new Duration(TimeSpan.FromSeconds(2));
                            return translateTransform;
                        }
                    case ("Turn Over Up"):
                        {
                            return new TurnOverUpTransition();
                        }
                    case ("Turn Over Down"):
                        {
                            return new TurnOverDownTransition();
                        }
                    case ("Turn Over Left"):
                        {
                            return new TurnOverLeftTransition();
                        }
                    case ("Turn Over Right"):
                        {
                            return new TurnOverRightTransition();
                        }
                    case ("Vertical Blinds"):
                        {
                            return new VerticalBlindsTransition();
                        }
                    case ("Vertical Wipe"):
                        {
                            return new VerticalWipeTransition();
                        }
                    case ("Wave FX"):
                        {
                            return new WaveTransitionFX();
                        }
                    //case ("Zoom In"):
                    //    {
                    //        return new ZoomInTransition();
                    //    }
                    default:
                        return new FadeTransition();
                }
            }
            return new FadeTransition();
        }


        public static string GetTransitionName(Transition transition)
        {
            switch (transition.GetType().Name)
            {
                case ("NoTransition"):
                    return "None";
                case ("BandedSwirlTransitionFX"):
                    return "Banded Swirl FX";
                case ("BlindsTransitionFX"):
                    return "Blinds FX";
                case ("BloodTransitionFX"):
                    return "Blood Transition FX";
                case ("CheckerboardTransition"):
                    return "Checkerboard";
                case ("CircleBlurTransitionFX"):
                    return "Circle Blur FX";
                case ("CircleRevealTransitionFX"):
                    return "Circle Reveal FX";
                case ("CircleStretchTransitionFX"):
                    return "Circle Stretch FX";
                case ("CloudRevealTransitionFX"):
                    return "Cloud Reveal FX";
                case ("CrumbleTransitionFX"):
                    return "Crumble FX";
                case ("DiagonalWipeTransition"):
                    return "Diagnal Wipe";
                case ("DiamondsTransition"):
                    return "Diamonds";
                case ("DisolveTransitionFX"):
                    return "Disolve FX";
                case ("DoorTransition"):
                    return "Door";
                case ("DotsTransition"):
                    return "Dots";
                case ("DoubleRotateWipeTransition"):
                    return "Double Rotate Wipe";
                case ("DropFadeTransitionFX"):
                    return "Drop Fade FX";
                case ("FadeAndBlurTransition"):
                    return "Fade and Blur";
                case ("FadeAndGrowTransition"):
                    return "Fade and Grow";
                case ("FadeTransition"):
                    return "Fade";
                case ("FadeTransitionFX"):
                    return "Fade FX";
                case ("FlipTransition"):
                    return "Flip";
                case ("HorizontalBlindsTransition"):
                    return "Horizontal Blinds";
                case ("HorizontalWipeTransition"):
                    return "Horizontal Wipe";
                case ("LeastBrightTransitionFX"):
                    return "Least Bright FX";
                case ("LineRevealTransitionFX"):
                    return "Line Reveal FX";
                case ("MeltTransition"):
                    return "Melt";
                case ("MostBrightTransitionFX"):
                    return "Most Bright FX";
                case ("PageTransition"):
                    return "Page";
                case ("PixelateTransitionFX"):
                    return "Pixelate FX";
                case ("PixelateInTransitionFX"):
                    return "Pixelate In FX";
                case ("PixelateOutTransitionFX"):
                    return "Pixelate Out FX";
                case ("RadialBlurTransitionFX"):
                    return "Radial Blur FX";
                case ("RadialWiggleTransitionFX"):
                    return "Radial Wiggle FX";
                case ("RandomCircleRevealTransitionFX"):
                    return "Random Circle Reveal FX";
                case ("RippleTransitionFX"):
                    return "Ripple FX";
                case ("RollTransition"):
                    return "Roll";
                case ("RotateCrumbleTransitionFX"):
                    return "Rotate Crumble FX";
                case ("RotateRightTransition"):
                    return "Rotate Right";
                case ("RotateUpTransition"):
                    return "Rotate Up";
                case ("RotateDownTransition"):
                    return "Rotate Down";
                case ("RotateTransition"):
                    return "Rotate Left";
                case ("TurnOverUpTransition"):
                    return "Turn Over Up";
                case ("TurnOverDownTransition"):
                    return "Turn Over Down";
                case ("TurnOverLeftTransition"):
                    return "Turn Over Left";
                case ("TurnOverRightTransition"):
                    return "Turn Over Right";
                case ("RotateWipeTransition"):
                    return "Rotate Wipe";
                case ("SaturateTransitionFX"):
                    return "Saturate FX";
                case ("ShrinkTransitionFX"):
                    return "Shrink FX";
                case ("SlideInTransitionFX"):
                    return "Slide In FX";
                case ("SlideOutRightInLeft"):
                    return "Slide Out Right In Left";
                case ("SlideOutLeftInRight"):
                    return "Slide Out Left In Right";
                case ("SlideOutInRightTransition"):
                    return "Slide Out-In Right";
                case ("SlideOutInLeftTransition"):
                    return "Slide Out-In Left";
                case ("SlideOutInBottomTransition"):
                    return "Slide Out-In Bottom";
                case ("SlideOutInTopTransition"):
                    return "Slide Out-In Top";
                case ("SlideOutTopInBottom"):
                    return "Slide Out Top In Bottom";
                case ("SlideOutBottomInTop"):
                    return "Slide Out Bottom In Top";
                case ("SmoothSwirlGridTransitionFX"):
                    return "Smooth Swirl Grid FX";
                case ("StarTransition"):
                    return "Star";
                case ("SwirlTransitionFX"):
                    return "Swirl FX";
                case ("SwirlGridTransitionFX"):
                    return "Swirl Grid FX";
                case ("TranslateTransition"):
                    return "Translate";
                case ("VerticalBlindsTransition"):
                    return "Vertical Blinds";
                case ("VerticalWipeTransition"):
                    return "Vertical Wipe";
                case ("WaveTransitionFX"):
                    return "Wave FX";
                //case ("ZoomInTransition"):
                //    return "Zoom In";
                default:
                    return "Fade";
            }
        }
        #endregion

    }
}
