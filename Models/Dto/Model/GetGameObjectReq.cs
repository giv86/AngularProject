using Models.Dbo.Dictionaries;

namespace Models.Dto.Model;

public class GetGameObjectReq
{
  public int Id { get; set; }

  public ModelType ModelType { get; set; }
}
