using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Server.EntityFramework;
using Shared.Models;

namespace Server.Services
{
    public class EFCoreService : IEFCoreService
    {
        public DataContext dbContext { get; set; }
        public EFCoreService()
        {
            dbContext = new();
        }
        public async void AddUserAsync(UserCredentials credentials)
        {
            await dbContext.AddAsync<UserCredentials>(credentials);
            dbContext.SaveChangesAsync();
        }

        public bool IsUserExistInDB(UserCredentials credentials)
        {

            UserCredentials user = (from u in dbContext.Users.AsParallel()
                                     where u.Name == credentials.Name 
                                     where u.Password == credentials.Password
                                     select u).FirstOrDefault();
            if (user is null)
                return false;
            return true;
        }
    }
}