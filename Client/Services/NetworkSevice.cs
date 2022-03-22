using Shared.Models;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
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
            socket.Bind(endPoint);
            socket.Listen();

            while (true)
            {
                Socket client = await socket.AcceptAsync();
                System.Console.WriteLine("Client connected!");

                ThreadPool.QueueUserWorkItem(async obj =>
                {
                    while (true)
                    {
                        byte[] buffer = new byte[65000];
                        int size = await client.ReceiveAsync(buffer, SocketFlags.None);

                        string data = Encoding.UTF8.GetString(buffer, 0, size);
                        Request userRequest = JsonSerializer.Deserialize<Request>(data);

                        System.Console.WriteLine(userRequest.Credentials.Name);
                    }
                });
            }

        }

        public async void  SendCredentialsToServerAsync(Request request)
        {
            string data = JsonSerializer.Serialize<Request>(request);
            byte[] dataInBytes = Encoding.UTF8.GetBytes(data);

            await socket.SendAsync(dataInBytes, socketFlags: SocketFlags.None);
        }

        
    }
}
