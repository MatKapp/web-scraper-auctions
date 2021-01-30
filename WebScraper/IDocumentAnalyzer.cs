using System.Collections.Generic;
using System.Text.RegularExpressions;
using AngleSharp.Dom;

namespace WebScraper
{
    public interface IDocumentAnalyzer
    {
        IList<string> FindUrlsWithinSelector(IDocument document, string selector);

        IList<IElement> FindElementsWithMatchingTextContent(IDocument document, Regex regexToBeMatched);

        string FindNextPageAddress(IDocument document);
    }
}
