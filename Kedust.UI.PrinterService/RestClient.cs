using System.Net.Http;
using System.Threading.Tasks;

namespace Kedust.UI.PrinterService
{
    public static class RestClient
    {
        public static Task<string> GetOrders()
        {
            HttpClient client = new HttpClient();
            return client.GetStringAsync("https://localhost:5001/Menu");
        }
    }
}