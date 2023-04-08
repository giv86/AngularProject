using Microsoft.EntityFrameworkCore;
using Models.Dbo.Account;
using Models.Dbo.Dictionaries;
using Models.Dbo.Game;
using Action = Models.Dbo.Game.Action;

namespace Services.Core;

public class NawiaDbContext : DbContext
{
  public NawiaDbContext(DbContextOptions<NawiaDbContext> options)
    : base(options)
  {
  }

  public DbSet<Hero> Heroes { get; set; }
  public DbSet<User> Users { get; set; }

  public DbSet<Action> Actions { get; set; }
  public DbSet<Conversation> Conversations { get; set; }
  public DbSet<Dialogue> Dialogues { get; set; }
  public DbSet<Location> Locations { get; set; }

  public DbSet<Models.Dbo.Dictionaries.Attachment> ActionsDictionary { get; set; }
  public DbSet<ConversationsToLocation> ConversationsToLocations { get; set; }
  public DbSet<DialoguesToConversation> DialoguesToConversations { get; set; }
  public DbSet<HeroesToUser> HeroesToUsers { get; set; }
  public DbSet<LocationsToHero> LocationsToUsers { get; set; }
  public DbSet<Models.Dbo.Dictionaries.Attachment> Attachments { get; set; }
}
