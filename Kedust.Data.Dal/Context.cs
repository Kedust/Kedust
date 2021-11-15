using System;
using System.Threading;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kedust.Data.Dal
{
    internal sealed class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Setting> Settings { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Table> Tables { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddAudit<Menu>();
            modelBuilder.AddAudit<Choice>();
            modelBuilder.AddAudit<Order>();
            modelBuilder.AddAudit<OrderItem>();
            modelBuilder.AddAudit<Table>();
            modelBuilder.AddAudit<Setting>();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["CreatedAt"] = DateTime.Now;
                        entry.CurrentValues["DeletedAt"] = null;
                        entry.CurrentValues["DeletedAt"] = null;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues["UpdatedAt"] = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["DeletedAt"] = DateTime.Now;
                        break;
                }
            }
        }
    }

    internal static class ModelCreatingHelper
    {
        internal static ModelBuilder AddAudit<T>(this ModelBuilder modelBuilder) where T : class
        {
            modelBuilder.Entity<T>().Property<DateTime?>("CreatedAt");
            modelBuilder.Entity<T>().Property<DateTime?>("UpdatedAt");
            modelBuilder.Entity<T>().Property<DateTime?>("DeletedAt");
            modelBuilder.Entity<T>().HasQueryFilter(m => !EF.Property<DateTime?>(m, "DeletedAt").HasValue);
            return modelBuilder;
        }
    }
}