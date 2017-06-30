using System;
using System.Windows;
using System.Windows.Input;
using Inspire.Server.Proxy;

namespace Inspire.Client.Dialogs
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {


        public Registration(RegistrationRequest registrationRequest)
        {
            InitializeComponent();
            DataContext = registrationRequest;
        }

        private void RegisterExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var registrationRequest = DataContext as RegistrationRequest;

            if(registrationRequest != null)
            {
                var authenticate = RegistrationManager.RegisterSoftware(registrationRequest.FirstName,
                                                                        registrationRequest.LastName,
                                                                        registrationRequest.CompanyName,
                                                                        registrationRequest.AddressLine1,
                                                                        registrationRequest.AddressLine2,
                                                                        registrationRequest.City,
                                                                        registrationRequest.State,
                                                                        registrationRequest.Zip,
                                                                        registrationRequest.EmailAddress,
                                                                        registrationRequest.Phone,
                                                                        registrationRequest.RegistrationGuid);

                DialogResult = authenticate;
                return;
            }
            DialogResult = false;
        }

        private void RegisterCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
