using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Services
{

    public interface IEFCoreService
    {
        public void AddUserAsync(UserCredentials credentials);
        public bool IsUserExistInDB(UserCredentials credentials);
    }
}