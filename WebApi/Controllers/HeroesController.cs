using Services.Core;

namespace WebApi.Controllers;

public class HeroesController : BaseController
{
  public HeroesController(NawiaDbContext dbContext) : base(dbContext)
  {
  }
}
