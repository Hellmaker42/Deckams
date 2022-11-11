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

    // [HttpGet("aboutus")]
    // public async Task<ActionResult> GetAboutUs()
    // {
    //   var aboutUs =
    // }

    [HttpPost("aboutus")]
    public async Task<ActionResult> CreateAboutUs(PostAboutUsViewModel model)
    {
      await _miscRepo.CreateAboutUsAsync(model);
      if (await _miscRepo.SaveAllAsync())
      {
        return StatusCode(201);
      }

      return StatusCode(500, "Det gick inte att spara kategorin.");
    }
  }
}