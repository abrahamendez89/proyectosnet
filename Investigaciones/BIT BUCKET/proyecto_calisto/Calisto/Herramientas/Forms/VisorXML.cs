using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Herramientas.Forms
{
    public partial class VisorXML : Form
    {
        public VisorXML(String xml)
        {
            InitializeComponent();
            //create a random temporary file with an .xml file extension

            var path = Path.GetTempPath();
            var fileName = Guid.NewGuid().ToString() + ".xml";
            var fullFileName = Path.Combine(path, fileName);
            //write the contents of your xml string to the temporary file we just created
            File.WriteAllText(fullFileName, xml); //xmlText is your xml string
            //"navigate" to the file
            web.Navigate(fullFileName); //webBrowser is your WebBrowser control
        }
    }
}
