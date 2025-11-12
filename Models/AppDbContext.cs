using Microsoft.EntityFrameworkCore;
namespace iBarber.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Barbearias> Barbearias { get; set; }
    }
}
