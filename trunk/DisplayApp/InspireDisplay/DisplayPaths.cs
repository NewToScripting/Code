using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows.Forms;
using Inspire;

namespace InspireDisplay
{
    public class DisplayPaths
    {
        

        public static void CreateDirectories()
        {
            try
            {
                // make sure all the app directories exist
                if (!Directory.Exists(Paths.PlayerSlideDirectory))
                {
                    Directory.CreateDirectory(Paths.PlayerSlideDirectory);
                }

                if (!Directory.Exists(Paths.PlayerDefaultSlideDirectory))
                {
                    Directory.CreateDirectory(Paths.PlayerDefaultSlideDirectory);
                }

                if (!File.Exists(Paths.PlayerDefaultSlideDirectory + @"\" + "DefaultSlide.xml"))
                {
                    CreateDefaultSlide();
                }
                if (!Directory.Exists(Paths.ApplicationDirectory + @"\" + "DefaultLogo"))
                {
                    Directory.CreateDirectory(Paths.ApplicationDirectory + @"\" + "DefaultLogo");
                }

            }
            catch (Exception ex)
            {
                ;
            }
        }

        private static void CreateDefaultSlide()
        {
            //FlowDocument inspireDoc = new FlowDocument();
            //inspireDoc.PagePadding = new Thickness(5, 0, 5, 0);
            //inspireDoc.TextAlignment = TextAlignment.Center;
            //inspireDoc.PageWidth = 1022;
            //inspireDoc.FontFamily = new FontFamily("Mistral");
            //inspireDoc.FontSize = 100;
            //Paragraph block = new Paragraph(new Run("Inspire Digital Displays"));
            //inspireDoc.Blocks.Add(block);

            //FlowDocumentReader inspireDocReader = new FlowDocumentReader();
            //inspireDocReader.Document = inspireDoc;
            //string contentXaml = XamlWriter.Save(inspireDocReader.Document);

            //XElement defaultSlide = new XElement("Root",
            //                                     new XElement("DesignCanvas",
            //                                                  new XElement("BackGround", "#FFFFFFFF")),
            //                                     new XElement("DesignImages"),
            //                                     new XElement("DesignVideos"),
            //                                     new XElement("DesignTextBoxes",
            //                                                  new XElement("DesignTextBox",
            //                                                               new XElement("Left", "0"),
            //                                                               new XElement("Top", "301"),
            //                                                               new XElement("Width", "1024"),
            //                                                               new XElement("Height", "372"),
            //                                                               new XElement("GUID", "DefaultSlide"),
            //                                                               new XElement("zIndex", "0"),
            //                                                               new XElement("Name", "RichTextBox 1"),
            //                                                               new XElement("Document", contentXaml),
            //                                                               new XElement("Angle", "0"),
            //                                                               new XElement("CenterX", "0"),
            //                                                               new XElement("CenterY", "0"))),
            //                                     new XElement("DesignScrollText"),
            //                                     new XElement("DesignReflections"));

            //defaultSlide.Save(DisplayPaths.DefaultSlideDirectory + @"\" + "DefaultSlide.xml");

        }

    }
}
