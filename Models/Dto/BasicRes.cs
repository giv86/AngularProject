namespace Models.Dto;

public class BasicRes
{
  public List<object>? Entities { get; set; }

  public bool EntitiesHasAnyElement => Entities != null;

  public bool IsSuccess => ServicesDictionary.All(x => x.Value);

  public bool HasErrors => !ErrorsDictionary.Any();

  public Dictionary<string, bool> ServicesDictionary { get; set; } = new();

  public Dictionary<string, string> ErrorsDictionary { get; set; } = new();
}
