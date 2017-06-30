using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Inspire;
using Inspire.Server.Proxy;
using Inspire.Services.WeakEventHandlers;

namespace UserConfig.Dialogs
{
    /// <summary>
    /// Interaction logic for AddRole.xaml
    /// </summary>
    public partial class AddRole : IWeakEventListener
    {
        private List<Role> roles;
        private List<Role> userRoles;
        public Role SelectedRole { get; set; }

        public AddRole(List<Role> _userRoles)
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);
            userRoles = _userRoles;
        }

        void AddRole_Loaded(object sender, EventArgs e)
        {
            roles = UserManager.GetAllRoles();

            List<Role> newRoles = new List<Role>();
            
            List<string> roleGuids = new List<string>();
            List<string> userRoleGuids = new List<string>();

            foreach (var role in roles  )
            {
                roleGuids.Add(role.GUID);
            }

            foreach (var userRole in userRoles)
            {
                userRoleGuids.Add(userRole.GUID);
            }

            List<string> availableRoleGuids = roleGuids.Except(userRoleGuids).ToList();

            foreach (var role in roles)
            {
                if(availableRoleGuids.Contains(role.GUID))
                    newRoles.Add(role);
            }

            lbManageRoles.ItemsSource = newRoles;
        }

        private void AddRole_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                AddRole_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion

        private void AddRoleExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            SelectedRole = (Role)lbManageRoles.SelectedItem;
            DialogResult = true;
        }

        private void AddRoleCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (User.UserPermision.Contains(PermissionTypes.Administrator) && lbManageRoles.SelectedItem != null);
        }
    }
}
