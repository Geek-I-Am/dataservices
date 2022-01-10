using System;

namespace Geekiam.Domain.Requests.Posts;

public class Body
{
  
    public string Summary { get; set; }
    public string Content { get; set; }
    public DateTime Published { get; set; }
  
}