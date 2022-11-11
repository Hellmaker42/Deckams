using Deckams_Api.Interfaces;
using Deckams_Api.Models.Products;
using Deckams_Api.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace Deckams_Api.Controllers
{
  [ApiController]
  [Route("api/v1/products")]
  public class ProductsController : ControllerBase
  {
    private readonly IProductRepository _productRepo;
    public ProductsController(IProductRepository productRepo)
    {
      _productRepo = productRepo;
    }

    [HttpPost("category")]
    public async Task<ActionResult> AddCategory(PostCategoryViewModel model)
    {
      await _productRepo.AddCategoryAsync(model);
      if (await _productRepo.SaveAllAsync())
      {
        return StatusCode(201);
      }

      return StatusCode(500, "Det gick inte att spara kategorin.");
    }

    [HttpPost()]
    public async Task<ActionResult> AddProduct(PostProductViewModel model)
    {
      await _productRepo.AddProductAsync(model);

      if (await _productRepo.SaveAllAsync())
      {
        return StatusCode(201);
      }

      return StatusCode(500, "Det gick inte att spara produkten.");
    }
  }
}