using Microsoft.AspNetCore.Mvc;
using MvcAdmin.Models;
using MvcAdmin.ViewModels;

namespace MvcAdmin.Controllers
{
  [Route("[controller]")]
  public class MiscController : Controller
  {
    private readonly IConfiguration _config;
    private readonly MiscServiceModel _miscService;

    public MiscController(IConfiguration config)
    {
      _config = config;
      _miscService = new MiscServiceModel(_config);
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpGet("aboutus")]
    public async Task<IActionResult> GetAboutUsInfo()
    {
      var aboutInfo = await _miscService.GetAboutUsInfo();
      return View("UpdateAboutUs", aboutInfo);
    }

    [Route("Misc/UpdateAboutUs", Name = "Update")]
    [HttpPut("UpdateAboutUs")]
    public async Task<IActionResult> UpdateAboutUs(AboutUsViewModel aboutModel)
    {
      if (await _miscService.UpdateAboutUsInfo(aboutModel))
      {
        ViewBag.updateded = true;
        return View("UpdateAboutUs", aboutModel);
      }
      return View("Error!");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }
  }
}