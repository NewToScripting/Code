using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MapModule
{
	/// <summary>
	/// Interaction logic for SearchControl.xaml
	/// </summary>
	public partial class SearchControl : UserControl
	{
        private readonly List<MapCategory> _inspireMapCategories;
        private readonly Transitionals.Controls.TransitionElement _contentHolder;
        private readonly Transitionals.Controls.TransitionElement _detailHolder;
        private readonly InspireMapLocation _home;
	    private readonly bool _showPrint;

	    public SearchControl()
		{
			this.InitializeComponent();
		}

        public SearchControl(List<MapCategory> inspireMapCategories, Transitionals.Controls.TransitionElement categoryHolder, Transitionals.Controls.TransitionElement detailsHolder, InspireMapLocation home, bool showPrint): this()
        {
            this._inspireMapCategories = inspireMapCategories;
            this._contentHolder = categoryHolder;
            this._detailHolder = detailsHolder;
            this._home = home;

            _showPrint = showPrint;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(tbSearch.Text.Length.Equals(0)) return;

            Random randNum = new Random();

            var style = randNum.Next(1, 48); 

            var subCatView = new SubCategorySlider(_inspireMapCategories, null, _contentHolder, _detailHolder, _home, tbSearch.Text, style.ToString(), true, _showPrint);
            _contentHolder.Content = subCatView;
        }

	    private void BackButton_Click(object sender, RoutedEventArgs e)
	    {
            var catView = new CategorySlider(_inspireMapCategories, _contentHolder, _detailHolder, _home, _showPrint);
            _contentHolder.Content = catView;
            _detailHolder.Content = null;
            VEMapManager.SetPushPins(null, _home);
	    }
	}
}