using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Data.Dal
{
    internal sealed class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public DbSet<Domain.Menu> Menus { get; set; }
        public DbSet<Domain.Choice> MenuItems { get; set; }
        public DbSet<Domain.Order> Orders { get; set; }
        public DbSet<Domain.OrderItem> OrderItems { get; set; }
        public DbSet<Domain.Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Menu>()
                .HasMany(e => e.Choices)
                .WithOne(e => e.Menu)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}