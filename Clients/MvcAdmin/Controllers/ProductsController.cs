using Microsoft.AspNetCore.Mvc;

namespace MvcAdmin.Controllers
{
  [Route("[controller]")]
  public class ProductsController : Controller
  {
    public ProductsController()
    {
    }

    [Route("Index")]
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