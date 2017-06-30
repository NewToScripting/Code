using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;

namespace InspireDisplay
{
    class Deserializer
    {

        //#region Deserialize DesignImage

        //public static MediaObjects.DesignImage DeserializeDesignerImage(XElement itemXML, string guid, double OffsetX, double OffsetY)
        //{
        //    MediaObjects.DesignImage item = new MediaObjects.DesignImage(guid);
        //    item.Width = Double.Parse(itemXML.Element("Width").Value, CultureInfo.InvariantCulture);
        //    item.Height = Double.Parse(itemXML.Element("Height").Value, CultureInfo.InvariantCulture);
        //    Canvas.SetLeft(item, Double.Parse(itemXML.Element("Left").Value, CultureInfo.InvariantCulture) + OffsetX);
        //    Canvas.SetTop(item, Double.Parse(itemXML.Element("Top").Value, CultureInfo.InvariantCulture) + OffsetY);
        //    Canvas.SetZIndex(item, Int32.Parse(itemXML.Element("zIndex").Value));
        //    item.Name = itemXML.Element("Name").Value;
        //    item.FileExtension = Path.GetExtension(itemXML.Element("FileName").Value);
        //    item.RotateTransform = new RotateTransform(Double.Parse(itemXML.Element("Angle").Value, CultureInfo.InvariantCulture), Double.Parse(itemXML.Element("CenterX").Value, CultureInfo.InvariantCulture), Double.Parse(itemXML.Element("CenterY").Value, CultureInfo.InvariantCulture));
        //    return item;
        //}
        //#endregion

        //#region Deserialize DesignVideo

        //public static MediaObjects.DesignVideo DeserializeDesignerVideo(XElement itemXML, string guid, double OffsetX, double OffsetY)
        //{
        //    MediaObjects.DesignVideo item = new MediaObjects.DesignVideo(guid);
        //    item.Width = Double.Parse(itemXML.Element("Width").Value, CultureInfo.InvariantCulture);
        //    item.Height = Double.Parse(itemXML.Element("Height").Value, CultureInfo.InvariantCulture);
        //    Canvas.SetLeft(item, Double.Parse(itemXML.Element("Left").Value, CultureInfo.InvariantCulture) + OffsetX);
        //    Canvas.SetTop(item, Double.Parse(itemXML.Element("Top").Value, CultureInfo.InvariantCulture) + OffsetY);
        //    Canvas.SetZIndex(item, Int32.Parse(itemXML.Element("zIndex").Value));
        //    item.Name = itemXML.Element("Name").Value;
        //    item.FileExtension = Path.GetExtension(itemXML.Element("FileName").Value);
        //    item.RotateTransform = new RotateTransform(Double.Parse(itemXML.Element("Angle").Value, CultureInfo.InvariantCulture), Double.Parse(itemXML.Element("CenterX").Value, CultureInfo.InvariantCulture), Double.Parse(itemXML.Element("CenterY").Value, CultureInfo.InvariantCulture));
        //    return item;
        //}
        //#endregion

        //#region Deserialize DesignTextBox

        //public static MediaObjects.DesignTextBox DeserializeDesignerTextBox(XElement itemXML, string guid, double OffsetX, double OffsetY)
        //{
        //    MediaObjects.DesignTextBox item = new MediaObjects.DesignTextBox(guid);
        //    item.Width = Double.Parse(itemXML.Element("Width").Value, CultureInfo.InvariantCulture);
        //    item.Height = Double.Parse(itemXML.Element("Height").Value, CultureInfo.InvariantCulture);
        //    Canvas.SetLeft(item, Double.Parse(itemXML.Element("Left").Value, CultureInfo.InvariantCulture) + OffsetX);
        //    Canvas.SetTop(item, Double.Parse(itemXML.Element("Top").Value, CultureInfo.InvariantCulture) + OffsetY);
        //    Canvas.SetZIndex(item, Int32.Parse(itemXML.Element("zIndex").Value));
        //    item.Name = itemXML.Element("Name").Value;
        //    FlowDocument document = (FlowDocument)XamlReader.Load(XmlReader.Create(new StringReader(itemXML.Element("Document").Value)));
        //    item.Document = document;
        //    item.RotateTransform = new RotateTransform(Double.Parse(itemXML.Element("Angle").Value, CultureInfo.InvariantCulture), Double.Parse(itemXML.Element("CenterX").Value, CultureInfo.InvariantCulture), Double.Parse(itemXML.Element("CenterY").Value, CultureInfo.InvariantCulture));
        //    return item;
        //}
        //#endregion

        //#region Deserialize DesignScrollText
        //public static MediaObjects.DesignScrollText DeserializeDesignerScrollText(XElement itemXML, string slideguid, string guid, double OffsetX, double OffsetY)
        //{
        //    MediaObjects.DesignScrollText item = new MediaObjects.DesignScrollText(guid);
        //    item.Width = Double.Parse(itemXML.Element("Width").Value, CultureInfo.InvariantCulture);
        //    item.Height = Double.Parse(itemXML.Element("Height").Value, CultureInfo.InvariantCulture);
        //    Canvas.SetLeft(item, Double.Parse(itemXML.Element("Left").Value, CultureInfo.InvariantCulture) + OffsetX);
        //    Canvas.SetTop(item, Double.Parse(itemXML.Element("Top").Value, CultureInfo.InvariantCulture) + OffsetY);
        //    Canvas.SetZIndex(item, Int32.Parse(itemXML.Element("zIndex").Value));
        //    item.Name = itemXML.Element("Name").Value;

