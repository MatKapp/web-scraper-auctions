using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp.Dom;

namespace WebScraper
{
    public class DocumentAnalyzer : IDocumentAnalyzer
    {
        private const string NextPageSelector = ".next .pageNextPrev";

        public IList<IElement> FindElementsWithMatchingTextContent(IDocument document, Regex regexToBeMatched)
            => document.QuerySelectorAll("*")
            .Where(child => regexToBeMatched.IsMatch(child.TextContent))
            .ToList();

        public string FindNextPageAddress(IDocument document)
        {
            var nextPageElement = document.QuerySelector(NextPageSelector);
            return nextPageElement.GetAttribute("Href");
        }

        public IList<string> FindUrlsWithinSelector(IDocument document, string selector)
        {
            var elements = document.QuerySelectorAll(selector);
            var addresses = elements
                .Select(element => (element as AngleSharp.Html.Dom.IHtmlAnchorElement)?.Href)
                .Distinct();
            return addresses.ToList();
        }
    }
}
