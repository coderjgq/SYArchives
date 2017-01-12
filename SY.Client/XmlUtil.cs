using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace SY.Client
{
    class XmlUtil
    {
        public static List<string> GetReminders(string reminder)
        {
            XmlNodeList list = SelectNodes(reminder, "/root/reminder");
            List<string> ret = new List<string>();
            foreach (XmlNode node in list)
            {
                ret.Add(node.InnerText);
            }
            return ret;
        }

        public static string GetReminderXml(List<string> reminders)
        {
            string xml = "";
            for (int i = 0; i < reminders.Count; i++)
            {
                string reminder = reminders[i];
                xml = AddReminderToXml(xml, reminder);
            }
            return xml;
        }

        public static string AddReminderToXml(string xml, string reminder)
        {
            return AppendChild(xml, "reminder", reminder);
        }

        //***********************************   <无业务逻辑>   *********************************

        public static XmlNode SelectFirstNode(string xml, string xmlPath)
        {
            if (xml == null)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            XmlNodeList listNodes = listNodes = root.SelectNodes(xmlPath);
            return listNodes[0];
        }

        public static XmlNode SelectFirstNode(XmlReader xml, string xmlPath)
        {
            if (xml == null)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlElement root = doc.DocumentElement;
            XmlNodeList listNodes = listNodes = root.SelectNodes(xmlPath);
            return listNodes[0];
        }

        public static XmlNodeList SelectNodes(XmlReader xml, string xmlPath)
        {
            if (xml == null)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlElement root = doc.DocumentElement;
            XmlNodeList listNodes = listNodes = root.SelectNodes(xmlPath);
            return listNodes;
        }

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
                node.InnerXml =  value;
                root.AppendChild(node);
                return doc.InnerXml;
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("root");
                doc.AppendChild(root);
                XmlElement node = doc.CreateElement(nodeName);
                node.InnerXml = value;
                root.AppendChild(node);
                return doc.InnerXml;
            }
        }

        public static string FormatXml(string sUnformattedXml)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(sUnformattedXml);
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlTextWriter xtw = null;
            try
            {
                xtw = new XmlTextWriter(sw);
                xtw.Formatting = Formatting.Indented;
                xtw.Indentation = 1;
                xtw.IndentChar = '\t';
                xd.WriteTo(xtw);
            }
            finally
            {
                if (xtw != null)
                    xtw.Close();
            }
            return sb.ToString();
        }  

    }
}
