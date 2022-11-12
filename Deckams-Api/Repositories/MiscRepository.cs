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
      if (await _context.AboutUs.FindAsync(1) is null)
      {
        var newModel = new AboutUs
        {
          Info = "Nothing here yet..."
        };
        await _context.AboutUs.AddAsync(newModel);
        await SaveAllAsync();
        var newModelToSend = new AboutUsViewModel
        {
          Info = "Nothing here yet..."
        };
        return newModelToSend;

      }
      var model = await _context.AboutUs.FindAsync(1);
      var modelToSend = new AboutUsViewModel
      {
        Info = model!.Info
      };
      return modelToSend;
    }

    public async Task UpdateAboutUsAsync(PutAboutUsViewModel model)
    {
      var oldInfo = await _context.AboutUs.FindAsync(1);

      oldInfo!.Info = model.Info;
      _context.Update(oldInfo);
    }


    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}