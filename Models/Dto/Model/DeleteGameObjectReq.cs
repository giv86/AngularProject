using Models.Dbo.Dictionaries;

namespace Models.Dto.Model;

public class DeleteGameObjectReq
{
  public int Id { get; set; }
  public ModelType ModelType { get; set; }
}
