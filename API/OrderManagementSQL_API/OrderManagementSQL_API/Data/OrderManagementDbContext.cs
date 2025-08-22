using Microsoft.EntityFrameworkCore;
using OrderManagementSQL_API.Models;

namespace OrderManagementSQL_API.Data;

public class OrderManagementDbContext : DbContext
{
    public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Customers table mapping - matches your SQL exactly
        modelBuilder.Entity<Customer>().ToTable("customers");
        modelBuilder.Entity<Customer>().Property(c => c.Id).HasColumnName("id");
        modelBuilder.Entity<Customer>().Property(c => c.FirstName).HasColumnName("first_name");
        modelBuilder.Entity<Customer>().Property(c => c.LastName).HasColumnName("last_name");
        modelBuilder.Entity<Customer>().Property(c => c.Email).HasColumnName("email");
        modelBuilder.Entity<Customer>().Property(c => c.Details).HasColumnName("details"); // JSONB in PostgreSQL

        // Products table mapping - matches your SQL exactly
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("id");
        modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("name");
        modelBuilder.Entity<Product>().Property(p => p.Category).HasColumnName("category");
        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnName("price"); // DECIMAL(20,2) in PostgreSQL

        // Orders table mapping - matches your SQL exactly
        modelBuilder.Entity<Order>().ToTable("orders");
        modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnName("id");
        modelBuilder.Entity<Order>().Property(o => o.CustomerId).HasColumnName("customer_id");
        modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasColumnName("order_date");

        // Order Items table mapping - matches your SQL exactly
        modelBuilder.Entity<OrderItem>().ToTable("order_items");
        modelBuilder.Entity<OrderItem>().HasKey(oi => new { oi.OrderId, oi.ProductId }); // Composite PRIMARY KEY
        modelBuilder.Entity<OrderItem>().Property(oi => oi.OrderId).HasColumnName("order_id");
        modelBuilder.Entity<OrderItem>().Property(oi => oi.ProductId).HasColumnName("product_id");
        modelBuilder.Entity<OrderItem>().Property(oi => oi.Quantity).HasColumnName("quantity");

        // Foreign Key relationships - matches your REFERENCES exactly
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey(o => o.CustomerId);
    }
}