using AngleSharp;
using AngleSharp.Dom;

namespace TribalWarsPlayerInfo.Helpers;

public class HtmlManipulator : IHtmlManipulator
{
    public async Task<IDocument> ProcessHtmlString(string htmlString)
    {
        var config = Configuration.Default;
        var context = BrowsingContext.New(config);

        return await context.OpenAsync(req => req.Content(htmlString));
    }

    public string CleanHtmlTextContent(string textContent) =>
      textContent
        .Replace("\\n", "")
        .Replace("\\t", "")
        .Trim();
}