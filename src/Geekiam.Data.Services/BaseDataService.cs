using System.Globalization;
using System.Text;

namespace Geekiam.Data.Services;

public abstract class BaseDataService
{
    internal static string TransformTag(string tag)
    {
        var sb = new StringBuilder();

        var words = tag.Trim().Split(' ');

        if (words.Length < 1)
            return sb.Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tag.ToLower().Trim())).ToString();
        foreach (var word in words)
        {
            sb.Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.Trim().ToLower()));
        }

        return sb.ToString();
    }

    internal static string TransformPermalink(string tag)
    {
        var sb = new StringBuilder();

        var words = tag.Trim().Split(' ');

        if (words.Length < 1) return sb.Append(tag.ToLower().Trim()).ToString();
        
        words.ToList().ForEach(word =>
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                sb.Append($"{word}-");
            }
        });
        

        return sb.ToString().TrimEnd('-');
    }

    internal static string TransformCategory(string text)
    {
        var sb = new StringBuilder();

        var words = text.Trim().Split(' ');

        if (words.Length < 1) return sb.Append(text.ToLower().Trim()).ToString();
        
        words.ToList().ForEach(word =>
        {
            if (!string.IsNullOrWhiteSpace(word))
                sb.Append($" {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.Trim().ToLower())}");
        });

        return sb.ToString().Trim();
    }
    
}