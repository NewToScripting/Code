using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Inspire.AnimationLibrary
{
    /// <summary>
    /// Interaction logic for AnimationSelector.xaml
    /// </summary>
    public partial class AnimationSelector
    {
        public CustomStoryboard SelectedAnimation { get; set; }

        public string SelectedName { get; set; }
        
        private FillBehavior _fillBehavior;

        private RepeatBehavior _repeatBehavior;

        private readonly ContentControl _contentControl;

        public AnimationSelector(ContentControl contentControl)
        {
            InitializeComponent();
            _contentControl = contentControl;

            lbInAnimations.ItemsSource = AnimationManager.GetInAnimations();
            lbAnimations.ItemsSource = AnimationManager.GetNormalAnimations();
            lbOutAnimations.ItemsSource = AnimationManager.GetOutAnimations();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedAnimation = new CustomStoryboard(((CustomStoryboard)(((DictionaryEntry)((FrameworkElement)sender).DataContext).Value)));

            if (_contentControl != null)
            {
                var storyBoard = ((CustomStoryboard)(((DictionaryEntry)((FrameworkElement)sender).DataContext).Value));
                SelectedName = ((DictionaryEntry) ((FrameworkElement) sender).DataContext).Key.ToString();
                storyBoard = AnimationManager.GetPreviewStoryboard(storyBoard, _contentControl, ((DictionaryEntry)((FrameworkElement)sender).DataContext).Key.ToString());
                _repeatBehavior = storyBoard.RepeatBehavior;
                _fillBehavior = storyBoard.FillBehavior;
                storyBoard.RepeatBehavior = new RepeatBehavior(1);
                //storyBoard.Completed += new EventHandler(storyBoard_Completed);

                //string controlXaml = XamlWriter.Save(_contentControl);

                //StringReader stringReader = new StringReader(controlXaml);
                //XmlReader xmlReader = XmlReader.Create(stringReader);
                //_newContentControl = (ContentControl)XamlReader.Load(xmlReader);
                storyBoard.FillBehavior = FillBehavior.Stop;
                storyBoard.Begin(_contentControl, true);
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAnimation != null)
            {
                if (SelectedAnimation.FillBehavior == null)
                    SelectedAnimation.FillBehavior = FillBehavior.HoldEnd;
                else
                    SelectedAnimation.FillBehavior = _fillBehavior;
                SelectedAnimation.RepeatBehavior = _repeatBehavior;
                string guid = Guid.NewGuid().ToString().Substring(0, 4);
                SelectedAnimation.Name = SelectedName + "_" + guid;
            }
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
