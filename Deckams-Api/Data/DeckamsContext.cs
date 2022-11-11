using Deckams_Api.Models.Misc;
using Deckams_Api.Models.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Deckams_Api.Data
{
  public class DeckamsContext : IdentityDbContext
  {

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductOverlay> ProductOverlays => Set<ProductOverlay>();
    public DbSet<ProductPic> ProductPics => Set<ProductPic>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Accessories> Accessories => Set<Accessories>();
    public DbSet<AboutUs> AboutUs => Set<AboutUs>();
    public DbSet<ContactInfo> ContactInfo => Set<ContactInfo>();
    public DbSet<Terms> Terms => Set<Terms>();

    public DeckamsContext(DbContextOptions options) : base(options)
    {
    }
  }
}