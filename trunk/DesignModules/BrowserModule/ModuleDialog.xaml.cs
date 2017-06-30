
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using Timer=System.Timers.Timer;

namespace BrowserModule
{
    /// <summary>
    /// Interaction logic for ModuleDialog.xaml
    /// </summary>
    public partial class ModuleDialog
    {
        public bool ShowScrollBars { get; private set; }

        public string Url { get; private set; }

        public int RefreshInterval { get; private set; }

        public ModuleDialog()
        {
            InitializeComponent();

            tbUrl.Focus();

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Url = tbUrl.Text;
            RefreshInterval = Convert.ToInt32(tbRefresh.Text); // TODO: Check for valid number

            if (rbShowScrollBars.IsChecked == true)
                ShowScrollBars = true;

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Show_Checked(object sender, RoutedEventArgs e)
        {
            //if (FormBrowser.Document != null)
            //{
            //    GetScrollBars();
            //    FormBrowser.ScrollBarsEnabled = true;
            //    timer.Enabled = true;
            //}
        }

        private void Hide_Checked(object sender, RoutedEventArgs e)
        {
            //if (FormBrowser.Document != null)
            //{
            //    GetScrollBars();
            //    FormBrowser.ScrollBarsEnabled = false;
            //    timer.Enabled = true;
            //}
        }

        private void GetScrollBars()
        {
            //if (FormBrowser.Document != null)
            //{
            //    if (FormBrowser.Document.Body.Parent.ScrollLeft > 0 ||
            //        FormBrowser.Document.Body.Parent.ScrollTop > 0)
            //    {
            //        LeftScroll = FormBrowser.Document.Body.Parent.ScrollLeft;
            //        TopScroll = FormBrowser.Document.Body.Parent.ScrollTop;
            //        parent = true;
            //    }

            //    if (FormBrowser.Document.Body.ScrollLeft > 0 ||
            //        FormBrowser.Document.Body.ScrollTop > 0)
            //    {
            //        LeftScroll = FormBrowser.Document.Body.ScrollLeft;
            //        TopScroll = FormBrowser.Document.Body.ScrollTop;
            //        parent = false;
            //    }
            //}
        }

        private void SetScrollBars()
        {
            //if (FormBrowser.Document != null)
            //{
            //    FormBrowser.Document.Window.ScrollTo(LeftScroll, TopScroll);
            //}
        }
    }
}
