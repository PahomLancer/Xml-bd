using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace xml_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const String filename = "xmlfile1.xml";
            const String filename2 = "xmlfile2.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            label1.Text = "xml loaded " + filename;
            XmlNodeList nodelist = doc.GetElementsByTagName("book");
            label2.Text = "nodelist count: " + nodelist.Count;
            richTextBox1.Text = "";
            foreach (XmlNode node in nodelist)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    richTextBox1.Text = richTextBox1.Text + "attribute " + attribute.Name + " = " + attribute.Value + "\n";
                }
                XmlDocument doc2 = new XmlDocument();
                XmlNodeList nodelist2 = node.SelectNodes("description");
                foreach (XmlNode selNode in nodelist2)
                {
                    richTextBox1.Text = richTextBox1.Text + "value of description is " + selNode.InnerXml + "\n";
                }
                if (node.PreviousSibling != null)
                {
                    richTextBox1.Text = richTextBox1.Text + "node.PreviousSibling is tag " + node.PreviousSibling.Name + "\n";
                }
                if (node.NextSibling != null)
                {
                    richTextBox1.Text = richTextBox1.Text + "node.NextSibling is tag " + node.NextSibling.Name + "\n";
                }
                richTextBox1.Text = richTextBox1.Text + "\n";
                node.RemoveChild(nodelist2[0]);
                XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "description2", "");
                XmlAttribute newAttr = doc.CreateAttribute("Att1");
                newAttr.Value = "value";
                newNode.Attributes.Append(newAttr);
                XmlNode newNode2 = doc.CreateNode(XmlNodeType.Element, "description3", "");
                newNode2.InnerText = "value2";
                newNode.AppendChild(newNode2);
                node.AppendChild(newNode);
            }
            doc.Save(filename2);
        }
    }
}
