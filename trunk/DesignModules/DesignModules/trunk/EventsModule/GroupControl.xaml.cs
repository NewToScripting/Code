using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventsModule
{
    /// <summary>
    /// Interaction logic for GroupControl.xaml
    /// </summary>
    public partial class GroupControl
    {
        public GroupControl()
        {
            InitializeComponent();
        }

        public GroupControl(IGrouping<string, BagOfNuts> nuts, List<TextBlock> eventColumns) : this()
        {
            GroupHeader.Text = nuts.Key;

            //foreach (TextBlock column in eventColumns)
            //{
            //    switch (column.Text)
            //    {
            //        case ():
            //            break;
            //    }
            //}

            foreach (BagOfNuts nut in nuts)
            {

                EventRows.Children.Add(new EventRow(nut, eventColumns));
            }
        }
    }
}
