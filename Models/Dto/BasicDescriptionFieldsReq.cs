using Models.Dbo.Dictionaries;

namespace Models.Dto;

public class BasicDescriptionFieldsReq
{
  public string Description { get; set; }
  public string Name { get; set; }
  public string DisplayText { get; set; }

  public ModelType ModelType { get; set; }
}
