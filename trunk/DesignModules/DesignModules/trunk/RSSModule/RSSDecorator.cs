using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace RSSModule
{
    public class RSSDecorator : Decorator
    {
        public RSSDecorator()
        {
            m_listener.Rendering += m_listener_rendering;
            m_listener.WireParentLoadedUnloaded(this);

        }

        public static readonly DependencyProperty TargetIndexProperty =
            DependencyProperty.Register("TargetIndex", typeof(int), typeof(RSSDecorator),
            new FrameworkPropertyMetadata(0, new PropertyChangedCallback(targetIndexChanged)));

        public int TargetIndex
        {
            get { return (int)GetValue(TargetIndexProperty); }
            set { SetValue(TargetIndexProperty, value); }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            UIElement child = this.Child;
            if (child != null)
            {
                m_listener.StartListening();
                child.Measure(availableSize);
            }
            return new Size();
        }

        #region Implementation

        private void m_listener_rendering(object sender, EventArgs e)
        {
            if (this.Child != m_RSSPanel)
            {
                m_RSSPanel = (RSSPanel)this.Child;
                m_RSSPanel.RenderTransform = m_traslateTransform;
            }
            if (m_RSSPanel != null)
            {
                int actualTargetIndex = Math.Max(0, Math.Min(m_RSSPanel.Children.Count - 1, TargetIndex));

                double targetPercentOffset = -actualTargetIndex / (double)m_RSSPanel.Children.Count;
                targetPercentOffset = double.IsNaN(targetPercentOffset) ? 0 : targetPercentOffset;

                bool stopListening = !Util.Animate(
                    m_percentOffset, m_velocity, targetPercentOffset,
                    .05, .3, .1, c_diff, c_diff,
                    out m_percentOffset, out m_velocity);

                double targetPixelOffset = m_percentOffset * (this.RenderSize.Width * m_RSSPanel.Children.Count);
                m_traslateTransform.X = targetPixelOffset;

                if (stopListening)
                {
                    m_listener.StopListening();
                }

            }
        }

        private static void targetIndexChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            ((RSSDecorator)element).m_listener.StartListening();
        }

        private double m_velocity;
        private double m_percentOffset;

        private RSSPanel m_RSSPanel;
        private readonly TranslateTransform m_traslateTransform = new TranslateTransform();
        private readonly CompositionTargetRenderingListener m_listener = new CompositionTargetRenderingListener();

        private const double c_diff = .00001;

        #endregion

    }
}
