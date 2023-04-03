using EFcore_practise2;
using EFcore_practise2.Entities;
using Microsoft.EntityFrameworkCore;

var dbcontext = new ECommerceDbContext();
var dataSeeding =  new DataSeeding(dbcontext);

// Query
 var customers = from customer in dbcontext.Customers select customer;
 foreach (var customer in customers)
 {
     Console.WriteLine(customer.Name);
 }

//Query2
var transactions = dbcontext.Transactions
    .Include("Product")
    .Where(t => t.ProductId == 1)
    .AsNoTracking()
    .ToList();
foreach (var transaction in transactions)
{
    Console.WriteLine(transaction.Product.Name);
}

//Insert
var newTransaction = new Transaction { ProductId = 2, CustomerId = 2 };
dbcontext.Add(newTransaction);
var newProduct = new Product { Name = "salt", Price = 3};
dbcontext.Add(newProduct);

//Delete
var removedTransaction = new Transaction { Id = 4, ProductId = 2, CustomerId = 2 };
dbcontext.Remove(removedTransaction);

//Update
var updatedProduct = new Product { Id = 3, Name = "salt", Price = 4};
dbcontext.Update(updatedProduct);

dbcontext.SaveChanges();