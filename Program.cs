using EFcore_practise2;
using EFcore_practise2.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var dbcontext = new ECommerceDbContext();
var dataSeeding =  new DataSeeding(dbcontext);

//Query
 var customers = from customer in dbcontext.Customers select customer;
 foreach (var customer in customers)
 {
     Console.WriteLine(customer.Name);
 }

//Query2
var transactions = dbcontext.Transactions
    .Where(t => t.ProductId == 1)
    .Include(t => t.Product)
    .AsSplitQuery()
    .AsNoTracking()
    .ToList();
foreach (var transaction in transactions)
{
    Console.WriteLine(transaction.Product.Name);
}

// //Insert
// var newTransaction = new Transaction { ProductId = 2, CustomerId = 2 };
// dbcontext.Add(newTransaction);
// var newProduct = new Product { Name = "salt", Price = 3};
// dbcontext.Add(newProduct);
//
// //Delete
// var removedTransaction = new Transaction { Id = 4, ProductId = 2, CustomerId = 2 };
// dbcontext.Remove(removedTransaction);
//
// //Update
// var updatedProduct = new Product { Id = 3, Name = "salt", Price = 4};
// dbcontext.Update(updatedProduct);

dbcontext.SaveChanges();

//use sql connectionPool
using var connection = new SqlConnection(
    "Data Source=127.0.0.1,1433;Initial Catalog=master;" +
    "User Id=sa;Password=MyPass@word;TrustServerCertificate=True;MultiSubnetFailover=True;");
connection.Open();
var command =
    new SqlCommand("INSERT INTO Customers (Name, Email, PhoneNumber) VALUES ('Calvin', 'Calvin@123.com', '333')",connection);
var command2 =
    new SqlCommand("INSERT INTO Transactions (ProductId, CustomerId) VALUES (1, 3)",connection);
command.ExecuteNonQuery();
command2.ExecuteNonQuery();
connection.Close();