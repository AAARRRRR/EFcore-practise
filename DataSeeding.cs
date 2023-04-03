using EFcore_practise2.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFcore_practise2;

public class DataSeeding
{
    public ECommerceDbContext eCommerceDbContext { get; set; }

    public DataSeeding(ECommerceDbContext eCommerceDbContext)
    {
        using (var context = eCommerceDbContext)
        {
            context.Database.EnsureCreated();

            var testCustomer = context.Customers.FirstOrDefault(b => b.Id == 1);
            if (testCustomer == null)
            {
                context.Customers.Add(
                    new Customer {Name = "Avan", PhoneNumber = "11111", Email = "Avan@gmail.com" });
                context.Customers.Add(
                    new Customer {Name = "Bob", PhoneNumber = "22222", Email = "Bob@gmail.com" });
            } 
            
            var testProduct = context.Products.FirstOrDefault(b => b.Id == 1);
            if (testProduct == null)
            {
                context.Products.Add(
                    new Product {Name = "Biscuit", Price = 1.1 });
                context.Products.Add(
                    new Product {Name = "Sugar", Price = 2.2 });
            }
            
            var testTransaction = context.Transactions.FirstOrDefault(b => b.Id == 1);
            if (testTransaction == null)
            {
                context.Transactions.Add(
                    new Transaction {CustomerId = 1, ProductId = 1 });
                context.Transactions.Add(
                    new Transaction {CustomerId = 1, ProductId = 2 });
                context.Transactions.Add(
                    new Transaction {CustomerId = 2, ProductId = 1 });
            }
            
            var testProductDetail = context.ProductDetails.FirstOrDefault(b => b.Id == 1);
            if (testProductDetail == null)
            {
                context.ProductDetails.Add(
                    new ProductDetail {ProductId = 1, Description = "type of snack" });
                context.ProductDetails.Add(
                    new ProductDetail {ProductId = 2, Description = "type of seasoning or snack" });
            }
            
            context.SaveChanges();
        }
    }
}