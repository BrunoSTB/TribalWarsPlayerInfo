using AngleSharp.Dom;

namespace TribalWarsPlayerInfo.Helpers;

public interface IHtmlManipulator
{
    Task<IDocument> ProcessHtmlString(string htmlString);
    string CleanHtmlTextContent(string textContent);
}
