using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire;
using Microsoft.Win32;
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
            cbTransition.ItemsSource = Transitions.TransitionList.Values;
            cbTransition.SelectedIndex = 9;
        }

        public PlaylistFileSelecter(string fileName)
        {
            InitializeComponent();
            tbFileName.Text = fileName;
            cbTransition.ItemsSource = Transitions.TransitionList.Values;
            cbTransition.SelectedIndex = 9;

            if (File.Exists(fileName))
            {
                string extention = Path.GetExtension(fileName);
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
                string extention = Path.GetExtension(tbFileName.Text);
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
                Element.Transition = Transitions.SetTransition(cbTransition.Text);

                DialogResult = true;
                Close();
            }
            else
            {
               Inspire.Common.Dialogs.CommonDialog commonDialog = new CommonDialog("Invalid File", "The file cannot be located.");
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
