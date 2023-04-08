using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Dbo.Dictionaries;

namespace Models.Dbo;

public class BaseModel
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  public DateTime Created { get; set; } = DateTime.Now;

  public DateTime Updated { get; set; } = DateTime.Now;

  public string Salt { get; set; }

  public ModelType ModelType { get; set; }
}
