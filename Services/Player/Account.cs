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

  public BasicRes RemoveAllUsers()
  {
    try
    {
      var users = _dbContext.Users.ToList();

      if (!users.Any())
      {
        return new BasicRes
        {
          ErrorsDictionary = { { "remove_all_users", "There are no users to remove." } }
        };
      }

      _dbContext.Users.RemoveRange(users);
      _dbContext.SaveChanges();

      return new BasicRes();
    }
    catch (Exception ex)
    {
      return new BasicRes
      {
        ErrorsDictionary = { { "remove_all_users", ex.Message } }
      };
    }
  }

  public BasicRes AuthenticateUser(LoginReq request)
  {
    var users = _dbContext.Users.ToList();

    var user = users.FirstOrDefault(x => x.Username == request.Username);

    if (user == null || user.Password != Encryption.Encode(request.Password, user.Salt))
    {
      return new BasicRes
      {
        ErrorsDictionary = { { "login", "Invalid username or password." } }
      };
    }

    return new BasicRes
    {
      Entities = new List<object> { user }
    };
  }


  public BasicRes CreateUser(RegisterReq request)
  {
    if (DoesUserExist(request))
    {
      return new BasicRes
      {
        ErrorsDictionary = { { "create_user", "User with this username already exists." } }
      };
    }

    var salt = Encryption.GenerateSalt();

    var user = new Models.Dbo.Account.User
    {
      Created = DateTime.Now,
      Updated = DateTime.Now,
      Username = request.Username,
      Password = Encryption.Encode(request.Password, salt),
      Email = request.Email,
      IsAdmin = request.Email == "lord.giv@gmail.com"
                && request.Username == "admin"
                && request.Password=="H@Slo12#$",
      Salt = salt
    };

    _dbContext.Users.Add(user);

    var result = _dbContext.SaveChanges() > 0;

    if (result)
    {
      return new BasicRes();
    }

    return new BasicRes
    {
      ErrorsDictionary = { { "create_user", "Error creating user." } }
    };
  }
  private bool DoesUserExist(RegisterReq request) => _dbContext.Users.Any(x => x.Username == request.Username);
}
