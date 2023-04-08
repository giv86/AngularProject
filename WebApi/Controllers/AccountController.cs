using Microsoft.AspNetCore.Mvc;
using Models.Dto.User;
using Services.Core;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : BaseController
{
  public AccountController(NawiaDbContext dbContext) : base(dbContext)
  {
  }

  [HttpPost("AuthenticateUser")]
  public IActionResult Authenticate([FromBody] LoginReq request)
  {
    if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
      return BadRequest();

    var result = ServiceAuthentication.AuthenticateUser(request);
    if (result == null)
      return BadRequest(new LoginRes { IsAuthenticated = false });

    if (result.IsAuthenticated)
      return Ok(result);

    return BadRequest(new LoginRes
    {
      IsAuthenticated = false
    });
  }


  [HttpPost("RegisterUser")]
  public IActionResult Register([FromBody] RegisterReq request)
  {
    if (string.IsNullOrEmpty(request.Username)
        || string.IsNullOrEmpty(request.Password)
        || string.IsNullOrEmpty(request.Email)) return BadRequest();

    var result = ServiceAccount.CreateUser(request);

    return result.IsSuccess ? Ok() : BadRequest();
  }
}
