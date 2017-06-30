using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Inspire.Interfaces;

namespace Inspire.Designer.Commands
{
    public class MoveDesignItemCommand : IDesignerCommand
    {

        #region Properties

        public List<ControlPosition> StartPositions { get; set; }
        public List<ControlPosition> EndPositions { get; set; }

        #endregion

        #region ctor

        public MoveDesignItemCommand(List<ControlPosition> startPositions, List<ControlPosition> endPositions)
        {
            if (startPositions != null && endPositions != null)
            {
                if (startPositions == null) throw new ArgumentNullException("startPositions");
                if (endPositions == null) throw new ArgumentNullException("endPositions");

                StartPositions = startPositions;
                EndPositions = endPositions;
            }
        }
        #endregion

        public void Execute()
        {
            // This is where we will show Dialogs, Wizards or other things

            if(EndPositions != null)
            foreach (ControlPosition controlPosition in EndPositions)
            {
                Canvas.SetLeft(controlPosition.DesignerItem, controlPosition.DesignerCoordinate.X);
                Canvas.SetTop(controlPosition.DesignerItem, controlPosition.DesignerCoordinate.Y);
               // Canvas.SetZIndex(controlPosition.DesignerItem, controlPosition.DesignerZIndex);
                controlPosition.DesignerItem.Width = controlPosition.DesignerSize.Width;
                controlPosition.DesignerItem.Height = controlPosition.DesignerSize.Height;
                controlPosition.DesignerItem.RotateTransform.Angle = controlPosition.DesignerRotateAngle;
            }
        }

        public void Undo()
        {
            if (StartPositions != null)
            foreach (ControlPosition controlPosition in StartPositions)
            {
                Canvas.SetLeft(controlPosition.DesignerItem, controlPosition.DesignerCoordinate.X);
                Canvas.SetTop(controlPosition.DesignerItem, controlPosition.DesignerCoordinate.Y);
               // Canvas.SetZIndex(controlPosition.DesignerItem, controlPosition.DesignerZIndex);
                controlPosition.DesignerItem.Width = controlPosition.DesignerSize.Width;
                controlPosition.DesignerItem.Height = controlPosition.DesignerSize.Height;
                controlPosition.DesignerItem.RotateTransform.Angle = controlPosition.DesignerRotateAngle;
            }
        }

        public void Redo()
        {
            if (EndPositions != null)
            foreach (ControlPosition controlPosition in EndPositions)
            {
                Canvas.SetLeft(controlPosition.DesignerItem, controlPosition.DesignerCoordinate.X);
                Canvas.SetTop(controlPosition.DesignerItem, controlPosition.DesignerCoordinate.Y);
               // Canvas.SetZIndex(controlPosition.DesignerItem, controlPosition.DesignerZIndex);
                controlPosition.DesignerItem.Width = controlPosition.DesignerSize.Width;
                controlPosition.DesignerItem.Height = controlPosition.DesignerSize.Height;
                controlPosition.DesignerItem.RotateTransform.Angle = controlPosition.DesignerRotateAngle;
            }
        }

        public string Title
        {
            get
            {
                return "Elements moved";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
