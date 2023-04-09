namespace Models.Dto
{
  public class BasicRes
  {
    public List<object>? Entities { get; set; }

    public bool EntitiesHasAnyElement => Entities?.Count > 0;

    public bool IsSuccess => ErrorsDictionary.Count == 0;

    public Dictionary<string, bool> ServicesDictionary { get; set; } = new();

    public Dictionary<string, string> ErrorsDictionary { get; set; } = new();
  }
}
