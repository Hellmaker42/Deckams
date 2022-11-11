using System.ComponentModel.DataAnnotations.Schema;

namespace Deckams_Api.Models.Products
{
  public class Product
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ArticleNr { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public int QuantityInStore { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int ProductsOverlayId { get; set; }
    public ICollection<ProductPic>? ProductPics { get; set; } = new List<ProductPic>();
    public ICollection<Accessories> Accessories { get; set; } = new List<Accessories>();
    [ForeignKey("ProductsOverlayId")]
    public ProductOverlay? ProductOverlay { get; set; } = new ProductOverlay();
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; } = new Category();
  }
}