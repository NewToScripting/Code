using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace RSSModule
{
    public class RSSCommandItem : ICommand, INotifyPropertyChanged
    {
        protected internal RSSCommandItem(RSSControl RSSScroller, int index)
        {
            Util.RequireNotNull(RSSScroller, "RSSScroller");
            Util.RequireArgumentRange(index >= 0, "index");

            m_RSSScroller = RSSScroller;

            m_RSSScroller.CurrentItemChanged += delegate(object sender, RoutedPropertyChangedEventArgs<int> e)
            {
                OnCanExecuteChanged(EventArgs.Empty);
            };

            m_index = index;

            m_content = m_RSSScroller.Items[m_index];
        }

        public object Content
        {
            get { return m_content; ; }
            protected internal set
            {
                if (m_content != value)
                {
                    m_content = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Content"));
                }
            }
        }

        public int Index { get { return m_index; } }

        /// <remarks>
        ///     For public use. Most people don't like zero-base indices.
        /// </remarks>
        public int Number { get { return m_index + 1; } }

        public bool CanExecute
        {
            get
            {
                return (m_index != m_RSSScroller.CurrentItemIndex);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute;
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            OnPropertyChanged(new PropertyChangedEventArgs("CanExecute"));

            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void MakeCurrent()
        {
            m_RSSScroller.CurrentItemIndex = m_index;
        }

        void ICommand.Execute(object parameter)
        {
            MakeCurrent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public override string ToString()
        {
            string output = (Content == null) ? "*null*" : Content.ToString();

            return string.Format("RSSCommandItem - Index: {0}, Content: {1}", m_index, output);
        }

        #region Implementation

        private object m_content;

        private readonly int m_index;
        private readonly RSSControl m_RSSScroller;

        #endregion

    } //*** class RSSCommandItem
}
