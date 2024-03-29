using Microsoft.EntityFrameworkCore;

namespace Asp.net_Practical.Models
{
    public class SolutionDbContext : DbContext
    {
        public SolutionDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
