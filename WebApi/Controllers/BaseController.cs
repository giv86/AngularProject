using Microsoft.AspNetCore.Mvc;
using Services.Core;
using Services.Player;

namespace WebApi.Controllers;

public class BaseController : Controller
{
  public readonly NawiaDbContext DbContext;

  public Account ServiceAccount;
  public Authentication ServiceAuthentication;


  public BaseController(NawiaDbContext dbContext)
  {
    DbContext = dbContext;
    ServiceAuthentication = new (dbContext);
    ServiceAccount = new (dbContext);
  }
}
