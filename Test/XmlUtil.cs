using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Test
{
    class XmlUtil
    {
        public static XmlNodeList SelectNodes(string xml, string xmlPath)
        {
            if (xml == null || xml.Trim().Equals(""))
            {
                return null;
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            XmlNodeList listNodes = listNodes = root.SelectNodes(xmlPath);

            return listNodes;
        }

        public static string AppendChild(string xml, string nodeName, string value)
        {
            if (xml != null && !xml.Trim().Equals(""))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlElement root = doc.DocumentElement;
                XmlElement node = doc.CreateElement(nodeName);
                node.InnerText = value;
                root.AppendChild(node);
                return doc.InnerXml;
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("root");
                doc.AppendChild(root);
                XmlElement node = doc.CreateElement(nodeName);
                node.InnerText = value;
                root.AppendChild(node);
                return doc.InnerXml;
            }
        }


    }
}
