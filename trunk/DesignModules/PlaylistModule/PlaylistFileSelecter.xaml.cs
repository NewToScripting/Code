using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using Transitionals;
using Transitionals.Transitions;
using CommonDialog=Inspire.Common.Dialogs.CommonDialog;


namespace PlaylistModule
{
    /// <summary>
    /// Interaction logic for PlaylistFileSelecter.xaml
    /// </summary>
    public partial class PlaylistFileSelecter
    {
        public PlaylistElement Element { get; set; }

        public PlaylistFileSelecter()
        {
            InitializeComponent();
            dtiDuration.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0,0,06);
            Element = new PlaylistElement();
            cbTransition.ItemsSource = TransitionService.TransitionList;
            cbTransition.SelectedIndex = 9;
        }

        public PlaylistFileSelecter(string fileName)
        {
            InitializeComponent();
            tbFileName.Text = fileName;
            cbTransition.ItemsSource = TransitionService.TransitionList;
            cbTransition.SelectedIndex = 9;

            if (File.Exists(fileName))
            {
                string extention = Path.GetExtension(fileName).Trim().ToLower();
                List<string> movieExtensions = new List<string>(Movie.Extensions);

                if (movieExtensions.Contains(extention))
                {
                    MediaElement mediaElement = new MediaElement();
                    mediaElement.Source = new Uri(fileName, UriKind.RelativeOrAbsolute);
                    if (mediaElement.NaturalDuration.HasTimeSpan)
                        dtiDuration.Value = new DateTime(DateTime.Now.Year,
                                                         DateTime.Now.Month,
                                                         DateTime.Now.Day,
                                                         mediaElement.
                                                             NaturalDuration.
                                                             TimeSpan.Hours,
                                                         mediaElement.
                                                             NaturalDuration.
                                                             TimeSpan.Minutes,
                                                         mediaElement.
                                                             NaturalDuration.
                                                             TimeSpan.Seconds);
                    else
                    {
                        dtiDuration.Value = new DateTime(DateTime.Now.Year,
                                                         DateTime.Now.Month,
                                                         DateTime.Now.Day, 0, 0, 15);
                    }
                }
                
                else
                {
                    dtiDuration.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 06);
                }
                Element = new PlaylistElement();
            }
        }

        public PlaylistFileSelecter(PlaylistElement element, string empty)
        {
            InitializeComponent();

            cbTransition.ItemsSource = TransitionService.TransitionList;

            Element = new PlaylistElement();

            if (element.MediaElement is Movie)
            {
                tbFileName.Text = ((Movie) element.MediaElement).Uri;
                cbStretch.Text = ((Movie)element.MediaElement).Stretch.ToString();
                cbTransition.SelectedValue = TransitionService.GetTransitionName(element.Transition);
                dtiDuration.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, element.Duration.TimeSpan.Hours, element.Duration.TimeSpan.Minutes, element.Duration.TimeSpan.Seconds);
            }
            if(element.MediaElement is Picture)
            {
                tbFileName.Text = ((Picture)element.MediaElement).Uri;
                cbStretch.Text = ((Picture)element.MediaElement).Stretch.ToString();
                cbTransition.SelectedValue = TransitionService.GetTransitionName(element.Transition);
                dtiDuration.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, element.Duration.TimeSpan.Hours, element.Duration.TimeSpan.Minutes, element.Duration.TimeSpan.Seconds);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;
            if (!String.IsNullOrEmpty(fileName))
            {
                tbFileName.Text = fileName;
            }
            e.Handled = true;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(tbFileName.Text))
            {
                string extention = Path.GetExtension(tbFileName.Text).Trim().ToLower();
                List<string> pictureExtensions = new List<string>(Picture.Extensions);
                List<string> movieExtensions = new List<string>(Movie.Extensions);

                if (pictureExtensions.Contains(extention))
                {
                    
                   Element.MediaElement = new Picture(tbFileName.Text, GetStretch(cbStretch.Text));
                }
                else if (movieExtensions.Contains(extention))
                {
                    Element.MediaElement = new Movie(tbFileName.Text, GetStretch(cbStretch.Text));                    
                }
                else
                {
                    Element = null;
                    Close();
                    return;
                }

                Element.Duration =
                    new Duration(new TimeSpan(dtiDuration.Value.Value.Hour, dtiDuration.Value.Value.Minute,
                                              dtiDuration.Value.Value.Second));
                Element.Transition = TransitionService.SetTransition(cbTransition.Text);

                if (Element.Transition is IFullDurationTransition)
                {
                    //Element.Transition.Duration = Element.Duration;
                    Element.Duration = new Duration(TimeSpan.FromSeconds(.01));
                }

                DialogResult = true;

                Close();
            }
            else
            {
                CommonDialog commonDialog = new CommonDialog("Invalid File", "The file cannot be located.");
                commonDialog.ShowDialog();
            }
        }

        private static Stretch GetStretch(string stretch)
        {
            switch (stretch)
            {
                case "Uniform":
                    return Stretch.Uniform;
                case "Fill":
                    return Stretch.Fill;
                case "None":
                    return Stretch.None;
                case "UniformToFill":
                    return Stretch.UniformToFill;
                default:
                    return Stretch.None;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
