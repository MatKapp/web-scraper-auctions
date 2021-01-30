using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AuctionsScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true);

            var configuration = builder.Build();

            var webScraper = new WebScraper.WebScraper();
            var auctionsAddresses = await FindAuctionsAddresses(webScraper, configuration);
        }

        private static async Task<IList<string>> FindAuctionsAddresses(WebScraper.WebScraper webScraper, IConfigurationRoot configuration)
        {
            AuctionService service = new AuctionService(webScraper);
            var addresses = await service.FindAuctionsAddressesAsync(configuration.GetSection("StoreAddress").Value);
            var distinctAddresses = addresses.Distinct();
            Console.WriteLine(addresses);
            return addresses;
        }
    }
}
