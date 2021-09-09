using Microsoft.EntityFrameworkCore;

namespace Kedust.Data.Dal
{
    internal class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        
        public DbSet<Domain.Menu> Menus { get; set; }
        public DbSet<Domain.MenuItem> MenuItems { get; set; }
        public DbSet<Domain.Order> Orders { get; set; }
        public DbSet<Domain.OrderItem> OrderItems { get; set; }
        public DbSet<Domain.Table> Tables { get; set; }
    }
}