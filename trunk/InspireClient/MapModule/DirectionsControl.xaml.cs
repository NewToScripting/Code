using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using Transitionals.Controls;

namespace MapModule
{
	/// <summary>
	/// Interaction logic for DirectionsControl.xaml
	/// </summary>
	public partial class DirectionsControl : UserControl
	{
	    private readonly BackgroundWorker _backgroundWorker;
	    private readonly InspireMapLocation _endLocation;

        private readonly TransitionElement _contentHolder;
        private readonly TransitionElement _detailHolder;
        private readonly IEnumerable<MapCategory> _cats;
        private readonly InspireMapLocation _home;
	    private readonly bool _showPrint;

	    public DirectionsControl(InspireMapLocation home, InspireMapLocation endLocation, TransitionElement contentHolder, TransitionElement detailHolder, IEnumerable<MapCategory> cats, bool showPrint)
		{
			InitializeComponent();

	        _contentHolder = contentHolder;
	        _detailHolder = detailHolder;
	        _cats = cats;
	        _home = home;
	        _endLocation = endLocation;
            _showPrint = showPrint;

	        DataContext = _endLocation;

            if(_endLocation.RatingCount == 0)
            {
                //PART_RatingControl.Visibility = System.Windows.Visibility.Collapsed;
                PART_NumOfRatings.Visibility = System.Windows.Visibility.Collapsed;
            }

            if (_showPrint)
                PART_PrintButton.Visibility = System.Windows.Visibility.Visible;

            _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;

            while (_backgroundWorker.IsBusy)
            {
                Thread.Sleep(1000);
            }

            _backgroundWorker.RunWorkerAsync();
		}

	    private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	    {
            loadingControl.Visibility = Visibility.Collapsed;
            
            //if (lbDirections.Items.Count == 0)
            //        .Text = "No directions found please try again.";
	    }

	    private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
	    {
            List<DirectionItem> directions = MapRequestManager.GetDirections(_home, _endLocation);

	        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
	                                                                    {
                                                                            lbDirections.ItemsSource = directions;
	                                                                    }));
	    }

	    private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var catView = new CategorySlider(_cats, _contentHolder, _detailHolder, _home, _showPrint);
            _contentHolder.Content = catView;
            _detailHolder.Content = null;
            VEMapManager.SetPushPins(null, _home);
        }

        private void PART_PrintButton_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            var printForm = new PrintForm((List<DirectionItem>) lbDirections.ItemsSource, _home, _endLocation);
                
            printForm.UpdateLayout();
            printForm.Arrange(new Rect(new Size(768, 1024)));

            pd.PrintVisual(printForm, "Directions to " + _endLocation.LocationName);
            PART_PrintButton.Visibility = Visibility.Collapsed;

        }

        private void PART_PrintButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            var printForm = new PrintForm((List<DirectionItem>)lbDirections.ItemsSource, _home, _endLocation);

            printForm.UpdateLayout();
            printForm.Arrange(new Rect(new Size(820, 1024)));

            pd.PrintVisual(printForm, "Directions to " + _endLocation.LocationName);
            PART_PrintButton.Visibility = Visibility.Collapsed;
        }
	}
}