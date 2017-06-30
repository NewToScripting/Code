using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using EventsModule.Dialogs;
using Inspire;
using Inspire.Common.Utility;
using Inspire.Events.Proxy;
using Inspire.Services.WeakEventHandlers;
using Microsoft.Win32;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog1 : IWeakEventListener
    {
        public ModuleDialog1()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);
            
        }

        public FeedContentControl EventControlHolder { get; set; }

        private ObservableCollection<FeedTemplate> RoomTemplates;
        private ObservableCollection<FeedTemplate> DirectoryTemplates;

        void ModuleDialog_Loaded(object sender, EventArgs e)
        {
            try
            {
                
                RoomTemplates = new ObservableCollection<FeedTemplate>();

                
                DirectoryTemplates = new ObservableCollection<FeedTemplate>();

                lbDirectoryTemplates.ItemsSource = DirectoryTemplates;
                lbRoomTemplates.ItemsSource = RoomTemplates;

                List<FeedTemplate> feedTemplates = Inspire.Events.Proxy.FeedTemplateProxy.GetTemplates();

                foreach (var template in feedTemplates)
                {
                    if(template.Type == "Directory")
                        DirectoryTemplates.Add(template);
                    if (template.Type == "Room")
                        RoomTemplates.Add(template);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTemplateBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Xaml Templates (*.xaml) |*.xaml";
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                tbTemplateUri.Text = openFileDialog1.FileName;

            e.Handled = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Multiselect = true;
            openFileDialog2.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog2.FileName))
                foreach (string fileName in openFileDialog2.FileNames)
                {
                    lbTemplateFiles.Items.Add(fileName);
                }
            e.Handled = true;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if(lbTemplateFiles.SelectedItem != null)
                lbTemplateFiles.Items.Remove(lbTemplateFiles.SelectedItem);
            e.Handled = true;
        }

        private void btnThumbnailBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog3 = new OpenFileDialog();
            openFileDialog3.Multiselect = false;
            openFileDialog3.Filter = "Images (*.jpg, *.png, *.gif, *.bmp, *.jpeg) |*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog3.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog3.FileName))
            {
                BitmapFrame bitmapFrame = BitmapFrame.Create(new Uri(openFileDialog3.FileName, UriKind.RelativeOrAbsolute));
                imgThumbnail.Source = bitmapFrame;
            }
            e.Handled = true;
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbTemplateName.Text) && !string.IsNullOrEmpty(tbTemplateDescription.Text) && imgThumbnail.Source != null && !string.IsNullOrEmpty(tbTemplateUri.Text))
            {
                FeedTemplate feedTemplate = new FeedTemplate();
                feedTemplate.Description = tbTemplateDescription.Text;
                feedTemplate.Name = tbTemplateName.Text;
                feedTemplate.Rows = Convert.ToInt32(cbTemplateRows.Text);
                feedTemplate.Guid = Guid.NewGuid().ToString();

                Files.ClearDirectory(Paths.ClientTemplateTempDirectory);
                Files.ClearDirectory(Paths.ClientTransferDirectory);

                if (File.Exists(tbTemplateUri.Text))
                    File.Copy(tbTemplateUri.Text, Paths.ClientTemplateTempDirectory + feedTemplate.Guid + ".xaml");
                //else
                   // TODO: Validation

                foreach (var file in lbTemplateFiles.Items)
                {
                    if(File.Exists(file.ToString()))
                        File.Copy(Path.GetFullPath(file.ToString()), Paths.ClientTemplateTempDirectory + Path.GetFileName(file.ToString()),true);
                }

                int fields = 0;
                if (cbNameField1.IsChecked == true)
                    fields = fields + 1;
                if (cbNameField2.IsChecked == true)
                    fields = fields + 2;
                if (cbNameField3.IsChecked == true)
                    fields = fields + 4;
                if (cbNameField4.IsChecked == true)
                    fields = fields + 8;
                if (cbDescField1.IsChecked == true)
                    fields = fields + 16;
                if (cbDescField2.IsChecked == true)
                    fields = fields + 32;
                if (cbDescField3.IsChecked == true)
                    fields = fields + 64;
                if (cbDescField4.IsChecked == true)
                    fields = fields + 128;
                if (cbIntField1.IsChecked == true)
                    fields = fields + 256;
                if (cbIntField2.IsChecked == true)
                    fields = fields + 512;
                if (cbDecimalField1.IsChecked == true)
                    fields = fields + 1024;
                if (cbDecimalField2.IsChecked == true)
                    fields = fields + 2048;
                if (cbDateField1.IsChecked == true)
                    fields = fields + 4096;
                if (cbDateField2.IsChecked == true)
                    fields = fields + 8192;
                if (cbDateField3.IsChecked == true)
                    fields = fields + 16384;
                if (cbDateField4.IsChecked == true)
                    fields = fields + 32768;
                feedTemplate.Fields = (FeedTemplate.FieldsEnum) fields;

                ZipUtil.NewZipFiles(Paths.ClientTemplateTempDirectory, Paths.ClientTransferDirectory + feedTemplate.Guid + ".inst", "wookie");

                feedTemplate.File = File.ReadAllBytes(Paths.ClientTransferDirectory + feedTemplate.Guid + ".inst");

                feedTemplate.Thumb_Nail = (byte[])ImageToByteConverter.Convert(imgThumbnail);

                feedTemplate.Type = cbTemplateType.Text;

                Inspire.Events.Proxy.FeedTemplateProxy.AddTemplate(feedTemplate);

                ClearTemplateForm();
            }
            e.Handled = true;
        }

        private void ClearTemplateForm()
        {
            tbTemplateName.Text = "";
            tbTemplateDescription.Text = "";
            imgThumbnail = null;
            tbTemplateUri.Text = "";
            lbTemplateFiles.Items.Clear();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearTemplateForm();
            e.Handled = true;
        }

        private void expTemplate_Expanded(object sender, RoutedEventArgs e)
        {
            expTemplate.Width = Width;
            expTemplate.Height = Height - 21;
            expTemplate.Margin = new Thickness(0,0,0,0);
            e.Handled = true;
        }

        private void expTemplate_Collapsed(object sender, RoutedEventArgs e)
        {
            expTemplate.Width = 126;
            expTemplate.Height = 35;
            e.Handled = true;
        }

        private void btnInsertDirectoryTemplate_Click(object sender, RoutedEventArgs e)
        {
            if (lbDirectoryTemplates.SelectedItem != null)
            {
                ConfigureEvents configureEvents = new ConfigureEvents(((FeedTemplate)lbDirectoryTemplates.SelectedItem).Guid);
                configureEvents.ShowDialog();
                if(configureEvents.DialogResult == true)
                {
                    EventControlHolder = configureEvents.EvntControl;
                    DialogResult = true;
                    Close();
                }
            }
            e.Handled = true;
        }

        private void btnInsertRoomTemplate_Click(object sender, RoutedEventArgs e)
        {
            if (lbRoomTemplates.SelectedItem != null)
            {
                ConfigureEvents configureEvents = new ConfigureEvents(((FeedTemplate)lbRoomTemplates.SelectedItem).Guid);
                configureEvents.ShowDialog();
                if (configureEvents.DialogResult == true)
                {
                    EventControlHolder = configureEvents.EvntControl;
                    DialogResult = true;
                    Close();
                }
            }
            e.Handled = true;
        }

        private void DeleteTemplate(object sender, RoutedEventArgs e)
        {
            MenuItem mItem = (MenuItem)sender;
            ContextMenu cMenu = (ContextMenu)mItem.Parent;
            FeedTemplate feedTemplate = (FeedTemplate)cMenu.DataContext;
            FeedTemplateProxy.DeleteTemplate(feedTemplate.Guid);
            if(feedTemplate.Type == "Directory")
                DirectoryTemplates.Remove(feedTemplate);
            if (feedTemplate.Type == "Room")
                RoomTemplates.Remove(feedTemplate);
            e.Handled = true;
        }

        private void btnTemplateCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnRoomTemplateCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ModuleDialog_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
