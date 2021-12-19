using System;

namespace Geekiam.Domain.Requests.Posts;

public class Detail
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Author { get; set; }
    public DateTime Published { get; set; }
    public Uri Url { get; set; }
}