using E_Phone_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Phone_Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = default!;
    }
}
