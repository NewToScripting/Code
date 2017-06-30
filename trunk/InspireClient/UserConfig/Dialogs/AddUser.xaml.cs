using System;
using System.Collections.Generic;
using System.Windows;
using Inspire;
using Inspire.Common.Dialogs;
using Inspire.Server.Proxy;

namespace UserConfig.Dialogs
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser
    {
        public User NewUser { get; set; }

        public bool IsNewUser { get; set; }

        private string _oldPassword;

        public AddUser()
        {
            InitializeComponent();
            
            NewUser = null;

            IsNewUser = true;
        }

        public AddUser(User user)
        {
            InitializeComponent();

            Title = InspireApp.ResourceManager.GetString("EditUserTitle");

            NewUser = user;
            _oldPassword = user.Password;
            NewUser.Password = string.Empty;
            tbUserName.Text = user.Name;
            tbUserLogin.Text = user.Login;
            tbUserDescription.Text = user.Description;

            lblOldPass.Visibility = Visibility.Visible;
            pbOldPassword.Visibility = Visibility.Visible;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void AddUserExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            User user = new User();
            user.GUID = Guid.NewGuid().ToString();
            user.Login = tbUserLogin.Text; 

            if(!IsNewUser && _oldPassword != pbOldPassword.Password)
            {
                CommonDialog commonDialog = new CommonDialog(InspireApp.ResourceManager.GetString("PasswordDialogTitle"), InspireApp.ResourceManager.GetString("PasswordDialogInvalid"));
                commonDialog.ShowDialog();
                return;
            }

            if (tbUserPassword.Password == pbConfirm.Password)
                user.Password = tbUserPassword.Password;
            else
            {
                CommonDialog commonDialog = new CommonDialog(InspireApp.ResourceManager.GetString("PasswordDialogTitle"), InspireApp.ResourceManager.GetString("PasswordDialogDescription"));
                commonDialog.ShowDialog();
                return;
            }

            user.Name = tbUserName.Text;
            user.Description = tbUserDescription.Text;
            user.Roles = new List<Role>();
            
            try
            {
                if (IsNewUser)
                    UserManager.AddUser(user);
                else
                {
                    UserManager.DeleteUser(user.GUID);
                    UserManager.AddUser(user);
                }
                NewUser = user;
                DialogResult = true;
                Close();
            }
            catch (Exception)
            {
                    // TODO: Handle Exception
                throw;
            }
        }

        private void AddUserCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator) && !String.IsNullOrEmpty(tbUserLogin.Text.Trim()) && !String.IsNullOrEmpty(tbUserPassword.Password.Trim()) && !String.IsNullOrEmpty(pbConfirm.Password.Trim()));
        }

        private void CancelExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void CancelCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
