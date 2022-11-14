using Deckams_Api.Data;
using Deckams_Api.Interfaces;
using Deckams_Api.Models.Products;
using Deckams_Api.ViewModels.Products;
using Microsoft.EntityFrameworkCore;

namespace Deckams_Api.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly DeckamsContext _context;
    public ProductRepository(DeckamsContext context)
    {
      _context = context;
    }

    public async Task<List<CategoryViewModel>> GetCategoriesAsync()
    {
      var categories = await _context.Categories.ToListAsync();
      var categoriesToSend = new List<CategoryViewModel>();
      foreach (var item in categories)
      {
        categoriesToSend.Add(new CategoryViewModel
        {
          Id = item.Id,
          Name = item.Name
        }
      );
      }
      return categoriesToSend;
    }

    public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
    {
      var category = await _context.Categories.FindAsync(id);
      var categoryToSend = new CategoryViewModel
      {
        Id = category!.Id,
        Name = category.Name
      };

      return categoryToSend;
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