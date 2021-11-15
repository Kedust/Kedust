using System.Threading.Tasks;
using Kedust.Services.DTO;
using Kedust.UI.PrinterService.TicketDefinitions;

namespace Kedust.UI.PrinterService
{
    public class PrintService
    {
        private const string FontTitle = "Cambria Math";

        public Task PrintOrderTicket(OrderForPrinting order, Config config)
        {
            KitchenTicket kitchenTicket = new KitchenTicket();
            kitchenTicket.Print(config.PrinterName, order);
            OrderTicket orderTicket = new OrderTicket();
            orderTicket.Print(config.PrinterName, order);
            return Task.CompletedTask;
        }
    }
}