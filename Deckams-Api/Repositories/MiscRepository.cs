using Deckams_Api.Data;
using Deckams_Api.Interfaces;
using Deckams_Api.Models.Misc;
using Deckams_Api.ViewModels.Misc;

namespace Deckams_Api.Repositories
{
  public class MiscRepository : IMiscRepository
  {
    private readonly DeckamsContext _context;
    public MiscRepository(DeckamsContext context)
    {
      _context = context;
    }
    public async Task<AboutUsViewModel> GetAboutUsAsync()
    {
      var model = await _context.AboutUs.FindAsync(1);
      var modelToSend = new AboutUsViewModel
      {
        Info = model!.Info
      };
      return modelToSend;
    }

    public async Task CreateAboutUsAsync(PostAboutUsViewModel model)
    {
      var modelToAdd = new AboutUs
      {
        Info = model.Info
      };
      await _context.AboutUs.AddAsync(modelToAdd);
    }


    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}