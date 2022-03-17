using Shared.Models;
using Shared.Tools;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

            socket.Connect(endPoint);
        }
        public async void HandleServerResponceAsync()
        {
           
        }

        public async void SendCredentialsToServerAsync(Request request)
        {         
            string data = JsonSerializer.Serialize(request);
            byte[] dataInBytes = Encoding.UTF8.GetBytes(data);

            await socket.SendAsync(dataInBytes, socketFlags: SocketFlags.None);
        }

        
    }
}
