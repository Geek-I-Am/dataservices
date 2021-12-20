using System.Collections.Generic;

namespace Geekiam.Domain.Requests.Posts;

public class Submission
{
    public Detail Article { get; set; }
    public IList<Section> Tags { get; set; }
    public IList<Section> Categories { get; set; }
    
}