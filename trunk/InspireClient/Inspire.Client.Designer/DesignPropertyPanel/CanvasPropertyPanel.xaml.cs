using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Inspire.Commands;
using Inspire.Interfaces;
using Inspire.Services.WeakEventHandlers;

namespace Inspire.Client.Designer.DesignPropertyPanel
{
    /// <summary>
    /// Interaction logic for CanvasPropertyPanel.xaml
    /// </summary>
    public partial class CanvasPropertyPanel : IWeakEventListener
    {
        public CanvasPropertyPanel()
        {
            InitializeComponent();
            LoadedEventManager.AddListener(this, this);
        }

        private UserControl canvas;

        void CanvasPropertyPanel_Loaded(object sender, EventArgs e)
        {
            SetDataContext();
        }

        public void SetDataContext()
        {
            canvas = InspireApp.CurrentDragCanvas;

            if (canvas != null)
            {
                DataContext = canvas;
                canvasBackgroundButton.Fill = canvas.Background;
            }
        }

        private void ChangeBackgroundColor_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (canvas != null)
            {
                ColorPickerDialog cPicker = new ColorPickerDialog();

                SolidColorBrush fontBrush = (SolidColorBrush) canvas.Background;

                cPicker.StartingColor = fontBrush.Color;
                //cPicker.Owner = this;

                bool? dialogResult = cPicker.ShowDialog();
                if (dialogResult != null && (bool) dialogResult)
                {

                    SolidColorBrush bgColor = new SolidColorBrush(cPicker.SelectedColor);

                    var command = new ChangeCanvasBackground(canvas, fontBrush,
                                                             bgColor);

                    if (((IDragCanvas) canvas).UndoService != null)
                    {
                        ((IDragCanvas) canvas).UndoService.Execute(command);
                    }
                    else
                    {
                        command.Execute();
                        canvasBackgroundButton.Fill = canvas.Background;
                    }


                    canvasBackgroundButton.Fill = canvas.Background;
                }
            }
            e.Handled = true;
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LoadedEventManager))
            {
                CanvasPropertyPanel_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion
    }
}
