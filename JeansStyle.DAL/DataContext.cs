using JeansStyle.DAL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace JeansStyle.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserCredentials> UserCredentials { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            Audit();

            return base.SaveChanges();
        }


        private void Audit()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity
                    && (e.State == EntityState.Added || e.State == EntityState.Modified))
                .ToArray();

            if (!entries.Any())
                return;

 

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
                }
                else
                {
                    Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedDate).IsModified = false;
                }

                ((AuditableEntity)entityEntry.Entity).UpdatedDate = DateTime.UtcNow;

            }

            ChangeTracker.DetectChanges();
        }
    }
}
