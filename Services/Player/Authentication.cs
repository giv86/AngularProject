using Models.Dto;
using Models.Dto.User;
using Services.Core;

namespace Services.Player
{
  public class Authentication
  {
    private readonly NawiaDbContext _dbContext;

    public Authentication(NawiaDbContext dbContext)
    {
      _dbContext = dbContext;
    }

   

  }
}
