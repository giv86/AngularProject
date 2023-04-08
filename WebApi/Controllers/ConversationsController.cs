using Microsoft.AspNetCore.Mvc;
using Models.Dbo.Game;
using Services.Core;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversationsController : BaseGameObjectController<Conversation>
{
  public ConversationsController(NawiaDbContext dbContext) : base(dbContext)
  {
  }
}
