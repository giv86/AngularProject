namespace Models.Dbo.Dictionaries;

public enum ModelType
{
  Default = 0,
  Action = 1,
  Dialogue = 2,
  Conversation = 3,
  Location = 4,
  Hero = 5,
  User = 6
}

public class Attachment : BaseDictionary
{
  public ModelType ModelTypeOfFrom { get; set; }
  public ModelType ModelTypeOfTo { get; set; }
}
