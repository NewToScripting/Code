using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using Transitionals;

namespace PlaylistModule
{
    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog
    {
        public enum FileType
        {
            Video,
            Image,
            NotSupported
        }

        public ModuleDialog()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PlaylistFileSelecter playlistFileSelecter = new PlaylistFileSelecter();
            playlistFileSelecter.ShowDialog();
            if(playlistFileSelecter.DialogResult == true)
            {
                if(playlistFileSelecter.Element != null)
                    plControl.Add(playlistFileSelecter.Element); 
            }
            e.Handled = true;
        }

        private void plControl_Drop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

            if (fileNames != null)
                foreach(string fileName in fileNames)
                {
                    PlaylistFileSelecter playlistFileSelecter = new PlaylistFileSelecter(fileName);
                    playlistFileSelecter.ShowDialog();
                    if (playlistFileSelecter.DialogResult == true)
                    {
                        if (playlistFileSelecter.Element != null)
                            plControl.Add(playlistFileSelecter.Element);
                    }
                }
        }

        private void plControl_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            string[] fileNames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

            if (fileNames != null)
                foreach (string fileName in fileNames)
                {
                    FileType type = GetFileType(fileName);

                    if (type == FileType.Image)
                        e.Effects = DragDropEffects.Copy;
                    if (type == FileType.Video)
                        e.Effects = DragDropEffects.Copy;
                }

            // Mark the event as handled, so control's native DragOver handler is not called.
            e.Handled = true;
        }

        /// <summary>Returns the FileType </summary>
        /// <param name="fileName">Path of a file.</param>
        public FileType GetFileType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();

            List<string> pictureExtensions = new List<string>(Picture.Extensions);
            List<string> movieExtensions = new List<string>(Movie.Extensions);

            if (pictureExtensions.Contains(extension))
                return FileType.Image;


            if (movieExtensions.Contains(extension))
                return FileType.Video;

            return FileType.NotSupported;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if(lbMedia.SelectedItem != null)
                plControl.RemoveAt(lbMedia.SelectedIndex);
        }
    }

    public class FileNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = (string)value;
            return Path.GetFileNameWithoutExtension(s);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class TransitionNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Transition transition = (Transition)value;
            return " " + (transition.GetType().Name).Replace("Transition", "");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
