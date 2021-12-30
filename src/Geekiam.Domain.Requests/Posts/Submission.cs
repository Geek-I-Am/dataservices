namespace Geekiam.Domain.Requests.Posts;

public class Submission
{
    public Article Article { get; set; }
    public Content Content { get; set; }
    public Metadata Metadata { get; set; }
    
}