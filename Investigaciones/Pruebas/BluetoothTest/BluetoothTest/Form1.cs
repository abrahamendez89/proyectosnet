
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BluetoothTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(RunSockets);
            t.Start();
        }

        private void RunSockets()
        {
            TcpListener serverSocket = new TcpListener(8888);

            int requestCount = 0;

            TcpClient clientSocket = default(TcpClient);

            serverSocket.Start();

            lb_mensajes.Items.Add(" >> Server Started");

            clientSocket = serverSocket.AcceptTcpClient();

            lb_mensajes.Items.Add(" >> Accept connection from client");

            requestCount = 0;



            while ((true))
            {

                try
                {

                    requestCount = requestCount + 1;

                    NetworkStream networkStream = clientSocket.GetStream();

                    byte[] bytesFrom = new byte[10025];

                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);

                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);

                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                    lb_mensajes.Items.Add(" >> Data from client - " + dataFromClient);

                    string serverResponse = "Last Message from client" + dataFromClient;

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);

                    networkStream.Write(sendBytes, 0, sendBytes.Length);

                    networkStream.Flush();

                    lb_mensajes.Items.Add(" >> " + serverResponse);

                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());

                }

            }



            clientSocket.Close();

            serverSocket.Stop();

            lb_mensajes.Items.Add(" >> exit");

            Console.ReadLine();
        }
    }
}
