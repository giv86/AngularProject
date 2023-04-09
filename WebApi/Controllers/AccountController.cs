using Microsoft.AspNetCore.Mvc;
using Models.Dto.User;
using Services.Core;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : BaseAccountController
{
  public AccountController(NawiaDbContext dbContext) : base(dbContext)
  {
  }

  [HttpPost("AuthenticateUser")]
  public IActionResult Authenticate([FromBody] LoginReq request)
  {
    if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
      return BadRequest();

    var result = ServiceAccount.AuthenticateUser(request);

    return result.IsSuccess
      ? Ok(result)
      : BadRequest(result);
    
  }
  
  [HttpPost("RegisterUser")]
  public IActionResult Register([FromBody] RegisterReq request)
  {
    if (string.IsNullOrEmpty(request.Username)
        || string.IsNullOrEmpty(request.Password)
        || string.IsNullOrEmpty(request.Email)) return BadRequest();

    var result = ServiceAccount.CreateUser(request);

    return result.IsSuccess ? Ok(result) : BadRequest(result);
  }

  [HttpPost("DeleteAllUsers")]
  public IActionResult DeleteAllUsers()
  {
    var result = ServiceAccount.RemoveAllUsers();

    return result.IsSuccess
      ? Ok(result)
      : BadRequest(result);
  }
}
