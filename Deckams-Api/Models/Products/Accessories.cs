namespace Deckams_Api.Models.Products
{
  public class Accessories
  {
    public int Id { get; set; }
    public int Product_Id { get; set; }
    public int ArticleNr { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public decimal Price { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
  }
}