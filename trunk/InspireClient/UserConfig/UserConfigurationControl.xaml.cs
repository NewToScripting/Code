using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Inspire;
using Inspire.Common.Dialogs;
using Inspire.Server.Proxy;
using Inspire.Services.WeakEventHandlers;
using UserConfig.Dialogs;

namespace UserConfig
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserConfigurationControl : IWeakEventListener
    {
        private ObservableCollection<User> users;

        private ObservableCollection<Role> userRoles;

        public UserConfigurationControl()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);
        }

        void ConfigurationControl_Loaded(object sender, EventArgs e)
        {
            users = new ObservableCollection<User>();

            userRoles = new ObservableCollection<Role>();

            List<User> lUsers = UserManager.GetUsers();

            if (lUsers != null)
            {

                foreach (var user in lUsers)
                {
                    users.Add(user);
                }

                lbUsers.ItemsSource = users;

                lbRoles.ItemsSource = userRoles;
            }
        }

        private void lbUsers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                userRoles.Clear();
                if (((User)lbUsers.SelectedItem).Roles != null)
                    foreach (var role in ((User)lbUsers.SelectedItem).Roles)
                    {
                        userRoles.Add(role);
                    }
            }
        }

        private void RemoveRoleExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (lbRoles.SelectedItem != null)
            {
                Role role = (Role)lbRoles.SelectedItem;
                User user = (User)lbUsers.SelectedItem;
                UserManager.DeleteRole(user.GUID, role.GUID);
                userRoles.Remove(role);
                user.Roles.Remove(role);
            }
        }

        private void RemoveRoleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator) && lbRoles.SelectedItem != null)
                e.CanExecute = true;
        }

        private void AddRoleFormExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                AddRole addRole = new AddRole(((User) lbUsers.SelectedItem).Roles);
                addRole.ShowDialog();
                if (addRole.DialogResult == true)
                {
                    if(addRole.SelectedRole != null)
                    if (((User)lbUsers.SelectedItem).Roles != null)
                    {
                        if (addRole.SelectedRole != null)
                        {
                            UserManager.AddRolesToUser(((User)lbUsers.SelectedItem).GUID, addRole.SelectedRole.GUID);
                            ((User)lbUsers.SelectedItem).Roles.Add(addRole.SelectedRole);
                            userRoles.Add(addRole.SelectedRole);
                        }
                    }
                    else
                    {
                        ((User)lbUsers.SelectedItem).Roles = new List<Role>();
                        if (addRole.SelectedRole != null)
                        {
                            UserManager.AddRolesToUser(((User)lbUsers.SelectedItem).GUID, addRole.SelectedRole.GUID);
                            ((User)lbUsers.SelectedItem).Roles.Add(addRole.SelectedRole);
                            userRoles.Add(addRole.SelectedRole);
                        }
                    }
                }
            }
            e.Handled = true;
        }

        private void AddRoleFormCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(User.UserPermision.Contains(PermissionTypes.Administrator) && lbUsers.SelectedItem != null)
                e.CanExecute = true;
        }

        private void DeleteUserExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                CommonDialog commonDialog = new CommonDialog("Delete User?","Are you sure you like to delete the user?");
                    commonDialog.ShowDialog();
                    if (commonDialog.DialogResult == true)
                    {
                        User user = (User) lbUsers.SelectedItem;
                        UserManager.DeleteUser(user.GUID);
                        users.Remove(user);
                        userRoles.Clear();
                    }
            }
        }

        private void DeleteUserCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator) && lbUsers.SelectedItem != null)
                    e.CanExecute = true;
        }

        private void AddUserFormCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (User.UserPermision.Contains(PermissionTypes.Administrator))
                e.CanExecute = true;
        }

        private void AddUserFormExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
            if(addUser.DialogResult == true)
            {
                if(addUser.NewUser != null)
                    users.Add(addUser.NewUser);
            }
            e.Handled = true;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                ConfigurationControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        private void EditUserExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                var user = lbUsers.SelectedItem as User;
                AddUser addUser = new AddUser(user);
                addUser.ShowDialog();
                if (addUser.DialogResult == true)
                {
                    if (addUser.NewUser != null)
                    {
                        user.Name = addUser.NewUser.Name;
                        user.Password = addUser.NewUser.Password;
                        user.Login = addUser.NewUser.Login;
                        user.Description = addUser.NewUser.Description;
                        user.Roles = addUser.NewUser.Roles;
                    }
                }
            }
            e.Handled = true;
        }

        private void EditUserCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((User.UserPermision.Contains(PermissionTypes.Administrator) && lbUsers.SelectedItem != null) || (lbUsers.SelectedItem != null && ((User)lbUsers.SelectedItem).GUID == User.UserGuid))
                e.CanExecute = true;
        }
    }
}
