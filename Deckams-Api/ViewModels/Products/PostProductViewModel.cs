using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deckams_Api.ViewModels.Products
{
  public class PostProductViewModel
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ArticleNr { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public int QuantityInStore { get; set; }
    public decimal Price { get; set; }
    public PostCategoryViewModel? Category { get; set; }

    public List<PostProductPicViewModel>? ProductPics { get; set; } = new List<PostProductPicViewModel>();
    public PostProductOverlayViewModel? ProductOverlay { get; set; }
  }
}