using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Inspire.Client.Dialogs;
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
            InspireCommands.AdminLoginCommand.InputGestures.Add(new KeyGesture(Key.Home, ModifierKeys.Control));
            LoadedEventManager.AddListener(this, this);

           // SingleInstance.Make("InspireClient", this);

        }

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

                AuthResult auth = UserManager.AuthenticateUser(user);

                if (auth.UserAuthorized)
                {
                    if (auth.TrialVersion)
                    {
                        var registration = new Registration(new RegistrationRequest());
                        registration.ShowDialog();
                        if (registration.DialogResult == true)
                        {
                            CommonDialog commonDialog2 = new CommonDialog("Software Registered", "Thank you for registering your software.", true);
                            commonDialog2.ShowDialog();
                            LaunchApp(user);
                        }
                        else
                        {
                            if (auth.RegDate > DateTime.Now)
                                LaunchApp(user);
                            else
                            {
                                CommonDialog commonDialog2 = new CommonDialog("Trial Version Expired", "Your trial version has expired. Please register the software to continue.", true);
                                commonDialog2.ShowDialog();
                                e.Handled = true;
                                Close();
                                return;
                            }

                            CommonDialog commonDialog = new CommonDialog("Not Registered", "Your software is not registered. You may continue to use the unregistered software until your trial expires. Please register the software to unlock the trial version.", true);
                            commonDialog.ShowDialog();
                        }
                    }
                    else
                        LaunchApp(user);
                }
                else
                {
                    Cursor = Cursors.Arrow;
                    CommonDialog commonDialog = new CommonDialog("Invalid Password.", "Invalid Passsord for user " + user.Name + ". Please enter a valid password.", true);
                    commonDialog.ShowDialog();
                }               
            }
            Cursor = Cursors.Arrow;
            e.Handled = true;
        }

        private void LaunchApp(User user)
        {
            this.Cursor = Cursors.Wait;
            BackgroundWorker backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += backgroundWorker_DoWork;

            backgroundWorker.RunWorkerAsync();

            MainWindow mainWindow = new MainWindow(cbUser.Text, user.GUID, user.Roles);
            Close();
            mainWindow.Show();
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

            LaunchApp(new User() { Roles = roles });
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
