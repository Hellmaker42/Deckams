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

    // [HttpGet("CreateInfo")]
    // public async Task<IActionResult> CreateInfo()
    // {
    //   var aboutInfo = new PostAboutUsViewModel();
    // }

    [HttpPut("CreateInfo")]
    public async Task<IActionResult> CreateInfo(PostAboutUsViewModel aboutModel)
    {
      if (await _miscService.CreateInfo(aboutModel))
      {
        return View("Index", aboutModel);
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