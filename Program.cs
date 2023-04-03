using EFcore_practise2;
using EFcore_practise2.Entities;

var dbcontext = new ECommerceDbContext();
var dataSeeding =  new DataSeeding(dbcontext);
