using Models.Dto.User;
using Services.Core;

namespace Services.Player;

public class Authentication
{
  private readonly NawiaDbContext _dbContext;

  public Authentication(NawiaDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public LoginRes? AuthenticateUser(LoginReq request)
  {
    var users = _dbContext.Users.ToList();

    var user = users.FirstOrDefault(x => x.Username == Encryption.Encode(request.Username, x.Salt));
    if (user == null
        || user.Password != Encryption.Encode(request.Password, user.Salt)) return null;

    return new LoginRes
    {
      Username = request.Username,
      Role = user.Role.ToString(),
      IsAuthenticated = true
    };
  }
}
