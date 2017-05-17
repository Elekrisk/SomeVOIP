using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeVOIPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void SetupServer(Int32 Port)
        {
            TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), Port);
            
        }
    }

    public static class Variables
    {
        public static Int32 Port;
        public static List<Channel> Channels;
    }

    public class Worker
    {
        
    }

    public class Listener
    {
        public TcpListener listener;
        public Listener(TcpListener l)
        {
            listener = l;
        }

        public void Listen(Int32 Port)
        {
            TcpClient c = listener.AcceptTcpClient();
        }
    }

    public class Channel
    {
        public string Name;
        List<Client> Clients;

        public Channel(string name)
        {
            Name = name;
        }
    }

    public class Client
    {
        TcpClient Voice;
        TcpClient Text;
        Channel currentChannel;
        string Nickname;

        public Client(TcpClient v, TcpClient t)
        {
            Voice = v;
            Text = t;
        }

        public bool SendMessage(string message)
        {
            try
            {
                NetworkStream n = Text.GetStream();
                byte[] bytes = new byte[message.Length];
                bytes = Encoding.ASCII.GetBytes(message);
                n.Write(bytes, 0, bytes.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetChannel(Channel c)
        {
            currentChannel = c;
        }

        public Channel GetChannel()
        {
            return currentChannel;
        }
    }
}
