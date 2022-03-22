using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.EntityFramework
{
    public class DataContext : DbContext
    {
        private const string CONNECTION_STRING = @"Data Source=DESKTOP-1GHJ14S;Database=UserDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DbSet<UserCredentials> Users { get; set; }
        public DataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
            base.OnConfiguring(optionsBuilder);
        }
    }
}