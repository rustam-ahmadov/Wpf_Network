using System;
using System.Net;
using System.Net.Sockets;

namespace Client.Services
{
    class NetworkSevice : INetworkService
    {
        private const int PORT = 8080;
        private const string IPADD = "127.0.0.1";
        private static Socket socket;
        private static IPAddress? ip;
        private static IPEndPoint? endPoint;

        public NetworkSevice()
        {
            socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ip = IPAddress.Parse(IPADD);
            endPoint = new(ip, PORT);            
        }
        public async void HandleServerResponceAsync()
        {
            
            while (true)
            {

            }
        }

        public async void SendCredentialsToServerAsync()
        {

        }
    }
}
