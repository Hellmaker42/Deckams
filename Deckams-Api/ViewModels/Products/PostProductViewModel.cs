namespace Deckams_Api.ViewModels.Products
{
  public class PostProductViewModel
  {
    public string? Name { get; set; }
    public string? ArticleNr { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public int QuantityInStore { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int ProductsOverlayId { get; set; }
    public CategoryViewModel? Category { get; set; }
    public List<ProductPicViewModel>? ProductPics { get; set; } = new List<ProductPicViewModel>();
    public ProductOverlayViewModel? ProductOverlay { get; set; }
  }
}