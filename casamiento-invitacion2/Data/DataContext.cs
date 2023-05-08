using Microsoft.EntityFrameworkCore;
using casamiento_invitacion2.Models;

namespace casamiento_invitacion2.Data
{
    public class DataContext:DbContext
    {
        private readonly string? ConnectionString;
        private readonly MySqlServerVersion ServerVersion;

        public DbSet<Guest> Guests { get; set; }

        public DataContext(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("mysqlconnection");
            ServerVersion = new MySqlServerVersion(MySqlServerVersion.AutoDetect(ConnectionString));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString, ServerVersion);
        }
    }
}
