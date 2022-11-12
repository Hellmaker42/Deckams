using Deckams_Api.ViewModels.Misc;

namespace Deckams_Api.Interfaces
{
  public interface IMiscRepository
  {
    public Task<AboutUsViewModel> GetAboutUsAsync();
    public Task UpdateAboutUsAsync(PutAboutUsViewModel model);
    public Task<ContactInfoViewModel> GetContactInfoAsync();
    public Task UpdateContactInfoAsync(PutContactInfoViewModel model);
    public Task<bool> SaveAllAsync();
  }
}