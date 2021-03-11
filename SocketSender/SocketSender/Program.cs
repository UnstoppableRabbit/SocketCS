using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketSender
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.2.1";
            int port = 1488;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            var mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket.Connect(ep);
            string k = "Передаю эту строку";
            mySocket.Send(Encoding.UTF8.GetBytes(k));
            mySocket.Shutdown(SocketShutdown.Both);
            mySocket.Close();

            int port1 = 1489;
            IPEndPoint ep1 = new IPEndPoint(IPAddress.Parse(ip), port1);
            var mySocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket1.Connect(ep1);
            string k1 = "Передаю и эту строку";
            mySocket1.Send(Encoding.UTF8.GetBytes(k1));
            mySocket1.Shutdown(SocketShutdown.Both);
            mySocket1.Close();
        }
    }
}
