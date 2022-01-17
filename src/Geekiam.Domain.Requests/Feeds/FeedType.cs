namespace Geekiam.Domain.Requests.Feeds;


public enum FeedType
{
    /// <summary>
    /// Atom Feed
    /// </summary>
    Atom,

    /// <summary>
    /// Rss 0.91 feed
    /// </summary>
    Rss091,

    /// <summary>
    /// Rss 0.92 feed
    /// </summary>
    Rss092,

    /// <summary>
    /// Rss 1.0 feed
    /// </summary>
    Rss10,

    /// <summary>
    /// Rss 2.0 feed
    /// </summary>
    Rss20,

    /// <summary>
    /// Media Rss feed
    /// </summary>
    MediaRss,


    /// <summary>
    /// Rss feed - is used for <see cref="Feed"/> type
    /// </summary>
    Rss,

    /// <summary>
    /// Unknown - default type
    /// </summary>
    Unknown
}