using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;

namespace Client.Services
{
    interface INetworkService
    {
        public void HandleServerResponceAsync();
        public void SendCredentialsToServerAsync(Request request);
    }
}
