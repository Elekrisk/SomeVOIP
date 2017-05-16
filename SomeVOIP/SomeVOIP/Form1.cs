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
            TcpClient client = new TcpClient();
            client.Connect(Address, Port);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] ss = textBox4.Text.Split(':');
            Connect(IPAddress.Parse(ss[0]), Int32.Parse(ss[1]));
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
