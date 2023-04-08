using Models.Dbo.Dictionaries;

namespace Models.Dto.Attachment;

public class FromToStructure
{
  public int IdFrom { get; set; }
  public int IdTo { get; set; }

  public ModelType ModelTypeOfFrom { get; set; }
  public ModelType ModelTypeOfTo { get; }
}
