using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kedust.UI.PrinterService
{
    public interface IOrderServiceClient
    {
        Task<Services.DTO.OrderForPrinting> GetOrder(int id, CancellationToken token);
        Task<List<Services.DTO.OrderForPrinting>> GetAllOrders(CancellationToken token);
        Task SetPrinted(int id, CancellationToken token);
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
        public async Task<List<Services.DTO.OrderForPrinting>> GetAllOrders(CancellationToken token)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(string.Join('/', _config.Api, "Order", "Print"), token);
            return JsonConvert.DeserializeObject<List<Services.DTO.OrderForPrinting>>(json);
        }

        public async Task SetPrinted(int id, CancellationToken token)
        {
            HttpClient client = new HttpClient();
            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("id", id.ToString())
            });
            await client.PostAsync(string.Join('/', _config.Api, "Order", "Printed"), stringContent, token);
        }
    }
}