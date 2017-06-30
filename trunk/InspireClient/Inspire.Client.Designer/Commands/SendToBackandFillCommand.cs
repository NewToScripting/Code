using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace Inspire.Client.Designer.Commands
{
    class FillSlideCommand : IDesignerCommand
    {
        #region Properties

        public List<ISelectable> Elements { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }
        public UserControl DCanvas { get; set; }
        public ControlPosition StartControlPosition { get; set; }

        #endregion

        #region ctor

        public FillSlideCommand(ObservableCollection<ContentControl> canvasItems, List<ISelectable> elements, UserControl userControl)
        {

            if (canvasItems == null) throw new ArgumentNullException("canvasItems");
            if (elements == null) throw new ArgumentNullException("elements");
            if (userControl == null) throw new ArgumentNullException("userControl");

            Elements = elements;
            CanvasItems = canvasItems;
            DCanvas = userControl;

            //List<ISelectable> selectionSorted = (from item in Elements
            //                                     orderby Canvas.GetZIndex(item as DesignContentControl) ascending
            //                                     select item).ToList();
            StartControlPosition = new ControlPosition((DesignControlHolder)Elements[0]);

        }
        #endregion

        public void Execute()
        {
            //List<ISelectable> selectionSorted = (from item in Elements
            //                                     orderby Canvas.GetZIndex(item as DesignContentControl) ascending
            //                                     select item).ToList();

            //List<DesignContentControl> childrenSorted = (from DesignContentControl item in CanvasItems
            //                                             orderby Canvas.GetZIndex(item) ascending
            //                                             select item).ToList();
            //int i = 0;
            //int j = 0;
            foreach (DesignControlHolder item in Elements)
            {

                if (((DesignContentControl)item.Content).Type == MediaType.Image)
                {
                    Image element = (Image)((DesignContentControl)item.Content).Content;
                    element.Stretch = Stretch.Fill;
                }
                else if (((DesignContentControl)item.Content).Type == MediaType.Video || ((DesignContentControl)item.Content).Type == MediaType.QuickTime)
                {
                    MediaElement element = ((DesignContentControl)item.Content).Content as MediaElement;
                    if (element != null) element.Stretch = Stretch.Fill;
                }
                //List<ControlPosition> startControlPositions = new List<ControlPosition>();
                //ControlPosition startControlPosition = new ControlPosition(item);
                //startControlPositions.Add(startControlPosition);

                Canvas.SetLeft(item, 0);
                Canvas.SetTop(item, 0);
                item.Width = DCanvas.Width + 2;
                item.Height = DCanvas.Height + 2;
                item.SnapsToDevicePixels = true;
                ((DesignContentControl)item.Content).RotateTransform.Angle = 0;

            }
        }

        public void Undo()
        {
            if (Elements != null && Elements.Count > 0)
            {
                ((ContentControl) Elements[0]).Width = StartControlPosition.DesignerSize.Width;
                ((ContentControl) Elements[0]).Height = StartControlPosition.DesignerSize.Height;
                ((DesignControlHolder) Elements[0]).RotateTransform.Angle = StartControlPosition.DesignerRotateAngle;
                Canvas.SetLeft((ContentControl) Elements[0], StartControlPosition.DesignerCoordinate.X);
                Canvas.SetTop((ContentControl)Elements[0], StartControlPosition.DesignerCoordinate.Y);
            }
        }

        public void Redo()
        {
            if (Elements != null && Elements.Count > 0)
            {
                foreach (DesignControlHolder item in Elements)
                {

                    if (((DesignContentControl)item.Content).Type == MediaType.Image)
                    {
                        Image element = (Image)((DesignContentControl)item.Content).Content;
                        element.Stretch = Stretch.Fill;
                    }
                    else if (((DesignContentControl)item.Content).Type == MediaType.Video || ((DesignContentControl)item.Content).Type == MediaType.QuickTime)
                    {
                        MediaElement element = ((DesignContentControl)item.Content).Content as MediaElement;
                        if (element != null) element.Stretch = Stretch.Fill;
                    }
                    //List<ControlPosition> startControlPositions = new List<ControlPosition>();
                    //ControlPosition startControlPosition = new ControlPosition(item);
                    //startControlPositions.Add(startControlPosition);

                    Canvas.SetLeft(item, 0);
                    Canvas.SetTop(item, 0);
                    item.Width = DCanvas.Width;
                    item.Height = DCanvas.Height;
                    ((DesignContentControl)item.Content).RotateTransform.Angle = 0;

                }
            }
        }

        public string Title
        {
            get
            {
                return "Elements filled to slide [" + Elements.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
