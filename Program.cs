using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyTrack
{
    static class Program
    {
       
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DummyTrack());
        }

        //public void StartSocket()
        //{
        //    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //    IPAddress serverAddr = IPAddress.Parse("192.168.2.255");

        //    IPEndPoint endPoint = new IPEndPoint(serverAddr, 11000);

        //    string text = "Hello";
        //    byte[] send_buffer = Encoding.ASCII.GetBytes(text);

        //    sock.SendTo(send_buffer, endPoint);
        //}

       
    }
}
