using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Dbo.Dictionaries;

public class BaseDictionary
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public int From { get; set; }
  public int To { get; set; }

  public ModelType ModelType { get; set; }

  public DateTime CreatedTime { get; set; } = DateTime.Now;
}
