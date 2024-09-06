using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess
{
    public class ShopContext : DbContext
    {
        private readonly string _connectionString;

        public ShopContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ShopContext()
        {
            _connectionString = "Data Source=.\\SQLExpress;Initial Catalog=shopAPI;TrustServerCertificate=true;Integrated security = true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<ShipmentItem>().HasKey(x => new { x.ShipmentId, x.OrderItemId });

            modelBuilder.Entity<Product>().UseTptMappingStrategy();

            modelBuilder.Entity<ImageProduct>()
                        .HasMany(x => x.Images)
                        .WithOne(x => x.ImageProduct)
                        .HasForeignKey(x => x.ImageProductId);

            modelBuilder.Entity<ImageProductFile>()
                        .HasOne(x => x.File)
                        .WithMany(x => x.ProductFiles)
                        .HasForeignKey(x => x.FileId);

            modelBuilder.Entity<ImageProductFile>().HasKey(x => new
            {
                x.FileId,
                x.ImageProductId
            });

            modelBuilder.Entity<CustomerUseCase>().HasKey(x => new
            {
                x.CustomerId,
                x.UseCaseId
            });

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.IsActive = true;
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }
                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderItemStatus> OrderItemStatuses { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<CustomerPaymentMethod> CustomerPaymentMethods { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<ImageProductFile> ImageProductFiles { get; set; }
        public DbSet<Domain.File> Files { get; set; }
        public DbSet<ImageProduct> ImageProducts { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<CustomerUseCase> CustomerUseCases { get; set; }
    }
}
