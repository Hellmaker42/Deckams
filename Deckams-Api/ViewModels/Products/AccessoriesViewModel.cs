namespace Deckams_Api.ViewModels.Products
{
  public class AccessoriesViewModel
  {
    public int Product_Id { get; set; }
    public int ArticleNr { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public decimal Price { get; set; }
    public ICollection<PostProductViewModel> Products { get; set; } = new List<PostProductViewModel>();
  }
}