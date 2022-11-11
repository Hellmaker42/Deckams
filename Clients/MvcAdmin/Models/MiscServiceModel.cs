using System.Text.Json;
using MvcAdmin.ViewModels;

namespace MvcAdmin.Models
{
  public class MiscServiceModel
  {
    private readonly string _baseUrl;
    private readonly IConfiguration _config;
    private readonly JsonSerializerOptions _options;
    public MiscServiceModel(IConfiguration config)
    {
      _config = config;
      _baseUrl = $"{_config.GetValue<string>("baseUrl")}";
      _options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };
    }

    // public async Task<AboutUsViewModel> GetAboutUsInfo()
    // {

    // }
    public async Task<bool> CreateInfo(PostAboutUsViewModel infoModel)
    {
      using var http = new HttpClient();
      var url = $"{_baseUrl}";

      var response = await http.PostAsJsonAsync(url, infoModel);

      if (!response.IsSuccessStatusCode)
      {
        string reason = await response.Content.ReadAsStringAsync();
        Console.WriteLine(reason);
        return false;
      }

      return true;
    }
  }
}