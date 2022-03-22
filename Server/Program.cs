using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Server.EntityFramework;
using Server.Services;
using Shared.Models;

namespace Server
{
    class Program
    {
        
        private static IEFCoreService efCoreService = new EFCoreService();
        private const int PORT = 8080;
        private const string IPADD = "127.0.0.1";
        private static Socket socket;
        private static IPAddress? ip;

        private static IPEndPoint? endPoint;
        static async Task Main(string[] args)
        {

            socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ip = IPAddress.Parse(IPADD);
            endPoint = new(ip, PORT);

            await StartServer();
        }

        private static async Task StartServer()
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


                        bool isUserAlreadyInDb = efCoreService.IsUserExistInDB(userRequest.Credentials);
                        byte[] responseInBytes;

                        if (userRequest.RequestTypes == Shared.Tools.RequestTypes.LOGIN)
                        {
                            string response = JsonSerializer.Serialize<string>(isUserAlreadyInDb.ToString());
                            responseInBytes = Encoding.UTF8.GetBytes(response);
                            await client.SendAsync(responseInBytes, SocketFlags.None);
                        }
                        else if (userRequest.RequestTypes == Shared.Tools.RequestTypes.CREATE)
                        {
                            if (isUserAlreadyInDb == true)
                                responseInBytes = Encoding.UTF8.GetBytes("false");
                            else{
                                efCoreService.AddUserAsync(userRequest.Credentials);
                                responseInBytes = Encoding.UTF8.GetBytes("true");
                            }

                            await client.SendAsync(responseInBytes, SocketFlags.None);
                        }
                    }
                });
            }
        }
    }
}
