using System.Text.Json;
using MvcAdmin.ViewModels;

namespace MvcAdmin.Models
{
  public class ProductServiceModel
  {
    private readonly string _baseUrl;
    private readonly IConfiguration _config;
    private readonly JsonSerializerOptions _options;
    public ProductServiceModel(IConfiguration config)
    {
      _config = config;
      _baseUrl = $"{_config.GetValue<string>("baseUrl")}";
      _options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };
    }

    public async Task<bool> PostProduct(PostProductViewModel productModel)
    {
      using var http = new HttpClient();
      var url = $"{_baseUrl}products/product";
      var response = await http.PostAsJsonAsync(url, productModel);

      if (!response.IsSuccessStatusCode)
      {
        string reason = await response.Content.ReadAsStringAsync();
        Console.WriteLine(reason);
        return false;
      }

      return true;
    }

    public async Task<List<CategoryViewModel>> GetCategories()
    {
      using var http = new HttpClient();
      var url = $"{_baseUrl}products/Categories";
      var response = await http.GetAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception("Det här gick ju inte bra tyvärr..");
      }
      var categories = await response.Content.ReadFromJsonAsync<List<CategoryViewModel>>();

      return categories ?? new List<CategoryViewModel>();
    }

    public async Task<CategoryViewModel> GetCategoryById(int id)
    {
      using var http = new HttpClient();
      var url = $"{_baseUrl}products/Categories/{id}";
      var response = await http.GetAsync(url);

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception("Det här gick ju inte bra tyvärr..");
      }
      var category = await response.Content.ReadFromJsonAsync<CategoryViewModel>();

      return category ?? new CategoryViewModel();
    }
  }
}