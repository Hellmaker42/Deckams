using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deckams_Api.ViewModels.Products
{
    public class PostAccessoriesViewModel
    {
    public int ArticleNr { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public decimal Price { get; set; }      
    }
}