using Microsoft.EntityFrameworkCore;
using StatePatternEfCore.Domain.Order;

namespace StatePatternEfCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}