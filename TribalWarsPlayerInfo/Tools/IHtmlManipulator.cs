using AngleSharp.Dom;

namespace TribalWarsPlayerInfo.Tools;

public interface IHtmlManipulator
{
    Task<IDocument> ProcessHtmlString(string htmlString);
}