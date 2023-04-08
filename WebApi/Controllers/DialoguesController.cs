using Microsoft.AspNetCore.Mvc;
using Models.Dbo.Game;
using Services.Core;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DialoguesController : BaseGameObjectController<Dialogue>
{
  public DialoguesController(NawiaDbContext dbContext) : base(dbContext)
  {
  }
}
