using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFcore_practise2.Entities;

public class ECommerceDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public ECommerceDbContext()
    {
    }
    
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     const string connectionString = "Data Source=127.0.0.1,1433;Initial Catalog=master;User Id=sa;Password=MyPass@word;TrustServerCertificate=True;MultiSubnetFailover=True;";
    //     optionsBuilder.UseLazyLoadingProxies()
    //         .UseSqlServer(connectionString)
    //         .LogTo(Console.WriteLine, LogLevel.Information);
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);
        
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<ProductDetail>()
            .HasKey(d => d.Id);
        modelBuilder.Entity<ProductDetail>()
            .HasOne(d => d.Product)
            .WithOne( p => p.ProductDetail)
            .HasForeignKey<ProductDetail>(d => d.ProductId);
            
        modelBuilder.Entity<Transaction>()
            .HasKey(t => t.Id);
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Product)
            .WithMany()
            .HasForeignKey(t => t.ProductId);
        
        // can seed data when initialize database
        // modelBuilder.Entity<Customer>()
        //     .HasData(new Customer { Id = 1, Name = "Avan", PhoneNumber = "11111", Email = "Avan@gmail.com" },
        //     new Customer  { Id = 2, Name = "Bob", PhoneNumber = "22222", Email = "Bob@gmail.com" });
    }
    
}