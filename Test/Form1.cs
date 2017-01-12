using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string xml = XmlUtil.AppendChild("","reminder","helloworld");
            xml = XmlUtil.AppendChild(xml, "reminder", "helloworld1");
            MessageBox.Show(xml);
            XmlNodeList list = XmlUtil.SelectNodes(xml,"/root/reminder");
            foreach (XmlNode node in list)
            {
                Console.WriteLine(node.InnerText);
            }
            //init();
            //initXml(null,null);
        }

        private void test()
        {
            
        }

        private void init()
        {
            string content = "";

            XmlReader xml = XmlReader.Create(@"test.xml");
            
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlElement root = null;
            root = doc.DocumentElement;
            XmlNodeList listNodes = null;
            listNodes = root.SelectNodes("/bookstore/book/price");
            XmlElement node1 = doc.CreateElement("TestNode");//主内容
            node1.InnerText = "testNode";
            root.AppendChild(node1);

            Console.WriteLine(doc.InnerXml);

            
        }

        private void initXml(List<string> content,string nodeName)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement Root = doc.CreateElement("Root");//主内容
            doc.AppendChild(Root);

            XmlElement Child1 = doc.CreateElement("attr1");
            XmlAttribute attr1 = doc.CreateAttribute("attr1");
            attr1.Value = "arrt1Content";
            Root.AppendChild(Child1);
            Console.WriteLine(doc.InnerXml);

        }

    }
}
