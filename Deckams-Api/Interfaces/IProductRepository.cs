using Deckams_Api.Models.Products;
using Deckams_Api.ViewModels.Products;

namespace Deckams_Api.Interfaces
{
  public interface IProductRepository
  {
    public Task AddProductAsync(PostProductViewModel model);
    public Task<List<CategoryViewModel>> GetCategoriesAsync();
    public Task<CategoryViewModel> GetCategoryByIdAsync(int id);
    public Task AddCategoryAsync(PostCategoryViewModel model);
    public Task<bool> SaveAllAsync();
  }
}