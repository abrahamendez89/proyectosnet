using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnviarMailCorcega
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String base64File;
        String fileName;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    Byte[] bytes = File.ReadAllBytes(file);
                    base64File = Convert.ToBase64String(bytes);
                    txtArchivo.Text = openFileDialog1.FileName; 
                    fileName = Path.GetFileName(openFileDialog1.FileName); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        private void SendMailCorcega()
        { 
             WebClient wc = new WebClient();
        wc.Headers.Add("Content-Type", "application/json");
            wc.Encoding = System.Text.Encoding.UTF8;
            
            try
            {
                String bodyStr = "";
                if (txtArchivo.Text.Equals(""))
                {
                    bodyStr = "{\"mensaje\": \"@mensaje\"}".Replace("@mensaje", txtMensaje.Text);
                }
                else
                {
                    bodyStr = "{\"mensaje\": \"@mensaje\", \"archivo\": \"@archivoName\", \"archivoBase64\": \"@archivoB64\"}".Replace("@mensaje", txtMensaje.Text).Replace("@archivoName", fileName).Replace("@archivoB64", base64File);
                }
                byte[] data = Encoding.UTF8.GetBytes(bodyStr);
                var response = wc.UploadData("http://104.131.146.48:3000/difusionEnviar", "POST", data);
                MessageBox.Show(response.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            SendMailCorcega();
        }
    }
}
