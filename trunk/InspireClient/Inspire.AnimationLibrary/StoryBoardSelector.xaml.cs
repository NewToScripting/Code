using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Inspire.AnimationLibrary
{
    /// <summary>
    /// Interaction logic for StoryBoardSelector.xaml
    /// </summary>
    public partial class StoryBoardSelector : IDisposable
    {
        public Storyboard ParentStoryboard
        {
            get { return (Storyboard)GetValue(ParentStoryboardProperty); }
            set { SetValue(ParentStoryboardProperty, value); }
        }

        public Storyboard SelectedResource
        {
            get { return (Storyboard)GetValue(SelectedResourceProperty); }
            set { SetValue(SelectedResourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for sealed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedResourceProperty =
            DependencyProperty.Register("SelectedResource", typeof(Storyboard), typeof(StoryBoardSelector), new UIPropertyMetadata(null));

        // Using a DependencyProperty as the backing store for sealed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ParentStoryboardProperty =
            DependencyProperty.Register("ParentStoryboard", typeof(Storyboard), typeof(StoryBoardSelector), new UIPropertyMetadata(null));


        private ResourceDictionary _resources = new ResourceDictionary();

        private string currentControl;

        bool hasLoaded;

        public StoryBoardSelector()
        {
            InitializeComponent();
            cbStoryBoards.ItemsSource = null;
            Loaded += StoryBoardSelector_Loaded;

            DataContextChanged += new DependencyPropertyChangedEventHandler(StoryBoardSelector_DataContextChanged);
        }

        private void StoryBoardSelector_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (hasLoaded)
                ChangeStoryBoard();
        }

        void StoryBoardSelector_Loaded(object sender, RoutedEventArgs e)
        {
            if (!hasLoaded)
            {
                ChangeStoryBoard();
                hasLoaded = true;
            }


            
            e.Handled = true;
        }

        internal void ChangeStoryBoard()
        {
            //cbStoryBoards.ItemsSource = new ResourceDictionary();
            if (DataContext != null && DataContext is ContentControl)
            {
                cbStoryBoards.ItemsSource = null;
                SelectedResource = null;
                ParentStoryboard = null;

                _resources = ((ContentControl)DataContext).Resources;

                object storyboardEntry = _resources["MainStoryboard"];

                if (storyboardEntry != null)
                {
                    Storyboard parentStoryboard = storyboardEntry as Storyboard;
                    if (parentStoryboard != null)
                    {
                        cbStoryBoards.ItemsSource = parentStoryboard.Children;
                        //.Clone();
                    }
                    else
                        parentStoryboard = new Storyboard();

                    ParentStoryboard = parentStoryboard;
                }
                tbParentStoryboardSpeed.DataContext = ParentStoryboard;
                tbParentStoryboardBegin.DataContext = ParentStoryboard;
                tbParentStoryboardDuration.DataContext = ParentStoryboard;
                tbParentStoryboardRepeatBehavior.DataContext = ParentStoryboard;
                cbParentStoryboardFillBehavior.DataContext = ParentStoryboard;
                tbParentStoryboardAcceleration.DataContext = ParentStoryboard;
                tbParentStoryboardDeceleration.DataContext = ParentStoryboard;
                ckbSBAutoreverse.DataContext = ParentStoryboard;
                if (ParentStoryboard != null)
                {
                    ckbSBAutoreverse.IsChecked = ParentStoryboard.AutoReverse;
                    //sbTimer.StoryBoardValue = ParentStoryboard.GetCurrentTime();
                    //sbTimer.StoryBoardMaxValue = (TimeSpan) GetMaxStoryboardTime(ParentStoryboard);
                }

                SelectFirstItem();

                

            }
            else
                ClearBindings();
        }

        private void ClearBindings()
        {
            cbStoryBoards.ItemsSource = null;
            SelectedResource = null;
            tbSpeed.DataContext = null;
            tbBegin.DataContext = null;
            tbDuration.DataContext = null;
            tbRepeatBehavior.DataContext = null;
            cbFillBehavior.DataContext = null;
            tbAcceleration.DataContext = null;
            tbDeceleration.DataContext = null;
            ckbAutoreverse.DataContext = null;
        }

        private void SelectFirstItem()
        {
            if (cbStoryBoards.Items.Count > 0)
                cbStoryBoards.SelectedIndex = 0;
        }

        private static TimelineCollection RePopulateResources(Storyboard mainStoryboard)
        {
            var storyBoards = new TimelineCollection();

            foreach (CustomStoryboard item in mainStoryboard.Children)
            {
                storyBoards.Add(new CustomStoryboard(item));
            }
            return storyBoards;
        }

        private void AddAnimation_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = Application.Current.MainWindow.DataContext;

            var animationSelector = new AnimationSelector((ContentControl)dataContext);
            animationSelector.ShowDialog();
            if (animationSelector.DialogResult == true)
            {
                // ResourceDictionary resources = ((ContentControl)DataContext).Resources;

                //Storyboard storyboard = ((ContentControl) DataContext).Resources["MainStoryBoard"] as Storyboard;

                // DictionaryEntry storyboardEntry = (DictionaryEntry)((ContentControl)DataContext).Resources["MainStoryboard"];

                object storyboardEntry = _resources["MainStoryboard"];
                Storyboard parentStoryboard = null;

                if (storyboardEntry != null)
                    parentStoryboard = storyboardEntry as Storyboard;

                if (animationSelector.SelectedAnimation != null)
                {
                    if (parentStoryboard != null)
                    {
                        parentStoryboard.Children.Add(animationSelector.SelectedAnimation);
                    }
                    else
                    {
                        parentStoryboard = new Storyboard();
                        parentStoryboard.Children.Add(animationSelector.SelectedAnimation);
                    }
                }
                _resources.Clear();
                _resources.Add("MainStoryboard", parentStoryboard);

                if (parentStoryboard != null)
                {
                    parentStoryboard.Children = RePopulateResources(parentStoryboard);

                    cbStoryBoards.ItemsSource = parentStoryboard.Children;
                }
                cbStoryBoards.SelectedIndex = cbStoryBoards.Items.Count - 1;

                ChangeStoryBoard();
            }
        }

        private void cbStoryBoards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbStoryBoards.SelectedItem != null && DataContext is ContentControl)
                SelectedResource = (CustomStoryboard)cbStoryBoards.SelectedItem;

            if (SelectedResource != null)
            {
                tbSpeed.DataContext = SelectedResource;
                tbBegin.DataContext = SelectedResource;
                tbDuration.DataContext = SelectedResource;
                tbRepeatBehavior.DataContext = SelectedResource;
                cbFillBehavior.DataContext = SelectedResource;
                tbAcceleration.DataContext = SelectedResource;
                tbDeceleration.DataContext = SelectedResource;
                ckbAutoreverse.DataContext = SelectedResource;
                ckbAutoreverse.IsChecked = SelectedResource.AutoReverse;
            }

        }

        private void RemoveAnimation_Click(object sender, RoutedEventArgs e)
        {
            if (cbStoryBoards.SelectedItem != null)
            {
                object storyboardEntry = _resources["MainStoryboard"];
                Storyboard parentStoryboard = null;

                if (storyboardEntry != null)
                    parentStoryboard = storyboardEntry as Storyboard;


                Timeline sb = null;

                if (parentStoryboard != null)
                {
                    foreach (var child in parentStoryboard.Children)
                    {
                        if (child.Name == ((CustomStoryboard)cbStoryBoards.SelectedItem).Name)
                            sb = child;
                    }
                }
                parentStoryboard.Children.Remove(sb);

                cbStoryBoards.ItemsSource = RePopulateResources(parentStoryboard);
            }
        }

        private void cbFillBehavior_DropDownClosed(object sender, System.EventArgs e)
        {
            if (SelectedResource != null)
                if (((ComboBox)sender).Text == "HoldEnd")
                    SelectedResource.FillBehavior = FillBehavior.HoldEnd;
                else
                    SelectedResource.FillBehavior = FillBehavior.Stop;
        }

        private void cbParentStoryboardFillBehavior_DropDownClosed(object sender, EventArgs e)
        {
            if (ParentStoryboard != null)
                if (((ComboBox)sender).Text == "HoldEnd")
                    ParentStoryboard.FillBehavior = FillBehavior.HoldEnd;
                else
                    ParentStoryboard.FillBehavior = FillBehavior.Stop;
        }

        private void ckbAutoreverse_Checked(object sender, RoutedEventArgs e)
        {
            if (SelectedResource != null) SelectedResource.AutoReverse = true;
        }

        private void ckbAutoreverse_Unchecked(object sender, RoutedEventArgs e)
        {
            if (SelectedResource != null) SelectedResource.AutoReverse = false;
        }

        private void ckbSBAutoreverse_Checked(object sender, RoutedEventArgs e)
        {
            if (ParentStoryboard != null) ParentStoryboard.AutoReverse = true;
        }

        private void ckbSBAutoreverse_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ParentStoryboard != null) ParentStoryboard.AutoReverse = false;
        }

        private void tbParentStoryboardAcceleration_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ParentStoryboard != null)
                if (e.NewValue + ParentStoryboard.DecelerationRatio > 1)
                    ParentStoryboard.DecelerationRatio = tbParentStoryboardDeceleration.Value = 1 - e.NewValue;
        }

        private void tbParentStoryboardDeceleration_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ParentStoryboard != null)
                if (e.NewValue + ParentStoryboard.AccelerationRatio > 1)
                    ParentStoryboard.AccelerationRatio = tbParentStoryboardAcceleration.Value = 1 - e.NewValue;
        }

        private void tbAcceleration_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SelectedResource != null)
                if (e.NewValue + SelectedResource.DecelerationRatio > 1)
                    SelectedResource.DecelerationRatio = tbDeceleration.Value = 1 - e.NewValue;
        }

        private void tbDeceleration_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SelectedResource != null)
                if (e.NewValue + SelectedResource.AccelerationRatio > 1)
                    SelectedResource.AccelerationRatio = tbAcceleration.Value = 1 - e.NewValue;
        }

        public void Dispose()
        {
            Loaded -= StoryBoardSelector_Loaded;

            currentControl = null;
            ParentStoryboard = null;
            SelectedResource = null;

            //TODO: clear textbox bindings

            //BindingOperations.ClearAllBindings(tbInnerGlowSize);
            //BindingOperations.ClearAllBindings(tbMain1);
            //BindingOperations.ClearAllBindings(tbMain2);
            //BindingOperations.ClearAllBindings(tbMain3);
            //BindingOperations.ClearAllBindings(tbMain4);
        }
    }
}