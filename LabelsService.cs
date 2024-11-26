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
                            .FirstOrDefault()?.SetValue($"{messageData.firstName} {messageData.lastName}");
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
