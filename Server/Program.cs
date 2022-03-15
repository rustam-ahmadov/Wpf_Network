using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        private const int PORT = 8080;
        private const string IPADD = "127.0.0.1";
        private static Socket socket ;
        private static IPAddress? ip;

        private static IPEndPoint? endPoint;
        static void Main(string[] args)
        {
            
            socket  = new(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            ip = IPAddress.Parse(IPADD);
            endPoint = new(ip,PORT);
            



        }

        private static async Task StartServer()
        {
            socket.Bind(endPoint);
            socket.Listen();



            while(true)
            {
               
            }
        }
    }
}
