namespace GenericsExample.Models;

public class Post : Requestable
{
    public string body { get; set; }
    public string title { get; set; }
    public string userId { get; set; }
    public int id { get; set; }
}