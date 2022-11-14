namespace MvcAdmin.ViewModels
{
  public class ProductViewModel
  {
    public string? Name { get; set; }
    public string? ArticleNr { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public int QuantityInStore { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int ProductsOverlayId { get; set; }
    public ICollection<PostProductPicViewModel>? ProductPics { get; set; } = new List<PostProductPicViewModel>();
    public ICollection<PostAccessoriesViewModel> Accessories { get; set; } = new List<PostAccessoriesViewModel>();
  }
}