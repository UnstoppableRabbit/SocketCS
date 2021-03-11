using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketPlayin
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.2.1";
            int port = 1488;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip),port);
            var mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket.Bind(ep);
            mySocket.Listen(10);

            int port1 = 1489;
            IPEndPoint ep1 = new IPEndPoint(IPAddress.Parse(ip), port1);
            var mySocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket1.Bind(ep1);
            mySocket1.Listen(10);
            while (true)
            {
                var listner1 = mySocket1.Accept();
                byte[] buf1 = new byte[1024];
                var listner = mySocket.Accept();
                byte[] buf = new byte[1024];
                var sb = new StringBuilder();
                var sb1 = new StringBuilder();
                do {
                    var size = listner.Receive(buf);
                    sb.Append(Encoding.UTF8.GetString(buf, 0, size));
                   }
                while (listner.Available > 0);
                Console.WriteLine(sb);
                
                do
                {
                    var size = listner1.Receive(buf1);
                    sb1.Append(Encoding.UTF8.GetString(buf1, 0, size));
                }
                while (listner1.Available > 0);
                Console.WriteLine(sb1);
            }
        }
    }
}
