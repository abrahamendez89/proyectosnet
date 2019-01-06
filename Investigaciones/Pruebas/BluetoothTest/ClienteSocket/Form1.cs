using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClienteSocket
{
    public partial class Form1 : Form
    {
        TcpClient clientSocket = new TcpClient();
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Load += Form1_Load;
            //clientSocket.Connect("127.0.0.1", 8888);
        }
        public void msg(string mesg)
        {

            lb_delServer.Items.Add(textBox1.Text +" >> " + mesg);

        } 
        void Form1_Load(object sender, EventArgs e)
        {
            msg("Client Started");
            Thread t = new Thread(BuscarServer);
            t.Start();
        }
        private Boolean encontrado = false;
        private void IntentarConectar(object ipt)
        {
            String ip = (String)ipt;
            try
            {
                lb_delServer.Items.Add("Probando ip: " + ip);
                lb_delServer.SelectedIndex = lb_delServer.Items.Count - 1;
                TcpClient clientSocket = new TcpClient(ip, 8889);
                encontrado = true;
            }
            catch { }
        }
        private void BuscarServer()
        {
            for (int i = 0; i < 255; i++)
            {
                String ip = "192.168.1." + i;
                Thread intento = new Thread(IntentarConectar);
                intento.Start(ip);
                Thread.Sleep(300);
                if (encontrado)
                {
                    if(intento.ThreadState != ThreadState.Stopped)
                        intento.Abort();
                    clientSocket.Connect(ip, 8888);
                    lb_delServer.Items.Add("Client Socket Program - Server Connected ip: " + ip + " ...");

                    break;
                }
                    
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox1.Text + "$");

            serverStream.Write(outStream, 0, outStream.Length);

            serverStream.Flush();

            //byte[] inStream = new byte[10025];

            //serverStream.Read(inStream, 0, inStream.Length);

            //string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            //msg(returndata);

            //textBox1.Text = "";

            textBox1.Focus();
        }
    }
}