        //    // Get the xml from the Folder and load the scroll items
        //    //  TODO: Really need to serialize the objects in the DesignerScrollTextItem instead
        //    XElement scrollItems = XElement.Load(DisplayPaths.SlideDirectory + @"\" + slideguid + @"\" + guid + @"\" + "ScrollItems.xml");

        //    IEnumerable<XElement> scrollitemsXML = scrollItems.Elements();
        //    foreach (XElement scrollitemXML in scrollitemsXML)
        //    {
        //        switch (scrollitemXML.Name.ToString())
        //        {
        //            case ("ScrollImage"):
        //                {
        //                    Image image = new Image();
        //                    BitmapFrame imgsource = BitmapFrame.Create(new Uri(DisplayPaths.SlideDirectory + @"\" + slideguid + @"\" + guid + @"\" + scrollitemXML.Element("FileName").Value, UriKind.RelativeOrAbsolute));
        //                    image.Source = imgsource;
        //                    // TODO: Hard Coding for now take out when we hook this up
        //                    image.Height = 40;
        //                    item.scrollItems.Items.Add(image);
        //                    break;
        //                }
        //            case ("ScrollMedia"):
        //                {
        //                    MediaElement mediaelement = new MediaElement();
        //                    mediaelement.Source = new Uri((DisplayPaths.SlideDirectory + @"\" + slideguid + @"\" + guid + @"\" + scrollitemXML.Element("FileName").Value), UriKind.RelativeOrAbsolute);
        //                    // TODO: Hard Coding for now take out when we hook this up
        //                    mediaelement.Height = 40;
        //                    item.scrollItems.Items.Add(mediaelement);
        //                    break;
        //                }
        //            case ("ScrollText"):
        //                {
        //                    TextBlock textblock = new TextBlock();
        //                    textblock.FontSize = Double.Parse(scrollitemXML.Element("FontSize").Value, CultureInfo.InvariantCulture);
        //                    // TODO: Hard Coding for now take out when we hook this up
        //                    textblock.FontSize = 30;
        //                    //textblock.FontFamily = new FontFamily(scrollitemXML.Element("FontFamily").Value);
        //                    // textblock.Foreground = new SolidColorBrush(Color.scrollitemXML.Element("FontColor").Value);
        //                    textblock.Text = scrollitemXML.Element("Text").Value;
        //                    item.scrollItems.Items.Add(textblock);
        //                    break;
        //                }
        //            default:
        //                break;
        //        }
        //    }

        //    return item;
        //}
        //#endregion

        //#region Deserialize DesignReflection

        //public static MediaObjects.DesignReflection DeserializeDesignerReflection(XElement itemXML, string guid, double OffsetX, double OffsetY)
        //{
        //    MediaObjects.DesignReflection item = new MediaObjects.DesignReflection(guid);
        //    item.Width = Double.Parse(itemXML.Element("Width").Value, CultureInfo.InvariantCulture);
        //    item.Height = Double.Parse(itemXML.Element("Height").Value, CultureInfo.InvariantCulture);
        //    Canvas.SetLeft(item, Double.Parse(itemXML.Element("Left").Value, CultureInfo.InvariantCulture) + OffsetX);
        //    Canvas.SetTop(item, Double.Parse(itemXML.Element("Top").Value, CultureInfo.InvariantCulture) + OffsetY);
        //    Canvas.SetZIndex(item, Int32.Parse(itemXML.Element("zIndex").Value));
        //    item.TargetGuid = itemXML.Element("TargetGuid").Value;
        //    return item;
        //}
        //#endregion

        //#region Deserialize DesignWebControl

        //public static MediaObjects.DesignWebControl DeserializeDesignerWebControl(XElement itemXML, string guid, double OffsetX, double OffsetY)
        //{
        //    MediaObjects.DesignWebControl item = new MediaObjects.DesignWebControl(guid);
        //    item.Width = Double.Parse(itemXML.Element("Width").Value, CultureInfo.InvariantCulture);
        //    item.Height = Double.Parse(itemXML.Element("Height").Value, CultureInfo.InvariantCulture);
        //    Canvas.SetLeft(item, Double.Parse(itemXML.Element("Left").Value, CultureInfo.InvariantCulture) + OffsetX);
        //    Canvas.SetTop(item, Double.Parse(itemXML.Element("Top").Value, CultureInfo.InvariantCulture) + OffsetY);
        //    item.LeftScroll = Int32.Parse(itemXML.Element("ScrollLeft").Value, CultureInfo.InvariantCulture);
        //    item.TopScroll = Int32.Parse(itemXML.Element("ScrollTop").Value, CultureInfo.InvariantCulture);
        //    Canvas.SetZIndex(item, Int32.Parse(itemXML.Element("zIndex").Value));
        //    item.Name = itemXML.Element("Name").Value;
        //    item.URL = new Uri(itemXML.Element("URL").Value, UriKind.RelativeOrAbsolute);
        //    return item;
        //}
        //#endregion

    }
}
