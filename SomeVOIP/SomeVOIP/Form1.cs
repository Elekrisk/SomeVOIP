using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeVOIP
{
    public partial class Form1 : Form
    {
        public bool mute = false;
        public bool deafen = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void Connect(IPAddress Address, Int32 Port)
        {
            DisplayMessage("Connecting to " + Address + ":" + Port);
            DisplayMessage("The program will now not respond until a connection has been made or has failed.");

            TcpClient client = new TcpClient();
            try
            {
                client.Connect(Address, Port);
                DisplayMessage("Connected to " + Address + ":" + Port);
            }
            catch (System.Exception e)
            {
                DisplayMessage(e.Message);
            }
        }

        public void DisplayMessage(string s)
        {
            textBox5.Text += s + Environment.NewLine;
            textBox5.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] ss = textBox4.Text.Split(':');
            if (ss.Length > 0)
            {
                if (ss.Length < 2)
                {
                    string[] sss = new string[2];
                    sss[0] = ss[0];
                    sss[1] = "4754";
                    ss = sss;
                }
                Connect(IPAddress.Parse(ss[0]), Int32.Parse(ss[1]));
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public static class Variables
    {
        public static IPAddress serverAddress;
        public static Int32 ServerPort;

        public static TcpListener audioSocket;
        public static TcpListener textSocket;
    }
}
