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

    public async Task<ContactInfoViewModel> GetContactInfoAsync()
    {
      if (await _context.ContactInfo.FindAsync(1) is null)
      {
        var newModel = new ContactInfo
        {
          CompanyName = "Nothing yet...",
          Street = "Nothing yet...",
          ZipCode = "Nothing yet...",
          City = "Nothing yet...",
          PhoneNr = "Nothing yet...",
          Email = "Nothing yet...",
          OrgNr = "Nothing yet..."
        };

        await _context.ContactInfo.AddAsync(newModel);
        await SaveAllAsync();
        var newModelToSend = new ContactInfoViewModel
        {
          CompanyName = "Nothing yet...",
          Street = "Nothing yet...",
          ZipCode = "Nothing yet...",
          City = "Nothing yet...",
          PhoneNr = "Nothing yet...",
          Email = "Nothing yet...",
          OrgNr = "Nothing yet..."
        };
        return newModelToSend;

      }
      var model = await _context.ContactInfo.FindAsync(1);
      var modelToSend = new ContactInfoViewModel
      {
        CompanyName = model!.CompanyName,
        Street = model.Street,
        ZipCode = model.ZipCode,
        City = model.City,
        PhoneNr = model.PhoneNr,
        Email = model.Email,
        OrgNr = model.OrgNr
      };
      return modelToSend;
    }

    public async Task UpdateContactInfoAsync(PutContactInfoViewModel model)
    {
      var oldInfo = await _context.ContactInfo.FindAsync(1);

      oldInfo!.CompanyName = model.CompanyName;
      oldInfo!.Street = model.Street;
      oldInfo!.ZipCode = model.ZipCode;
      oldInfo!.City = model.City;
      oldInfo!.PhoneNr = model.PhoneNr;
      oldInfo!.Email = model.Email;
      oldInfo!.OrgNr = model.OrgNr;

      _context.Update(oldInfo);
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}