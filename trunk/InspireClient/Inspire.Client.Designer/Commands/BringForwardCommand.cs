﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Inspire.Interfaces;

namespace Inspire.Client.Designer.Commands
{
    public class BringForwardCommand : IDesignerCommand
    {
        #region Properties

        public List<ISelectable> Elements { get; set; }
        public ObservableCollection<ContentControl> CanvasItems { get; set; }

        #endregion

        #region ctor

        public BringForwardCommand(ObservableCollection<ContentControl> canvasItems, List<ISelectable> elements)
        {

            if(canvasItems == null) throw new ArgumentNullException ("canvasItems");
            if(elements == null) throw new ArgumentNullException("elements");

            Elements = elements;
            CanvasItems = canvasItems;
        }
        #endregion

        public void Execute()
        {
            if(Elements != null)
            {
                List<ISelectable> ordered = (Elements.OrderByDescending(item => Canvas.GetZIndex(item as ContentControl))).ToList();

                int count = CanvasItems.Count;

                for (int i = 0; i < ordered.Count; i++)
                {
                    int currentIndex = Canvas.GetZIndex(ordered[i] as ContentControl);
                    int newIndex = Math.Min(count - 1 - i, currentIndex + 1);
                    if (currentIndex != newIndex)
                    {
                        Canvas.SetZIndex(ordered[i] as ContentControl, newIndex);
                        IEnumerable<ContentControl> it = CanvasItems.OfType<ContentControl>().Where(item => Canvas.GetZIndex(item) == newIndex);

                        foreach (ContentControl elm in it)
                        {
                            if (elm != ordered[i])
                            {
                                Canvas.SetZIndex(elm, currentIndex);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void Undo()
        {
            if (Elements != null)
            {
                List<ISelectable> ordered = (from item in Elements
                                                      orderby Canvas.GetZIndex(item as ContentControl) ascending
                                                      select item).ToList();

                for (int i = 0; i < ordered.Count; i++)
                {
                    int currentIndex = Canvas.GetZIndex(ordered[i] as ContentControl);
                    int newIndex = Math.Max(i, currentIndex - 1);
                    if (currentIndex != newIndex)
                    {
                        Canvas.SetZIndex(ordered[i] as ContentControl, newIndex);
                        IEnumerable<ContentControl> it = CanvasItems.OfType<ContentControl>().Where(item => Canvas.GetZIndex(item) == newIndex);

                        foreach (ContentControl elm in it)
                        {
                            if (elm != ordered[i])
                            {
                                Canvas.SetZIndex(elm, currentIndex);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void Redo()
        {
            if (Elements != null)
            {
                List<ISelectable> ordered = (Elements.OrderByDescending(item => Canvas.GetZIndex(item as ContentControl))).ToList();

                int count = CanvasItems.Count;

                for (int i = 0; i < ordered.Count; i++)
                {
                    int currentIndex = Canvas.GetZIndex(ordered[i] as ContentControl);
                    int newIndex = Math.Min(count - 1 - i, currentIndex + 1);
                    if (currentIndex != newIndex)
                    {
                        Canvas.SetZIndex(ordered[i] as ContentControl, newIndex);
                        IEnumerable<ContentControl> it = CanvasItems.OfType<ContentControl>().Where(item => Canvas.GetZIndex(item) == newIndex);

                        foreach (ContentControl elm in it)
                        {
                            if (elm != ordered[i])
                            {
                                Canvas.SetZIndex(elm, currentIndex);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public string Title
        {
            get
            {
                return "Elements moved forward [" + Elements.GetType().Name + "]";
            }
            set
            {
                // May just need get.
            }
        }
    }
}
