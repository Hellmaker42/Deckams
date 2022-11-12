using Deckams_Api.Interfaces;
using Deckams_Api.ViewModels.Misc;
using Microsoft.AspNetCore.Mvc;

namespace Deckams_Api.Controllers
{
  [ApiController]
  [Route("api/v1/misc")]
  public class MiscController : ControllerBase
  {
    private readonly IMiscRepository _miscRepo;
    public MiscController(IMiscRepository miscRepo)
    {
      _miscRepo = miscRepo;
    }

    [HttpGet("aboutus")]
    public async Task<AboutUsViewModel> GetAboutUs()
    {
      return await _miscRepo.GetAboutUsAsync();
    }

    [HttpPut("aboutus")]
    public async Task<ActionResult> CreateAboutUs(PutAboutUsViewModel model)
    {
      await _miscRepo.UpdateAboutUsAsync(model);
      if (await _miscRepo.SaveAllAsync())
      {
        return StatusCode(201);
      }

      return StatusCode(500, "Det gick inte att spara info.");
    }

    [HttpGet("ContactInfo")]
    public async Task<ContactInfoViewModel> GetContactInfo()
    {
      return await _miscRepo.GetContactInfoAsync();
    }

    [HttpPut("ContactInfo")]
    public async Task<ActionResult> UpdateContactInfo(PutContactInfoViewModel contactModel)
    {
      await _miscRepo.UpdateContactInfoAsync(contactModel);
      if (await _miscRepo.SaveAllAsync())
      {
        return StatusCode(201);
      }

      return StatusCode(500, "Det gick inte att spara info.");
    }
  }
}