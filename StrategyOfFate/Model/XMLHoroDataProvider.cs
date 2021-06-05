using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace StrategyOfFate
{
    public class XMLHoroDataProvider : IHoroDataProvider
    {

        private XmlDocument xmlDoc;

        public XMLHoroDataProvider()
        {
            var assembly = Assembly.GetExecutingAssembly();

            //System.Windows.MessageBox.Show(string.Join(",", assembly.GetManifestResourceNames()));

            var resourceName = "StrategyOfFate.Data.Data.xml";

            string xmlText;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                xmlText = reader.ReadToEnd();
            }

            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlText);

        }

        public SignInformation GetSignInformation(Horoscope horoscope)
        {
            var sInfo = new SignInformation();
            var pList = new List<SignParagraph>();
            var bDate = Properties.Settings.Default.BirthDate;
            foreach (XmlNode horoNode in xmlDoc.DocumentElement.ChildNodes)
            {
                if (horoNode.Attributes["Id"].Value == horoscope.Id)
                {
                    foreach (XmlNode signNode in horoNode.ChildNodes)
                    {
                        var attrDict = new Dictionary<string, string>();
                        foreach (XmlAttribute attr in signNode.Attributes)
                        {
                            attrDict[attr.Name] = attr.Value;
                        }
                        if (horoscope.IsSignMatchesDate (attrDict , bDate))
                        {
                            sInfo.Name = attrDict["Name"];
                            foreach (XmlNode sectionNode in signNode.ChildNodes)
                            {
                                var tmpSP = new SignParagraph(sectionNode.Attributes["Title"].Value, sectionNode.InnerText);
                                pList.Add(tmpSP);
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            sInfo.Paragraphs = pList.ToArray();
            return sInfo;
        }
    }
}
