using Deckams_Api.ViewModels.Misc;

namespace Deckams_Api.Interfaces
{
  public interface IMiscRepository
  {
    public Task UpdateAboutUsAsync(PutAboutUsViewModel model);
    public Task<AboutUsViewModel> GetAboutUsAsync();
    public Task<bool> SaveAllAsync();
  }
}