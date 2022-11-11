using Microsoft.AspNetCore.Mvc;

namespace MvcAdmin.Controllers
{
  [Route("[controller]")]
  public class ProductController : Controller
  {


    public IActionResult Index()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }
  }
}