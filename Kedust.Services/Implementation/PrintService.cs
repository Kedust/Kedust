using System.Threading.Tasks;

namespace Kedust.Services.Implementation
{
    public class PrintService: IPrintService
    {
        public Task PrintOrderTicket()
        {
            return Task.CompletedTask;
        }
    }
}