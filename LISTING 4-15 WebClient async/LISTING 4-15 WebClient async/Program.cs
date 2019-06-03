using System.Net;
using System.Threading.Tasks;

namespace LISTING_4_15_WebClient_async
{
    class Program
    {
        static async Task<string> readWebpage(string uri)
        {
            WebClient client = new WebClient();
            return await client.DownloadStringTaskAsync(uri);
        }

        static void Main(string[] args)
        {
            readWebpage("http://www.microsoft.com");
        }
    }
}