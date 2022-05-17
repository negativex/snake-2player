using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Snake
{
    class PVP
    {
        private static TcpClient tcpClient;
        private static StreamWriter sWriter;
        private static Thread clientthread;
        private static int svport = 8888;
        private static bool stopclient = true;
        private static int en = 1;
        //private static string user_name_ = "Pseudo";
        public static int pl_num_pvp;
        public static string pl_name_pvp;
        public static string iph_pvp;
        //public ListViewItem list = new ListViewItem("item1", 0);
        
        public static void ClientRecv()
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (!stopclient)
                {
                    Application.DoEvents();
                    string data = sr.ReadLine();
                    //UpdateChatHistoryThreadSafe($"{data}\n");
                }
            }
            catch (SocketException)
            {
                tcpClient.Close();
                sr.Close();

            }
        }

        public delegate void SafeCallDelegate(string text);


        public static void sendinnw()
        {
            try

            {
                if (Input.KeyPressed(Keys.A) && en != 1) { sWriter.WriteLine('J'); en = 1; }
                else if (Input.KeyPressed(Keys.D) && en != 2) { sWriter.WriteLine('L'); en = 2; }
                else if (Input.KeyPressed(Keys.S) && en != 3) { sWriter.WriteLine('K'); en = 3; }
                else if (Input.KeyPressed(Keys.W) && en != 4) { sWriter.WriteLine('I'); en = 4; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void endgame()
        {
            try
            {
                sWriter.WriteLine("Ket thuc,");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static int getplayer_num()
        {
            int num = 0;
            return num;
        }
        public static void Startnetwork()
        {
            try
            {
                stopclient = false;

                tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), svport));
                sWriter = new StreamWriter(tcpClient.GetStream());
                sWriter.AutoFlush = true;
                sWriter.WriteLine(pl_name_pvp);
                clientthread = new Thread(ClientRecv);
                clientthread.Start();
                //Timer1.Interval = 10;
                //timer1.Tick += sendinnw;
                //timer1.Start();
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show(sockEx.Message, "Network error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
