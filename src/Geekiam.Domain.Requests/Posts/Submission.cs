namespace Geekiam.Domain.Requests.Posts;

public class Submission
{
    public Article Article { get; set; }
    public Body Body { get; set; }
    public Metadata Metadata { get; set; }
    
}