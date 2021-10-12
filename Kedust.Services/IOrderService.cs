using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Kedust.Services.DTO;

namespace Kedust.Services
{
    public interface IOrderService
    {
        Task<int> Save(OrderForSaving saveOrder);
        Task<OrderForPrinting> GetById(int id, CancellationToken token);
    }
}