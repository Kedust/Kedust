using System.Net.Http;
using System.Security.Policy;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kedust.UI.PrinterService
{
    public interface IOrderServiceClient
    {
        Task<Services.DTO.OrderForPrinting> GetOrder(int id, CancellationToken token);
    }

    public class OrderServiceClient: IOrderServiceClient
    {
        private readonly Config _config;

        public OrderServiceClient(Config config)
        {
            _config = config;
        }

        public async Task<Services.DTO.OrderForPrinting> GetOrder(int id, CancellationToken token)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(string.Join('/', _config.Api, "Order", "Print", id), token);
            return JsonConvert.DeserializeObject<Services.DTO.OrderForPrinting>(json);
        }
    }
}