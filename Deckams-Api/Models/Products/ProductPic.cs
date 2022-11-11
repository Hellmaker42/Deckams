using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deckams_Api.Models.Products
{
  public class ProductPic
  {
    public int Id { get; set; }
    [Required]
    public string? FileName { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product? Product { get; set; } = new Product();
  }
}