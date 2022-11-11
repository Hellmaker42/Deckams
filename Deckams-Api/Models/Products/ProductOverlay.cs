using System.ComponentModel.DataAnnotations.Schema;

namespace Deckams_Api.Models.Products
{
  public class ProductOverlay
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
  }
}