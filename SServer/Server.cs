using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace SServer
{
    public partial class Server : Form
    {
        private Thread listenthread;
        private TcpListener tcpListener;
        private bool stopapp = true;
        private readonly int Port = 8888;
        private int Pl_count = 0;
        private Dictionary<string, TcpClient> dictiona = new Dictionary<string, TcpClient>();
        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            if (stopapp)
            {
                stopapp = false;
                listenthread = new Thread(this.Listen);
                listenthread.Start();
                maintxt.Text += @"Start listening for incoming connections" + Environment.NewLine;
            }
        }
        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port));
                tcpListener.Start();

                while (!stopapp)
                {
                    //Application.DoEvents();
                    TcpClient clientt = tcpListener.AcceptTcpClient();
                    StreamReader sr = new StreamReader(clientt.GetStream());
                    StreamWriter sw = new StreamWriter(clientt.GetStream());
                    sw.AutoFlush = true;
                    string username = sr.ReadLine();
                    if (username == null)
                    {
                        sw.WriteLine("Please pick a username");
                    }
                    else
                    {
                        if (!dictiona.ContainsKey(username))
                        {
                            Thread clientThread = new Thread(() => this.recive(username, clientt));
                            dictiona.Add(username, clientt);
                            clientThread.Start();
                            Updateuserjoin(username);
                        }
                        else
                        {
                            sw.WriteLine("Username already exist, pick another one");
                        }
                    }

                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void recive(string username, TcpClient tcpClient)
        {

            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (!stopapp)
                {
                    Application.DoEvents();
                    string msg = sr.ReadLine();
                    string formattedMsg = $"{msg}" + Environment.NewLine;
                    foreach (TcpClient otherClient in dictiona.Values)
                    {
                        StreamWriter sw = new StreamWriter(otherClient.GetStream());
                        sw.WriteLine(formattedMsg);
                        sw.AutoFlush = true;
                    }
                    updatechattheardsafe(formattedMsg);
                }
            }
            catch (SocketException)
            {
                tcpClient.Close();
                sr.Close();

            }

        }
        private delegate void SafeCallDelegate(string text);

        private void updatechattheardsafe(string text)
        {
            if (maintxt.InvokeRequired)
            {
                var d = new SafeCallDelegate(updatechattheardsafe);
                maintxt.Invoke(d, new object[] { text });
            }
            else
            {
                maintxt.Text += text;
            }
        }
        private void Updateuserjoin(string text)
        {
            Pl_count++;
            if (maintxt.InvokeRequired)
            {
                var d = new SafeCallDelegate(Updateuserjoin);
                maintxt.Invoke(d, new object[] { text });
            }
            else
            {
                maintxt.Text += text + " join the room" + Environment.NewLine;
            }
        }
    }
}
