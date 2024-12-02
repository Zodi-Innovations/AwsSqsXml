using System;
using System.Xml.Linq;

namespace AwsSqsXml
{
    public class LabelService
    {
        public void UpdateLabelXml(string XmlContent, MessageData messageData)
        {
            try
            {
                XDocument xDocument = XDocument.Load(XmlContent);

                var textObjects = xDocument.Descendants("TextObject");

                foreach (var textObject in textObjects)
                {
                    if (textObject.Element("Name")?.Value == "TextObject0")
                    {
                        textObject.Descendants("FormattedText")
                            .Elements("LineTextSpan")
                            .Elements("TextSpan")
                            .Elements("Text")
                            .FirstOrDefault()?.SetValue($"{messageData.firstname} {messageData.lastname}");
                    }
                    else if (textObject.Element("Name")?.Value == "TextObject1")
                    {
                        textObject.Descendants("FormattedText")
                            .Elements("LineTextSpan")
                            .Elements("TextSpan")
                            .Elements("Text")
                            .FirstOrDefault()?.SetValue($"{messageData.street} {messageData.houseNumber}");
                    }
                    else if (textObject.Element("Name")?.Value == "TextObject2")
                    {
                        textObject.Descendants("FormattedText")
                            .Elements("LineTextSpan")
                            .Elements("TextSpan")
                            .Elements("Text")
                            .FirstOrDefault()?.SetValue($"{messageData.city} {messageData.zip}");
                    }
                    else if (textObject.Element("Name")?.Value == "TextObject3")
                    {
                        textObject.Descendants("FormattedText")
                            .Elements("LineTextSpan")
                            .Elements("TextSpan")
                            .Elements("Text")
                            .FirstOrDefault()?.SetValue($"{messageData.country}");
                    }

                    else if (textObject.Element("Name")?.Value == "TextObject4")
                        textObject.Descendants("FormattedText")
                            .Elements("LineTextSpan")
                            .Elements("TextSpan")
                            .Elements ("Text")
                            .FirstOrDefault()?.SetValue($"{messageData.clubName}" );  
                }
                var qrCodeObjects = xDocument.Descendants("QrCodeObject");
                foreach (var qrCodeObject in qrCodeObjects) 
                    if (qrCodeObject.Element("Name")?.Value == "QRCodeObject0")
                    {
                        qrCodeObject.Descendants("Data")
                            .Elements("DataString")
                            .FirstOrDefault()?.SetValue($"{messageData.uuid}");
                        qrCodeObject.Descendants("TextHolder")
                          .Elements("Value")
                          .FirstOrDefault()?.SetValue($"{messageData.uuid}");
                    }




                xDocument.Save(XmlContent);
                Console.WriteLine("Label XML is succesvol bijgewerkt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het bijwerken van de XML: {ex.Message}");
            }
        }
    }
}
