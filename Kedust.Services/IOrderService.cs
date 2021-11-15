using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kedust.Services.DTO;

namespace Kedust.Services
{
    public interface IOrderService
    {
        Task<int> Save(OrderForSaving saveOrder);
        Task<OrderForPrinting> GetByIdForPrinting(int id, CancellationToken token);
        Task<List<OrderForPrinting>> GetAllForPrinting(CancellationToken token);
        Task MarkPrinted(int id, CancellationToken token);
    }
}