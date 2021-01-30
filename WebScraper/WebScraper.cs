using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace WebScraper
{
    public class WebScraper
    {
        public IBrowsingContext Context { get; set; }

        public WebScraper()
        {
            CreateContext();
        }

        public async Task<IDocument> LoadDocumentAsync(string address)
            => await Context.OpenAsync(address);

        private void CreateContext()
        {
            var configuration = Configuration.Default.WithDefaultLoader();
            Context = BrowsingContext.New(configuration);
        }
    }
}
