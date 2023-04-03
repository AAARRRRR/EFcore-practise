namespace EFcore_practise2.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public ProductDetail ProductDetail { get; set; }
}