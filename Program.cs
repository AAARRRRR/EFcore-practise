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

dbcontext.SaveChanges();