namespace Geekiam.Domain.Requests.Posts;

public class Submission
{
    public Detail Article { get; set; }
    public IList<string> Tags { get; set; }
    public IList<string> Categories { get; set; }
    
}