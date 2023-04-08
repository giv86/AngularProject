using Microsoft.AspNetCore.Mvc;
using Services.Core;
using Action = Models.Dbo.Game.Action;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActionsController : BaseGameObjectController<Action>
{
  public ActionsController(NawiaDbContext dbContext) : base(dbContext)
  {
  }
}
