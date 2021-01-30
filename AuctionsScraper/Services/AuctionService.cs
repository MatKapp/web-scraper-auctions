using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AuctionsScraper.Models;
using WebScraper;

namespace AuctionsScraper
{
    public class AuctionService : IAuctionService
    {
        private const string AuctionDetailsSelector = ".detailsLink";
        private readonly DocumentAnalyzer _documentAnalyzer;
        private readonly WebScraper.WebScraper _webScraper;

        public AuctionService(WebScraper.WebScraper webScraper)
        {
            _documentAnalyzer = new DocumentAnalyzer();
            _webScraper = webScraper;
        }

        public async Task<IList<string>> FindAuctionsAddressesAsync(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return new List<string>();
            }

            var document = await _webScraper.LoadDocumentAsync(address);
            var auctionsAddresses = _documentAnalyzer.FindUrlsWithinSelector(document, AuctionDetailsSelector) as List<string>;

            var nextPageAddress = _documentAnalyzer.FindNextPageAddress(document);
            var nextPageAddresses = await FindAuctionsAddressesAsync(nextPageAddress);
            auctionsAddresses.AddRange(nextPageAddresses);
            return auctionsAddresses;
        }
    }
}
