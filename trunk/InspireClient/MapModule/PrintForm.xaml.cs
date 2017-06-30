using System.Collections.Generic;
using System.Windows.Controls;

namespace MapModule
{
    /// <summary>
    /// Interaction logic for PrintForm.xaml
    /// </summary>
    public partial class PrintForm
    {
        public PrintForm()
        {
            InitializeComponent();
        }

        public PrintForm(List<DirectionItem> itemsSource, InspireMapLocation home, InspireMapLocation endLocation) : this()
        {
            DataContext = endLocation;
            txtPhone.Text = endLocation.PhoneNumber;
            txtLocation.Text = endLocation.LocationName;
            if (endLocation.Address != null) txtAddress.Text = endLocation.Address.FormattedAddress;
            txtDistance.Text = endLocation.LocationDistance;
            lbDirections.ItemsSource = itemsSource;
        }
    }
}
