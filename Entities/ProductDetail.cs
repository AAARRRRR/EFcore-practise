namespace EFcore_practise2.Entities;

public class ProductDetail
{
    public int Id { get; set; }
    
    public int  ProductId { get; set; }
    public string Description { get; set; }
    public Product Product { get; set; }
}