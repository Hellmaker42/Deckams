using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcAdmin.Models;
using MvcAdmin.ViewModels;

namespace MvcAdmin.Controllers
{
  [Route("[controller]")]
  public class ProductsController : Controller
  {
    private readonly IConfiguration _config;
    private readonly ProductServiceModel _productService;
    public ProductsController(IConfiguration config)
    {
      _config = config;
      _productService = new ProductServiceModel(_config);
    }

    [Route("Index")]
    public IActionResult Index()
    {
      return View();
    }

    [Route("Product/CreateProduct", Name = "CreateProduct")]
    [HttpGet("CreateProduct")]
    public async Task<IActionResult> CreateProduct()
    {
      var product = new PostProductViewModel();
      var categories = await _productService.GetCategories();
      List<SelectListItem> catList = categories.ConvertAll(a =>
      {
        return new SelectListItem()
        {
          Text = a.Name,
          Value = a.Id.ToString()
        };
      });
      ViewBag.Categories = catList;
      return View("CreateProduct", product);
    }

    [Route("Product/PostProduct", Name = "PostProduct")]
    [HttpPost("PostProduct")]
    public async Task<IActionResult> PostProduct(PostProductViewModel productModel)
    {
      var catId = Int32.Parse(productModel.Category.Name!);
      productModel.CategoryId = catId;
      var category = await _productService.GetCategoryById(catId);
      productModel.Category = category;

      // Autofyll
      var prodPic = new ProductPicViewModel
      {
        Id = 1,
        FileName = "img/pic.jpg"
      };
      productModel.ProductPics!.Add(prodPic);

      var prodOverLay = new ProductOverlayViewModel
      {
        Id = 1,
        Name = "Rea",
        ImgUrl = "img/ovLay/rea.jpg"
      };
      // productModel.ProductOverlay = prodOverLay;
      //

      if (await _productService.PostProduct(productModel))
      {
        return View("Index");
      }

      return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }
  }
}