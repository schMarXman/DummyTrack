using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyTrack
{
    class LogHandler
    {
        private TextBox box;
        public LogHandler(TextBox lb)
        {
            box = lb;
        }

        private void AddToLog(String text)
        {
                box.AppendText(GetTimestamp(DateTime.Now) + text + Environment.NewLine);
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("[HH:mm:ss] ");
        }

        public void NotifyStart(string ip, int port)
        {
            AddToLog("");
            AddToLog("Socket started. Sending Packages to " + ip + ":" + port);
        }

        public void AddMessage(string mes)
        {
            AddToLog(mes);
        }

        public void NotifyStop()
        {
            AddToLog("Socket stopped.");
        }

        public void NotifyJam(int port)
        {
            AddToLog("Jamming whole network on port " + port);
        }

        public TextBox GetBox()
        {
            return box;
        }
    }
}
