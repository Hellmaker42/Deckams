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

    public async Task<AboutUsViewModel> GetAboutUsInfo()
    {
      using var http = new HttpClient();
      var url = $"{_baseUrl}misc/aboutus";

      var response = await http.GetAsync(url);
      if (!response.IsSuccessStatusCode)
      {
        throw new Exception("Det här gick ju inte bra tyvärr..");
      }
      var modelToSend = await response.Content.ReadFromJsonAsync<AboutUsViewModel>();

      return modelToSend ?? new AboutUsViewModel();
    }
    public async Task<bool> UpdateAboutUsInfo(AboutUsViewModel infoModel)
    {
      var putInfoModel = new PutAboutUsViewModel
      {
        Info = infoModel.Info
      };

      using var http = new HttpClient();
      var url = $"{_baseUrl}misc/aboutus";

      var response = await http.PutAsJsonAsync(url, putInfoModel);

      if (!response.IsSuccessStatusCode)
      {
        string reason = await response.Content.ReadAsStringAsync();
        Console.WriteLine(reason);
        return false;
      }

      return true;
    }

    public async Task<ContactInfoViewModel> GetContactInfo()
    {
      using var http = new HttpClient();
      var url = $"{_baseUrl}misc/ContactInfo";

      var response = await http.GetAsync(url);
      if (!response.IsSuccessStatusCode)
      {
        throw new Exception("Det här gick ju inte bra tyvärr..");
      }
      var modelToSend = await response.Content.ReadFromJsonAsync<ContactInfoViewModel>();

      return modelToSend ?? new ContactInfoViewModel();
    }

    public async Task<bool> UpdateContactInfo(ContactInfoViewModel contactModel)
    {
      var putContactModel = new PutContactInfoViewModel
      {
        CompanyName = contactModel.CompanyName,
        Street = contactModel.Street,
        ZipCode = contactModel.ZipCode,
        City = contactModel.City,
        PhoneNr = contactModel.PhoneNr,
        Email = contactModel.Email,
        OrgNr = contactModel.OrgNr
      };

      using var http = new HttpClient();
      var url = $"{_baseUrl}misc/ContactInfo";

      var response = await http.PutAsJsonAsync(url, putContactModel);

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