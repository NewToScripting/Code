using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using Inspire;
using Inspire.Common.MediaObjects;
using Inspire.Interfaces;
using Inspire.MediaObjects;

namespace RichTextModule
{
    public class DesignRichTextModule : MediaModule, IMediaModule
    {

        public DesignContentControl Execute(double canvasWidth, double canvasHeight)
        {
            DesignTextBox richTextBox = new DesignTextBox();

            richTextBox.Margin = new Thickness(15);

            // Create a FlowDocument to contain content for the RichTextBox.
            FlowDocument myFlowDoc = new FlowDocument();

            myFlowDoc.FontSize = 30;
            myFlowDoc.TextAlignment = TextAlignment.Center;

            Bold myBold = new Bold(new Run("Edit me!"));

            // Create a paragraph and add the Run and Bold to it.
            Paragraph myParagraph = new Paragraph();
            myParagraph.Inlines.Add(myBold);

            // Add the paragraph to the FlowDocument.
            myFlowDoc.Blocks.Add(myParagraph);

            //Paragraph paragraph = new Paragraph();
            //paragraph.FontSize = 30;
            //paragraph.TextAlignment = TextAlignment.Center;
            //paragraph.Inlines.Add(new Run("Enter Text Here"));

            richTextBox.Document = myFlowDoc;
            richTextBox.SnapsToDevicePixels = true;
            richTextBox.Background = Brushes.Transparent;
            richTextBox.SpellCheck.IsEnabled = true;
            richTextBox.Foreground = Brushes.Black;
            richTextBox.BorderThickness = new Thickness(0);
           

            DesignContentControl contentControl = new DesignContentControl();

            contentControl.Tag = "TextBox";
            contentControl.Content = richTextBox;
            contentControl.Width = 230;
            contentControl.Height = 165;

            // Mark as Copyable so that the control can be copied and pasted.
            contentControl.IsCopyable = true;

            // Mark as Rotatable so this control can be rotated. Only Interop Controls Cannot be rotated.
            contentControl.IsRotatable = true;
            
            return contentControl;
        }

        public DesignContentControl EditControl(DesignContentControl designContentControl)
        {
            throw new System.NotImplementedException();
        }


        public MediaType GetModuleType()
        {
            return MediaType.RichText;
        }

        public string GetModuleName()
        {
            return "RichText";
        }

        public List<string> GetSupportedFileTypes()
        {
            return null;
        }

        public DesignContentControl CreateContentControl(string fileName)
        {
            return null;
        }

        public string CreatePlayerControl(DesignContentControl designContentControl, string guid)
        {
            string stringControl;
            DesignTextBox designTextBox = (DesignTextBox)designContentControl.Content;
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.BorderThickness = new Thickness(0);
            richTextBox.Background = Brushes.Transparent;
            richTextBox.IsHitTestVisible = false;
            richTextBox.Margin = new Thickness(15);

            TextRange sourceDocument = new TextRange(designTextBox.Document.ContentStart, designTextBox.Document.ContentEnd);
            MemoryStream stream = new MemoryStream();
            sourceDocument.Save(stream, DataFormats.Xaml);            // Clone the source document's content into a new FlowDocument.            

            TextRange copyDocumentRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            copyDocumentRange.Load(stream, DataFormats.Xaml);

            designContentControl.Content = richTextBox;
            designContentControl.IsNew = false;

            stringControl = XamlWriter.Save(designContentControl);

            designContentControl.Content = designTextBox;
            return stringControl;
        }

        public DesignContentControl CreateClientControl(DesignContentControl designContentControl)
        {
            RichTextBox designTextBox = (RichTextBox)designContentControl.Content;
            DesignTextBox richTextBox = new DesignTextBox();
            richTextBox.BorderThickness = new Thickness(0);
            richTextBox.Background = Brushes.Transparent;
            richTextBox.Margin = new Thickness(15);
            richTextBox.IsHitTestVisible = true;

            TextRange sourceDocument = new TextRange(designTextBox.Document.ContentStart, designTextBox.Document.ContentEnd);
            MemoryStream stream = new MemoryStream();
            sourceDocument.Save(stream, DataFormats.Xaml);            // Clone the source document's content into a new FlowDocument.            

            TextRange copyDocumentRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            copyDocumentRange.Load(stream, DataFormats.Xaml);

            designContentControl.Content = richTextBox;

            return designContentControl;
        }

        #region IMediaModule Members


        public void PlayControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            designContentControl.IsHitTestVisible = false;
            RichTextBox designTextBox = (RichTextBox)designContentControl.Content;
            DesignTextBox richTextBox = new DesignTextBox();
            richTextBox.BorderThickness = new Thickness(0);
            richTextBox.Margin = new Thickness(15);
            richTextBox.Background = Brushes.Transparent;
            richTextBox.IsHitTestVisible = false;

            TextRange sourceDocument = new TextRange(designTextBox.Document.ContentStart, designTextBox.Document.ContentEnd);
            MemoryStream stream = new MemoryStream();
            sourceDocument.Save(stream, DataFormats.Xaml);            // Clone the source document's content into a new FlowDocument.            

            TextRange copyDocumentRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            copyDocumentRange.Load(stream, DataFormats.Xaml);

            designContentControl.Content = richTextBox;
        }

        public void StopControl(DesignContentControl designContentControl, string _playbackFolder, string _displayGuid)
        {
            RichTextBox richTextBox = designContentControl.Content as RichTextBox;
            if (richTextBox != null) richTextBox.IsHitTestVisible = true;
            designContentControl.IsHitTestVisible = true;
        }

        public void Dispose(DesignContentControl designContentControl)
        {

        }

        public UserControl GetPropertyPanel()
        {
            return new PropertyPanel();
        }

        #endregion

        #region IMediaModule Members


        public bool GetIsPanelModule()
        {
            return true;
        }

        #endregion
    }
}
