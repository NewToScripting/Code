using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Inspire;
using Inspire.AnimationLibrary;
using Inspire.Events.Proxy;

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
        private readonly TextBlock _hTextBlock;
        private readonly Image _groupImage;
        private readonly StackPanel _panel;

        public GroupControl(IGrouping<string, HospitalityEvent> nuts, ListBox eventColumns, TextBlock headerTextBlock) : this()
        {
            var stackPanel = Content as StackPanel;

            SizeChanged += GroupControl_SizeChanged;

            if (stackPanel != null)
            {
                _panel = stackPanel.Children[0] as StackPanel;
                if (_panel != null)
                {
                    _groupImage = _panel.Children[0] as Image;
                    _hTextBlock = _panel.Children[1] as TextBlock;
                }

                if (_hTextBlock != null)
                {
                    _hTextBlock.Text = nuts.Key;
                    _hTextBlock.Foreground = headerTextBlock.Foreground;
                    _hTextBlock.FontSize = headerTextBlock.FontSize;
                    _hTextBlock.FontFamily = headerTextBlock.FontFamily;

                    _hTextBlock.FontStyle = headerTextBlock.FontStyle;
                    _hTextBlock.FontWeight = headerTextBlock.FontWeight;
                    _hTextBlock.TextDecorations = headerTextBlock.TextDecorations;

                    _hTextBlock.TextTrimming = TextTrimming.CharacterEllipsis;
                    _hTextBlock.TextWrapping = TextWrapping.NoWrap;
                    _hTextBlock.TextAlignment = headerTextBlock.TextAlignment;

                    _hTextBlock.RenderTransformOrigin = new Point(0.5, 0.5);
                    if (_groupImage != null) _groupImage.RenderTransformOrigin = new Point(0.5, 0.5);

                    var trGrp = new TransformGroup();

                    var scaleTransform = new ScaleTransform(1, 1);

                    trGrp.Children.Add(scaleTransform);

                    var skewTransform = new SkewTransform(0, 0);
                    trGrp.Children.Add(skewTransform);

                    var rotateTransform = new RotateTransform(0);
                    trGrp.Children.Add(rotateTransform);

                    var translateTransform = new TranslateTransform(0, 0);
                    trGrp.Children.Add(translateTransform);

                    _hTextBlock.RenderTransform = trGrp;

                    var trGrp2 = new TransformGroup();

                    var scaleTransform2 = new ScaleTransform(1, 1);

                    trGrp2.Children.Add(scaleTransform2);

                    var skewTransform2 = new SkewTransform(0, 0);
                    trGrp2.Children.Add(skewTransform2);

                    var rotateTransform2 = new RotateTransform(0);
                    trGrp2.Children.Add(rotateTransform2);

                    var translateTransform2 = new TranslateTransform(0, 0);
                    trGrp2.Children.Add(translateTransform2);

                    if (_groupImage != null) _groupImage.RenderTransform = trGrp2;
                }
            }
            string imageTag = string.Empty;

            if (stackPanel != null)
            {
                StackPanel eventRows = stackPanel.Children[1] as StackPanel;

                string logoUrl = string.Empty;

                foreach (HospitalityEvent nut in nuts)
                {
                    nut.IsVisible = true; // TODO : Take out once resize is implemented
                    if((bool) nut.IsVisible)
                        if (eventRows != null) eventRows.Children.Add(new EventRow(nut, eventColumns));

                    if (nut.GroupLogo.Length > 0 && !nut.GroupLogo.EndsWith("/"))
                        logoUrl = nut.GroupLogo;
                }



                if (logoUrl.Length > 0)
                {
                    foreach (TextBlock eventTextBlock in eventColumns.Items)
                    {
                        if (eventTextBlock.Text == "GroupLogo")
                        {
                            if (_groupImage != null)
                            {
                                _groupImage.Width = eventTextBlock.Width;
                                _groupImage.Source = new BitmapImage(new Uri(logoUrl));
                                if (eventTextBlock.Tag != null)
                                    imageTag = eventTextBlock.Tag.ToString();
                            }
                        }
                    }
                }
                else
                {
                    if (_groupImage != null) _groupImage.Visibility = Visibility.Collapsed;
                }

            }
            if (headerTextBlock.Tag != null)
                AnimationManager.ApplyAnimation(_hTextBlock, headerTextBlock.Tag.ToString(), InspireApp.GetCanvasSize());

            if (imageTag.Length > 0)
                AnimationManager.ApplyAnimation(_groupImage, imageTag, InspireApp.GetCanvasSize());
        }

        void GroupControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_hTextBlock != null)
            {
                if(ActualWidth > _groupImage.ActualWidth)
                    _hTextBlock.Width = ActualWidth - _groupImage.ActualWidth;
            }
        }

    }
}
