namespace Models.Dbo.Account;

public enum UserRole
{
  User = 1,
  Admin = 2
}

public class User : BaseModel
{
  public string Username { get; set; }
  public string Password { get; set; }
  public string Email { get; set; }
  public bool IsAdmin { get; set; }
}
