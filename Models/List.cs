namespace TaskMasterCSharp.Models
{
  public class List
  {
    public string Title { get; set; }
    public string Body { get; set; }
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}