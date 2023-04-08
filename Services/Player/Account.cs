using Models.Dbo.Account;
using Models.Dto;
using Models.Dto.User;
using Services.Core;

namespace Services.Player;

public class Account
{
  private readonly NawiaDbContext _dbContext;

  public Account(NawiaDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public BasicRes CreateUser(RegisterReq request)
  {
    if (DoesUserExist(request)) return new BasicRes();
    ;

    var salt = Encryption.GenerateSalt();

    var user = new Models.Dbo.Account.User
    {
      Created = DateTime.Now,
      Updated = DateTime.Now,
      Username = Encryption.Encode(request.Username, salt),
      Password = Encryption.Encode(request.Password, salt),
      Email = Encryption.Encode(request.Email, salt),
      Role = UserRole.User,
      Salt = salt
    };

    _dbContext.Users.Add(user);

    var result = _dbContext.SaveChanges() > 0;

    if (result) return new BasicRes();
    return new BasicRes();
  }

  private bool DoesUserExist(RegisterReq request)
  {
    var users = _dbContext.Users.ToList();

    var result = users.Any();
    return result && users.Any(x => x.Username == Encryption.Encode(request.Username, x.Salt));
  }
}
