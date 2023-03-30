using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Robot> Robots { get; set; }
        public DbSet<Payload> Payloads { get; set; }
    }
}