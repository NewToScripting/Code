using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Inspire
{
    // Defines SearchPredicate delegate alias as <element, search pattern, result>
    using SearchPredicate = Func<object, string, bool>;

    /// <summary>
    /// Provides a search/filter for items bind to an ItemsControl.
    /// 
    /// To use this control, simply place an ItemsControl object as the content
    /// </summary>
    [TemplatePart(Name = "PART_FilterBox")]
    public class Filter : HeaderedContentControl
    {
        #region Fields

        private TextBox _filterBox;

        #region ContentTextSearch
        public static readonly SearchPredicate ContentTextSearch = (element, pattern) =>
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return true;
            }

            string text = string.Empty;

            ContentControl control = element as ContentControl;
            if (control != null && control.Content != null)
            {
                text = control.Content.ToString();
            }
            else
            {
                text = element.ToString();
            }

            text = text.ToLower();
            pattern = pattern.ToLower();

            return text.Contains(pattern);
        };
        #endregion

        #endregion

        #region Initialization

        static Filter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Filter), new FrameworkPropertyMetadata(typeof(Filter)));
        }

        public Filter()
        {
            ComponentResourceKey filterBoxStyleKey = new ComponentResourceKey(typeof(Filter), "FilterBoxStyle");
            FilterBoxStyle = TryFindResource(filterBoxStyleKey) as Style;
        }

        #endregion

        #region Dependency Properties

        #region FilterBoxStyle Property

        /// <value>Identifies the FilterBoxStyle dependency property</value>
        public static readonly DependencyProperty FilterBoxStyleProperty =
            DependencyProperty.Register("FilterBoxStyle", typeof(Style), typeof(Filter),
            new FrameworkPropertyMetadata(null, OnFilterBoxStyleChanged));

        /// <value>description for FilterBoxStyle property</value>
        public Style FilterBoxStyle
        {
            get { return (Style)GetValue(FilterBoxStyleProperty); }
            set { SetValue(FilterBoxStyleProperty, value); }
        }

        /// <summary>
        /// Invoked on FilterBoxStyle change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        static void OnFilterBoxStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

        #region SearchPattern Property

        /// <value>Identifies the SearchPattern dependency property</value>
        public static readonly DependencyProperty SearchPatternProperty =
            DependencyProperty.Register("SearchPattern", typeof(string), typeof(Filter),
            new FrameworkPropertyMetadata(string.Empty, OnSearchPatternChanged));

        /// <value>description for SearchPattern property</value>
        public string SearchPattern
        {
            get { return (string)GetValue(SearchPatternProperty); }
            set { SetValue(SearchPatternProperty, value); }
        }

        /// <summary>
        /// Invoked on SearchPattern change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        static void OnSearchPatternChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Filter filter = d as Filter;

            if (filter.View != null)
            {
                filter.View.Refresh();
            }
        }

        #endregion

        #region SearchStrategy Property

        /// <value>Identifies the SearchStrategy dependency property</value>
        public static readonly DependencyProperty SearchStrategyProperty =
            DependencyProperty.Register("SearchStrategy", typeof(SearchPredicate), typeof(Filter),
            new FrameworkPropertyMetadata(
                ContentTextSearch,
                OnSearchStrategyChanged));

        /// <value>description for SearchStrategy property</value>
        public SearchPredicate SearchStrategy
        {
            get { return (SearchPredicate)GetValue(SearchStrategyProperty); }
            set { SetValue(SearchStrategyProperty, value); }
        }

        /// <summary>
        /// Invoked on SearchStrategy change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        static void OnSearchStrategyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Filter filter = d as Filter;

            if (filter.View != null)
            {
                filter.View.Filter = new Predicate<object>(item =>
                {
                    return filter.SearchStrategy(item, filter.SearchPattern);
                });
            }
        }

        #endregion

        #region ItemsSource Property

        /// <value>Identifies the ItemsSource dependency property</value>
        private static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(Filter),
            new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

        /// <value>description for ItemsSource property</value>
        private IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// Invoked on ItemsSource change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Filter filter = d as Filter;

            IEnumerable oldItems = e.OldValue as IEnumerable;
            if (oldItems != null)
            {
                ICollectionView oldView = CollectionViewSource.GetDefaultView(oldItems);
                oldView.Filter = null;
            }

            IEnumerable newItems = e.NewValue as IEnumerable;
            if (newItems != null)
            {
                ICollectionView newView = CollectionViewSource.GetDefaultView(newItems);
                newView.Filter = new Predicate<object>(item =>
                {
                    return filter.SearchStrategy(item, filter.SearchPattern);
                });
            }
        }

        #endregion

        #endregion

        #region CLR Properties

        private ICollectionView View
        {
            get { return CollectionViewSource.GetDefaultView(ItemsSource); }
        }

        #endregion

        #region Overrides

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            ItemsControl itemsControl = newContent as ItemsControl;
            if (itemsControl == null)
            {
                throw new ArgumentException("Content or Content Template must be an ItemsControl");
            }

            Binding itemsBinding = new Binding("ItemsSource");
            itemsBinding.Mode = BindingMode.OneWay;
            itemsBinding.Source = itemsControl;
            SetBinding(ItemsSourceProperty, itemsBinding);

            base.OnContentChanged(oldContent, newContent);
        }

        public override void OnApplyTemplate()
        {
            _filterBox = Template.FindName("PART_FilterBox", this) as TextBox;

            if (_filterBox == null)
            {
                throw new ArgumentException("Filter ControlTemplate must have at least one TextBox element named PART_FilterBox");
            }

            Binding filterBoxBinding = new Binding("Text");
            filterBoxBinding.Mode = BindingMode.TwoWay;
            filterBoxBinding.Source = _filterBox;
            SetBinding(SearchPatternProperty, filterBoxBinding);

            base.OnApplyTemplate();
        }

        #endregion
    }
}
