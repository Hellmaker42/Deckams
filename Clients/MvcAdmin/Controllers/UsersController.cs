using Microsoft.AspNetCore.Mvc;

namespace MvcAdmin.Controllers
{
  [Route("[controller]")]
  public class UsersController : Controller
  {


    public IActionResult Index()
    {
      return View();
    }

    [Route("GetUsers", Name = "GetTheUsers")]
    [HttpGet()]
    public ActionResult GetUsers()
    {
      return View("User");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }
  }
}