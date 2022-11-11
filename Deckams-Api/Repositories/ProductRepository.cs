using Deckams_Api.Data;
using Deckams_Api.Interfaces;
using Deckams_Api.Models.Products;
using Deckams_Api.ViewModels.Products;

namespace Deckams_Api.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly DeckamsContext _context;
    public ProductRepository(DeckamsContext context)
    {
      _context = context;
    }

    public async Task AddCategoryAsync(PostCategoryViewModel model)
    {
      var categoryToAdd = new Category
      {
        Name = model.Name
      };
      var product = await _context.Categories.AddAsync(categoryToAdd);
    }

    public async Task AddProductAsync(PostProductViewModel model)
    {
      var product = new Product
      {
        Name = model.Name,
        ArticleNr = model.ArticleNr,
        Description = model.Description,
        ShortDescription = model.ShortDescription,
        QuantityInStore = model.QuantityInStore,
        Price = model.Price,

        Category = new Category
        {
          Name = model.Category!.Name
        },

        ProductOverlay = new ProductOverlay
        {
          Name = model.ProductOverlay!.Name,
          ImgUrl = model.ProductOverlay.ImgUrl
        },

        ProductPics = new List<ProductPic>()
      };
      foreach (var item in model.ProductPics!)
      {
        var productPic = new ProductPic
        {
          FileName = item.FileName
        };
        product.ProductPics.Add(productPic);
      }

      await _context.Products.AddAsync(product);
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}