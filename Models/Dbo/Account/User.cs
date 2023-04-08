namespace Models.Dbo.Account;

public enum UserRole
{
  User,
  Admin
}

public class User : BaseModel
{
  public string Username { get; set; }
  public string Password { get; set; }
  public string Email { get; set; }
  public UserRole Role { get; set; }
}
