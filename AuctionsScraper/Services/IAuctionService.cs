using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AuctionsScraper.Models;

namespace AuctionsScraper
{
    public interface IAuctionService
    {
        Task<IList<string>> FindAuctionsAddressesAsync(string address);
    }
}