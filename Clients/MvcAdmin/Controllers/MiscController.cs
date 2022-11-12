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

    [Route("Index")]
    public IActionResult Index()
    {
      return View();
    }

    [Route("Misc/About", Name = "GetAboutUs")]
    [HttpGet("Aboutus")]
    public async Task<IActionResult> GetAboutUsInfo()
    {
      var aboutInfo = await _miscService.GetAboutUsInfo();
      return View("UpdateAboutUs", aboutInfo);
    }

    [Route("Misc/UpdateAboutUs", Name = "UpdateAboutUs")]
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

    [Route("Misc/ContactInfo", Name = "GetContactInfo")]
    [HttpGet("ContactInfo")]
    public async Task<IActionResult> GetContactInfo()
    {
      var contactInfo = await _miscService.GetContactInfo();
      return View("UpdateContactInfo", contactInfo);
    }

    [Route("Misc/UpdateContactInfo", Name = "UpdateContactInfo")]
    [HttpPut("UpdateContactInfo")]
    public async Task<IActionResult> UpdateContactInfo(ContactInfoViewModel contactModel)
    {
      if (await _miscService.UpdateContactInfo(contactModel))
      {
        ViewBag.updateded = true;
        return View("UpdateContactInfo", contactModel);
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