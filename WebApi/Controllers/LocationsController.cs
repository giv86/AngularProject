using Microsoft.AspNetCore.Mvc;
using Models.Dbo.Game;
using Services.Core;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : BaseGameObjectController<Location>
{
  public LocationsController(NawiaDbContext dbContext) : base(dbContext)
  {
  }
}
