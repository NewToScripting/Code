using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using Inspire.Commands;
using Inspire.Server.Proxy;
using Inspire.Services.WeakEventHandlers;
using Inspire.Common.Dialogs;

namespace Inspire.Client
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : IWeakEventListener
    {
        public Login()
        {
            InitializeComponent();

            OnInit();

            InspireCommands.AdminLoginCommand.InputGestures.Add(new KeyGesture(Key.Home, ModifierKeys.Control));
            LoadedEventManager.AddListener(this, this);

            SingleInstance.Make("InspireClient", this);

        }

        // This function does all the work
        [DllImport("Trial.dll", EntryPoint = "ReadSettingsStr", CharSet = CharSet.Ansi)]
        static extern uint InitTrial(String aKeyCode, IntPtr aHWnd);

        // Use this function to register the application when the application is running
        [DllImport("Trial.dll", EntryPoint = "DisplayRegistrationStr", CharSet = CharSet.Ansi)]
        static extern uint DisplayRegistration(String aKeyCode, IntPtr aHWnd);

        // The kLibraryKey is meant to prevent unauthorized use of the library.
        // Do not share this key. Replace this key with your own from Advanced Installer 
        // project > Licensing > Registration > Library Key
        private const string kLibraryKey = "26E6B010ABB83B7B5319742E4F1B3F06C057554FB24A45E21885A8E84AB359F621BCFDC0AC02";

        private void OnInit()
        {
            try
            {
                InitTrial(kLibraryKey, new WindowInteropHelper(this).Handle);
            }
            catch (DllNotFoundException ex)
            {
                // Trial dll is missing close the application immediately.
                MessageBox.Show("The Trial License is not found. Please reinstall the application.");
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        //private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Process process = Process.GetCurrentProcess();
        //        DisplayRegistration(kLibraryKey, process.MainWindowHandle);
        //    }
        //    catch (DllNotFoundException ex)
        //    {
        //        // Trial dll is missing close the application immediately.
        //        MessageBox.Show(ex.ToString());
        //        this.Close();
        //    }
        //    catch (Exception ex1)
        //    {
        //        MessageBox.Show(ex1.ToString());
        //    }
        //}

        void Login_Loaded(object sender, EventArgs e)
        {
            int failCount = 0;
            bool communication = false;
            bool goDesign = false;

            List<User> users;
            do
            {
                try
                {
                    //if (!FileAssociation.IsAssociated(".insp"))
                        //FileAssociation.Associate(".insp", "InspireClient", "insp File", "AllIcons.ico", "Inspire.Client.exe");

                    users = UserManager.GetUsers();

                    ServerSettings.SetDemoMode();

                    if (users.Count > 0)
                    {
                        cbUser.ItemsSource = users;
                        communication = true;
                    }
                    else
                        goDesign = true;
                }
                catch (Exception)
                {
                    var textPrompt = new TextPrompt("Server Not Found", "Server Not Found. Please enter the name of the server you would like to connect to:", ServerSettings.ConfigServer, "Server Name/IP:", "Enter the Server or IP Address");
                    textPrompt.ShowDialog();
                    if (textPrompt.DialogResult == true)
                    {
                        ServerSettings.SetConfigServer(textPrompt.Text);
                    }
                    else
                        goDesign = true;
                    failCount++;
                }
                
            } 
            while (!communication && failCount < 3 && !goDesign);
           
            if(failCount > 2 || goDesign)
            {
                Visibility = Visibility.Collapsed;
                DesignerLogin commonDialog = new DesignerLogin();
                commonDialog.LoginButton.Content = "Design";
                commonDialog.ShowDialog();
                if(commonDialog.DialogResult == true)
                {
                    BackgroundWorker backgroundWorker = new BackgroundWorker();

                    backgroundWorker.DoWork += backgroundWorker_DoWork;

                    backgroundWorker.RunWorkerAsync();

                    MainWindow mainWindow = new MainWindow(true);
                    Close();
                    mainWindow.Show();
                }
                else
                {
                    Close();
                }
           }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (cbUser.SelectedItem != null)
            {
                Cursor = Cursors.Wait;
                User user = (User)cbUser.SelectedItem;

                user.Password = txtPassword.Password; //TODO: Store Encrypted password
                if (UserManager.AuthenticateUser(user))
                {

                    BackgroundWorker backgroundWorker = new BackgroundWorker();

                    backgroundWorker.DoWork += backgroundWorker_DoWork;

                    backgroundWorker.RunWorkerAsync();

                    MainWindow mainWindow = new MainWindow(cbUser.Text, user.GUID, user.Roles);
                    Close();
                    mainWindow.Show();
                }
                else
                {
                    Cursor = Cursors.Arrow;
                    CommonDialog commonDialog = new CommonDialog("Invalid Password.", "Invalid Passsord for user " + user.Name + ". Please enter a valid password.");
                    commonDialog.ShowDialog();
                }               
            }
            e.Handled = true;
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Files.ClearDirectory(Paths.ClientTempDirectory);

            Files.ClearDirectory(Paths.SaveDirectory);

            SlideCollection.CleanRemovedOfflineSlides();

            Paths.CreateDirectories();

        }

        private void AdminLoginExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Role role = new Role();
            role.GUID = Guid.NewGuid().ToString();
            role.Name = "Administrator";
            List<Role> roles = new List<Role>();
            roles.Add(role);

            BackgroundWorker backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += backgroundWorker_DoWork;

            backgroundWorker.RunWorkerAsync();

            MainWindow mainWindow = new MainWindow(cbUser.Text, string.Empty, roles);
            mainWindow.Show();
            Close();
            e.Handled = true;
        }

        private void AdminLoginCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                Login_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        
    }

}
