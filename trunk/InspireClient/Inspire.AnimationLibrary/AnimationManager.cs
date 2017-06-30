using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Inspire.AnimationLibrary
{
    public static class AnimationManager
    {
        private static readonly ResourceDictionary Myresourcedictionary;
        private static UserControl _canvasControl;

        static AnimationManager()
        {
            Myresourcedictionary = new ResourceDictionary();

            Myresourcedictionary.Source = new Uri("/Inspire.AnimationLibrary;component/Resources/Animations.xaml",
                                                  UriKind.RelativeOrAbsolute);

            Window mainApp = Application.Current.Windows[0];

            if (mainApp != null)
            {
                var designWindow = mainApp.FindName("DesignerWindow") as UserControl;

                if (designWindow != null)
                {
                    TabControl tabControl = designWindow.FindName("DesignerDragCanvasHolder") as TabControl;
                    if (tabControl != null)
                    {
                        if(tabControl.SelectedValue != null)
                            _canvasControl = ((TabItem)tabControl.SelectedValue).Content as UserControl;
                    }
                }
            }
        }

        public static CustomStoryboard GetPreviewStoryboard(CustomStoryboard _storyboard, ContentControl uielement, string key)
        {
            double startLeft;
            double startTop;
            double originalLeft = Canvas.GetLeft(uielement);
            double originalTop = Canvas.GetTop(uielement);

            Size canvasSize = new Size();

            if (_canvasControl != null) canvasSize = new Size(_canvasControl.Width, _canvasControl.Height);
            

            var storyBoard = new CustomStoryboard(_storyboard);

                switch (key)
                {
                    case "RollInFromRight":
                        {
                            startLeft = (canvasSize.Width + 20);

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            EasingDoubleKeyFrame flin1 = new EasingDoubleKeyFrame(startLeft);
                            flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                            EasingDoubleKeyFrame flin2 = new EasingDoubleKeyFrame(originalLeft);
                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;
                            flin2.EasingFunction = backease;

                            flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);
                        }
                        break;
                    case "RollInFromLeft":
                        {
                            if (uielement.Width > 0)
                                startLeft = (uielement.Width + 20) * -1;
                            else
                                startLeft = (uielement.ActualWidth + 20) * -1;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            EasingDoubleKeyFrame flin1 = new EasingDoubleKeyFrame(startLeft);
                            flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                            EasingDoubleKeyFrame flin2 = new EasingDoubleKeyFrame(originalLeft);
                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;
                            flin2.EasingFunction = backease;

                            flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);
                        }
                        break;
                    case "FlyInLeft":
                        {
                            if (uielement.Width > 0)
                                startLeft = (uielement.Width + 20) * -1;
                            else
                                startLeft = (uielement.ActualWidth + 20) * -1;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            EasingDoubleKeyFrame flin1 = new EasingDoubleKeyFrame(startLeft);
                            flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                            EasingDoubleKeyFrame flin2 = new EasingDoubleKeyFrame(originalLeft);
                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;
                            flin2.EasingFunction = new BackEase();

                            flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));
                           
                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);
                        }
                        break;
                    case "FlyInRight":
                        {
                            startLeft = (canvasSize.Width + 20);

                            var dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            var flin1 = new EasingDoubleKeyFrame(startLeft)
                            {
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                            };

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;


                            var flin2 = new EasingDoubleKeyFrame(originalLeft)
                                            {
                                                EasingFunction = backease,
                                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                                            };

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);
                        }
                        break;
                    case "FlyInTop":
                        {
                            if (uielement.Height > 0)
                                startTop = (originalTop + uielement.Height + 20) * -1;
                            else
                                startTop = (originalTop + uielement.ActualHeight + 20) * -1;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            var flin1 = new EasingDoubleKeyFrame(startTop);
                            flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                            var flin2 = new EasingDoubleKeyFrame(originalTop);
                            flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;

                            flin2.EasingFunction = backease;

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);

                        }
                        break;
                    case "FlyInBottom":
                        {
                            startTop = canvasSize.Height + 20;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            var flin1 = new EasingDoubleKeyFrame(startTop);
                            flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                            var flin2 = new EasingDoubleKeyFrame(originalTop);
                            flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;

                            flin2.EasingFunction = backease;

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);
                        }
                        break;
                    case "FlyOutLeft":
                        {
                            double endpoint;

                            if (uielement.Width > 0)
                                endpoint = (originalLeft + uielement.Width + 20) * -1;
                            else
                                endpoint = (originalLeft + uielement.ActualWidth + 20) * -1;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            var flout1 = new EasingDoubleKeyFrame(originalLeft);
                            flout1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;

                            flout1.EasingFunction = backease;

                            var flout2 = new EasingDoubleKeyFrame(endpoint);
                            flout2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                            
                            dbA.KeyFrames.Add(flout1);
                            dbA.KeyFrames.Add(flout2);
                        }
                        break;
                    case "FlyOutRight":
                        {
                            double endpoint = canvasSize.Width + 20;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            var flout1 = new EasingDoubleKeyFrame(originalLeft);
                            flout1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;

                            flout1.EasingFunction = backease;

                            var flout2 = new EasingDoubleKeyFrame(endpoint);
                            flout2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                            dbA.KeyFrames.Add(flout1);
                            dbA.KeyFrames.Add(flout2);

                        }
                        break;
                    case "FlyOutTop":
                        {
                            double endTop;

                            if (uielement.Height > 0)
                                endTop = (originalTop + uielement.Height + 20) * -1;
                            else
                                endTop = (originalTop + uielement.ActualHeight + 20) * -1;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            var flout1 = new EasingDoubleKeyFrame(originalTop);
                            flout1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                            var flout2 = new EasingDoubleKeyFrame(endTop);
                            flout2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;

                            flout2.EasingFunction = backease;

                            dbA.KeyFrames.Add(flout1);
                            dbA.KeyFrames.Add(flout2);
                        }
                        break;
                    case "FlyOutBottom":
                        {
                            double endTop = canvasSize.Height + 20;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            var flout1 = new EasingDoubleKeyFrame(originalTop);
                            flout1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                            var flout2 = new EasingDoubleKeyFrame(endTop);
                            flout2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;

                            flout2.EasingFunction = backease;

                            dbA.KeyFrames.Add(flout1);
                            dbA.KeyFrames.Add(flout2);

                        }
                        break;
                    default:
                        {

                        }
                        break;
                }

            return storyBoard;
        }

        public static TimeSpan SaveAnimations(ContentControl uielement, RoutedEvent startTrig, RoutedEvent stopTrig, Size canvasSize)
        {
            TimeSpan laststoryBoardOut = TimeSpan.FromSeconds(0);

            object storyboardResource = uielement.Resources["MainStoryboard"];

            if (storyboardResource != null)
            {
                Storyboard parentStoryboard = storyboardResource as Storyboard;
                if (parentStoryboard != null)
                {
                    var resources = new TimelineCollection(); // = TestControl.Resources;

                    foreach (CustomStoryboard item in parentStoryboard.Children)
                    {
                        resources.Add(new CustomStoryboard(item));
                    }

                    var sortedDict =
                        (from entry in resources orderby entry.BeginTime ascending select entry);
                    if(sortedDict.Count() > 0)
                        laststoryBoardOut = sortedDict.Last().BeginTime is TimeSpan ? (TimeSpan) sortedDict.Last().BeginTime : new TimeSpan(0);

                    BeginStoryboard mainBeginStoryboard = GetMainBeginStoryboard(uielement, sortedDict, canvasSize);

                    //if (!uielement.Resources.Contains("Test"))
                    //{
                    //    uielement.Resources.Add("Test", mainBeginStoryboard);
                    //}

                    EventTrigger eventTrigger = new EventTrigger(startTrig);
                    eventTrigger.Actions.Add(mainBeginStoryboard);
                    uielement.Resources.Clear();
                    uielement.Triggers.Clear();

                    //uielement.Resources.Add("Test", mainBeginStoryboard);
                    uielement.Triggers.Add(eventTrigger);
                }
            }
            return laststoryBoardOut;
        }

        public static void ApplyAnimations(ContentControl uielement, Size canvasSize)
        {
            object storyboardResource = uielement.Resources["MainStoryboard"];

            if (storyboardResource != null)
            {
                Storyboard parentStoryboard = storyboardResource as Storyboard;
                if (parentStoryboard != null)
                {
                    var resources = new TimelineCollection(); // = TestControl.Resources;

                    foreach (CustomStoryboard item in parentStoryboard.Children)
                    {
                        resources.Add(new CustomStoryboard(item));
                    }

                    var sortedDict =
                        (from entry in resources orderby entry.BeginTime ascending select entry);

                    //uielement.Resources.Clear();
                    uielement.Triggers.Clear();

                    BeginStoryboard mainBeginStoryboard = GetMainBeginStoryboard(uielement, sortedDict, canvasSize);

                    mainBeginStoryboard.Storyboard.RepeatBehavior = parentStoryboard.RepeatBehavior;
                    mainBeginStoryboard.Storyboard.BeginTime = parentStoryboard.BeginTime;
                    mainBeginStoryboard.Storyboard.AccelerationRatio = parentStoryboard.AccelerationRatio;
                    mainBeginStoryboard.Storyboard.DecelerationRatio = parentStoryboard.DecelerationRatio;
                    mainBeginStoryboard.Storyboard.Duration = parentStoryboard.Duration;
                    mainBeginStoryboard.Storyboard.AutoReverse = parentStoryboard.AutoReverse;
                    mainBeginStoryboard.Storyboard.FillBehavior = parentStoryboard.FillBehavior;
                    mainBeginStoryboard.Storyboard.SlipBehavior = parentStoryboard.SlipBehavior;
                    mainBeginStoryboard.Storyboard.SpeedRatio = parentStoryboard.SpeedRatio;

                    if (!uielement.Resources.Contains("Test"))
                    {
                        uielement.Resources.Add("Test", mainBeginStoryboard);
                    }

                    mainBeginStoryboard.Storyboard.Begin(uielement, true);
                }
            }
        }


        private static BeginStoryboard GetMainBeginStoryboard(ContentControl uielement, IOrderedEnumerable<Timeline> sortedDict, Size canvasSize)
        {
            var mainBeginStoryboard = new BeginStoryboard {Storyboard = new Storyboard()};
            
            
            double startLeft = Canvas.GetLeft(uielement);
            double startTop = Canvas.GetTop(uielement);
            double originalLeft = Canvas.GetLeft(uielement);
            double originalTop = Canvas.GetTop(uielement);
            
            
            foreach (CustomStoryboard dictionaryEntry in sortedDict)
            {
                int index1 = dictionaryEntry.Name.IndexOf("_");

                string srybrdName = dictionaryEntry.Name.Remove(index1);

                TimeSpan? startTime = dictionaryEntry.BeginTime;

                var storyBoard = new CustomStoryboard(dictionaryEntry);

                switch (srybrdName)
                {
                    case "RollInFromRight":
                        {
                            if (startTime >= dictionaryEntry.BeginTime)
                                if (uielement.Visibility == Visibility.Visible)
                                    uielement.Visibility = Visibility.Collapsed;

                            startLeft = (canvasSize.Width + 20);

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();


                            var flin1 = new SplineDoubleKeyFrame(startLeft)
                            {
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                            };

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;


                            var flin2 = new EasingDoubleKeyFrame(originalLeft)
                            {
                                EasingFunction = backease,
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                            };

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);
                        }
                        break;
                    case "RollInFromLeft":
                        {
                            if (startTime >= dictionaryEntry.BeginTime)
                                if (uielement.Visibility == Visibility.Visible)
                                    uielement.Visibility = Visibility.Collapsed;

                            if (uielement.Width > 0)
                                startLeft = (uielement.Width + 20) * -1;
                            else
                                startLeft = (uielement.ActualWidth + 20) * -1;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();


                            var flin1 = new SplineDoubleKeyFrame(startLeft)
                            {
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                            };

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;


                            var flin2 = new EasingDoubleKeyFrame(originalLeft)
                            {
                                EasingFunction = backease,
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                            };

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);
                        }
                        break;
                    case "FlyInLeft":
                        {
                            if (startTime >= dictionaryEntry.BeginTime)
                                if(uielement.Visibility == Visibility.Visible)
                                    uielement.Visibility = Visibility.Collapsed;

                            if (uielement.Width > 0)
                                startLeft = (uielement.Width + 20) * -1;
                            else
                                startLeft = (uielement.ActualWidth + 20) * -1;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            EasingDoubleKeyFrame flin1 = new EasingDoubleKeyFrame(startLeft);
                            flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                            EasingDoubleKeyFrame flin2 = new EasingDoubleKeyFrame(originalLeft);
                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;
                            flin2.EasingFunction = new BackEase();

                            flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);

                           // dbA.SpeedRatio = dictionaryEntry.SpeedRatio;

                        }
                        break;
                    case "FlyInRight":
                        {
                            if (startTime >= dictionaryEntry.BeginTime)
                                if (uielement.Visibility == Visibility.Visible)
                                    uielement.Visibility = Visibility.Collapsed;

                            startLeft = (canvasSize.Width + 20);

                            var dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                          //  dbA.SpeedRatio = dictionaryEntry.SpeedRatio;

                            var flin1 = new SplineDoubleKeyFrame(startLeft)
                                                             {
                                                                 KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                                                             };

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;


                            var flin2 = new EasingDoubleKeyFrame(originalLeft)
                            {
                                EasingFunction = backease,
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                            };

                            //var flin2 = new SplineDoubleKeyFrame(originalLeft)
                            //                {
                            //                    KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                            //                };

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);

                        }
                        break;
                    case "FlyOutLeft":
                        {
                            double endpoint;

                            if (uielement.Width > 0)
                                endpoint = (originalLeft + uielement.Width + 20)*-1;
                            else
                                endpoint = (originalLeft + uielement.ActualWidth + 20)*-1;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();
                            
                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;

                          //  dbA.SpeedRatio = dictionaryEntry.SpeedRatio;

                            EasingDoubleKeyFrame flout1 = new EasingDoubleKeyFrame(originalLeft)
                                                              {
                                                                  
                                                                  KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                                                              };

                            

                            var flout2 = new EasingDoubleKeyFrame(endpoint)
                            {
                                EasingFunction = backease,
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                            };
                            
                            dbA.KeyFrames.Add(flout1);
                            dbA.KeyFrames.Add(flout2);
                        }
                        break;
                    case "FlyOutRight":
                        {
                            double endpoint = canvasSize.Width + 20;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                          //  dbA.SpeedRatio = dictionaryEntry.SpeedRatio;
                            var backease = new BackEase();
                            backease.Amplitude = 0.3;

                            var flin1 = new EasingDoubleKeyFrame(originalLeft)
                            {
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                            };

                            

                            var flin2 = new EasingDoubleKeyFrame(endpoint)
                            {
                                EasingFunction = backease,
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                            };

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);

                        }
                        break;
                    case "FlyInTop":
                        {
                            if (startTime >= dictionaryEntry.BeginTime)
                                if (uielement.Visibility == Visibility.Visible)
                                    uielement.Visibility = Visibility.Collapsed;

                            if (uielement.Height > 0)
                                startTop = (originalTop + uielement.Height + 20)*-1;
                            else
                                startTop = (originalTop + uielement.ActualHeight + 20)*-1;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            var flin1 = new EasingDoubleKeyFrame(startTop)
                            {
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                            };

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;


                            var flin2 = new EasingDoubleKeyFrame(originalTop)
                            {
                                EasingFunction = backease,
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                            };

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);

                          //  dbA.SpeedRatio = dictionaryEntry.SpeedRatio;

                        }
                        break;
                    case "FlyInBottom":
                        {
                            if (startTime >= dictionaryEntry.BeginTime)
                                if (uielement.Visibility == Visibility.Visible)
                                    uielement.Visibility = Visibility.Collapsed;

                            startTop = canvasSize.Height + 20;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                            var flin1 = new EasingDoubleKeyFrame(startTop)
                            {
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                            };

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;


                            var flin2 = new EasingDoubleKeyFrame(originalTop)
                            {
                                EasingFunction = backease,
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                            };

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);

                          //  dbA.SpeedRatio = dictionaryEntry.SpeedRatio;
                        }
                        break;
                    case "FlyOutTop":
                        {
                            double endTop;

                            if (uielement.Height > 0)
                                endTop = (originalTop + uielement.Height + 20)*-1;
                            else
                                endTop = (originalTop + uielement.ActualHeight + 20)*-1;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                          //  dbA.SpeedRatio = dictionaryEntry.SpeedRatio;

                            var flin1 = new EasingDoubleKeyFrame(originalTop)
                            {
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                            };

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;


                            var flin2 = new EasingDoubleKeyFrame(endTop)
                            {
                                EasingFunction = backease,
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                            };

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);
                        }
                        break;
                    case "FlyOutBottom":
                        {
                            double endTop = canvasSize.Height + 20;

                            DoubleAnimationUsingKeyFrames dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                            dbA.KeyFrames.Clear();

                         //   dbA.SpeedRatio = dictionaryEntry.SpeedRatio;

                            var flin1 = new EasingDoubleKeyFrame(originalTop)
                            {
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                            };

                            var backease = new BackEase();
                            backease.Amplitude = 0.3;
                            backease.EasingMode = EasingMode.EaseOut;


                            var flin2 = new EasingDoubleKeyFrame(endTop)
                            {
                                EasingFunction = backease,
                                KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                            };

                            dbA.KeyFrames.Add(flin1);
                            dbA.KeyFrames.Add(flin2);

                        }
                        break;
                    default:
                        {
                            if(dictionaryEntry.AnimationType == CustomStoryboard.AnimType.In && startTime >= dictionaryEntry.BeginTime)
                                if (uielement.Visibility == Visibility.Visible)
                                    uielement.Visibility = Visibility.Collapsed;

                        }
                        break;
                }

                mainBeginStoryboard.Storyboard.Children.Add(storyBoard);

            }
            return mainBeginStoryboard;
        }

        public static void ApplyAnimation(FrameworkElement uielement, string animationName, Size canvasSize)
        {
            if(animationName == "None") return;
            foreach (DictionaryEntry entry in Myresourcedictionary)
            {
                if(entry.Key.ToString() == animationName)
                {
                    Storyboard storyBoard = entry.Value as Storyboard;
                    if (storyBoard != null)
                    {
                        double startLeft;
                        double startTop;
                        double originalLeft = Canvas.GetLeft(uielement);
                        double originalTop = Canvas.GetTop(uielement);
                        switch (animationName)
                        {
                            case "RollInFromRight":
                                {
                                    startLeft = (canvasSize.Width + 20);

                                    DoubleAnimationUsingKeyFrames dbA =
                                        storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                                    dbA.KeyFrames.Clear();

                                    EasingDoubleKeyFrame flin1 = new EasingDoubleKeyFrame(startLeft);
                                    flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                                    EasingDoubleKeyFrame flin2 = new EasingDoubleKeyFrame(originalLeft);
                                    var backease = new BackEase();
                                    backease.Amplitude = 0.3;
                                    backease.EasingMode = EasingMode.EaseOut;
                                    flin2.EasingFunction = backease;

                                    flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                                    dbA.KeyFrames.Add(flin1);
                                    dbA.KeyFrames.Add(flin2);
                                }
                                break;
                            case "RollInFromLeft":
                                {
                                    if (uielement.Width > 0)
                                        startLeft = (uielement.Width + 20)*-1;
                                    else
                                        startLeft = (uielement.ActualWidth + 20)*-1;

                                    DoubleAnimationUsingKeyFrames dbA =
                                        storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                                    dbA.KeyFrames.Clear();

                                    EasingDoubleKeyFrame flin1 = new EasingDoubleKeyFrame(startLeft);
                                    flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                                    EasingDoubleKeyFrame flin2 = new EasingDoubleKeyFrame(originalLeft);
                                    var backease = new BackEase();
                                    backease.Amplitude = 0.3;
                                    backease.EasingMode = EasingMode.EaseOut;
                                    flin2.EasingFunction = backease;

                                    flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                                    dbA.KeyFrames.Add(flin1);
                                    dbA.KeyFrames.Add(flin2);
                                }
                                break;
                            case "FlyInLeft":
                                {
                                    if (uielement.Width > 0)
                                        startLeft = (uielement.Width + 20)*-1;
                                    else
                                        startLeft = (uielement.ActualWidth + 20)*-1;

                                    DoubleAnimationUsingKeyFrames dbA =
                                        storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                                    dbA.KeyFrames.Clear();

                                    EasingDoubleKeyFrame flin1 = new EasingDoubleKeyFrame(startLeft);
                                    flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                                    EasingDoubleKeyFrame flin2 = new EasingDoubleKeyFrame(originalLeft);
                                    var backease = new BackEase();
                                    backease.Amplitude = 0.3;
                                    backease.EasingMode = EasingMode.EaseOut;
                                    flin2.EasingFunction = new BackEase();

                                    flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                                    dbA.KeyFrames.Add(flin1);
                                    dbA.KeyFrames.Add(flin2);
                                }
                                break;
                            case "FlyInRight":
                                {
                                    startLeft = (canvasSize.Width + 20);

                                    var dbA = storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                                    dbA.KeyFrames.Clear();

                                    var flin1 = new EasingDoubleKeyFrame(startLeft)
                                                    {
                                                        KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))
                                                    };

                                    var backease = new BackEase();
                                    backease.Amplitude = 0.3;
                                    backease.EasingMode = EasingMode.EaseOut;


                                    var flin2 = new EasingDoubleKeyFrame(originalLeft)
                                                    {
                                                        EasingFunction = backease,
                                                        KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))
                                                    };

                                    dbA.KeyFrames.Add(flin1);
                                    dbA.KeyFrames.Add(flin2);
                                }
                                break;
                            case "FlyInTop":
                                {
                                    if (uielement.Height > 0)
                                        startTop = (originalTop + uielement.Height + 20)*-1;
                                    else
                                        startTop = (originalTop + uielement.ActualHeight + 20)*-1;

                                    DoubleAnimationUsingKeyFrames dbA =
                                        storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                                    dbA.KeyFrames.Clear();

                                    var flin1 = new EasingDoubleKeyFrame(startTop);
                                    flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                                    var flin2 = new EasingDoubleKeyFrame(originalTop);
                                    flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                                    var backease = new BackEase();
                                    backease.Amplitude = 0.3;
                                    backease.EasingMode = EasingMode.EaseOut;

                                    flin2.EasingFunction = backease;

                                    dbA.KeyFrames.Add(flin1);
                                    dbA.KeyFrames.Add(flin2);

                                }
                                break;
                            case "FlyInBottom":
                                {
                                    startTop = canvasSize.Height + 20;

                                    DoubleAnimationUsingKeyFrames dbA =
                                        storyBoard.Children[0] as DoubleAnimationUsingKeyFrames;

                                    dbA.KeyFrames.Clear();

                                    var flin1 = new EasingDoubleKeyFrame(startTop);
                                    flin1.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0));

                                    var flin2 = new EasingDoubleKeyFrame(originalTop);
                                    flin2.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1));

                                    var backease = new BackEase();
                                    backease.Amplitude = 0.3;
                                    backease.EasingMode = EasingMode.EaseOut;

                                    flin2.EasingFunction = backease;

                                    dbA.KeyFrames.Add(flin1);
                                    dbA.KeyFrames.Add(flin2);
                                }
                                break;
                        }


                        storyBoard.FillBehavior = FillBehavior.Stop;
                        storyBoard.Begin(uielement, true);
                    }
                }
            }
        }

        public static IDictionary GetRemainingStoryBoards(ContentControl contentControl)
        {
            IDictionary newDictionary = new ResourceDictionary();
            if (Myresourcedictionary.Count > 0)
                foreach (DictionaryEntry item in Myresourcedictionary)
                {
                    if (!contentControl.Resources.Contains(item.Key))
                        newDictionary.Add(item.Key, item.Value);
                }

            return newDictionary;
        }

        public static IDictionary GetInAnimations()
        {
            if (Myresourcedictionary != null && Myresourcedictionary.Count > 0)
            {
                var inDictionary = new ResourceDictionary();

                foreach (DictionaryEntry item in Myresourcedictionary)
                {
                    if (((CustomStoryboard)item.Value).AnimationType == CustomStoryboard.AnimType.In)
                        inDictionary.Add(item.Key, item.Value);
                }

                return inDictionary;
            }

            return null;
        }

        public static List<string> GetControlLoadingAnimations()
        {
            if (Myresourcedictionary != null && Myresourcedictionary.Count > 0)
            {
                var animationList = new List<string>();

                animationList.Add("None");

                foreach (DictionaryEntry item in Myresourcedictionary)
                {
                    if (((CustomStoryboard)item.Value).AnimationType == CustomStoryboard.AnimType.In)
                        animationList.Add(item.Key.ToString());
                }

                return animationList;
            }

            return null;
        }

        public static IDictionary GetNormalAnimations()
        {
            if (Myresourcedictionary != null && Myresourcedictionary.Count > 0)
            {
                var normalDictionary = new ResourceDictionary();

                foreach (DictionaryEntry item in Myresourcedictionary)
                {
                    if (((CustomStoryboard)item.Value).AnimationType == CustomStoryboard.AnimType.Animation)
                        normalDictionary.Add(item.Key, item.Value);
                }

                return normalDictionary;
            }
            
            return null;
        }

        public static IDictionary GetOutAnimations()
        {
            if (Myresourcedictionary != null && Myresourcedictionary.Count > 0)
            {
                var outDictionary = new ResourceDictionary();

                foreach (DictionaryEntry item in Myresourcedictionary)
                {
                    if (((CustomStoryboard)item.Value).AnimationType == CustomStoryboard.AnimType.Out)
                        outDictionary.Add(item.Key, item.Value);
                }

                return outDictionary;
            }
            
            return null;
        }

        public static ResourceDictionary GetStoryBoards()
        {
            return Myresourcedictionary;
        }

        public static IDictionary GetStoryBoards(ContentControl contentControl)
        {
            var resources = contentControl.Resources;
            return resources;
        }

        public static ResourceDictionary GetStoryBoardFromTrigger(ContentControl control)
        {
            ResourceDictionary resourceDictionary = null;

            if (control.Triggers.Count > 0)
            {
                EventTrigger eventTrigger = control.Triggers[0] as EventTrigger;
                if (eventTrigger != null)
                {
                    BeginStoryboard beginStoryboard = eventTrigger.Actions[0] as BeginStoryboard;

                    if (beginStoryboard != null)
                    {
                        Storyboard storyboard = beginStoryboard.Storyboard;

                        resourceDictionary = new ResourceDictionary();

                        resourceDictionary.Add("MainStoryboard", storyboard);
                    }
                }
            }

            return resourceDictionary;
        }

        public static ResourceDictionary CopyStoryBoardForHolder(ResourceDictionary dictionary)
        {
            var resourceDictionary = new ResourceDictionary();
            object storyboardResource = dictionary["MainStoryboard"];

            if (storyboardResource != null)
            {
                Storyboard parentStoryboard = storyboardResource as Storyboard;
                if (parentStoryboard != null)
                {
                    Storyboard sb = parentStoryboard;//.Clone();
                    resourceDictionary.Add("MainStoryboard", sb);
                }
            }
            return resourceDictionary;
        }

        public static void SaveParentStoryBordToTrigger(ContentControl control, ResourceDictionary holderResources)
        {
            object storyboardResource = holderResources["MainStoryboard"];

            if (storyboardResource != null)
            {
                Storyboard parentStoryboard = storyboardResource as Storyboard;
                if (parentStoryboard != null)
                {
                    if (control.Triggers.Count > 0)
                    {
                        EventTrigger eventTrigger = control.Triggers[0] as EventTrigger;
                        if (eventTrigger != null)
                        {
                            BeginStoryboard beginStoryboard = eventTrigger.Actions[0] as BeginStoryboard;

                            if (beginStoryboard != null)
                            {
                                beginStoryboard.Storyboard.AccelerationRatio = parentStoryboard.AccelerationRatio;
                                beginStoryboard.Storyboard.BeginTime = parentStoryboard.BeginTime;
                                beginStoryboard.Storyboard.AutoReverse = parentStoryboard.AutoReverse;
                                beginStoryboard.Storyboard.DecelerationRatio = parentStoryboard.DecelerationRatio;
                                beginStoryboard.Storyboard.Duration = parentStoryboard.Duration;
                                beginStoryboard.Storyboard.FillBehavior = parentStoryboard.FillBehavior;
                                beginStoryboard.Storyboard.RepeatBehavior = parentStoryboard.RepeatBehavior;
                                beginStoryboard.Storyboard.SlipBehavior = parentStoryboard.SlipBehavior;
                                beginStoryboard.Storyboard.SpeedRatio = parentStoryboard.SpeedRatio;
                            }
                        }
                    }
                }
            }
        }
    }
}
