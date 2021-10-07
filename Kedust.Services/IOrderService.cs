using System.Collections.Generic;
using System.Threading.Tasks;
using Kedust.Services.DTO;

namespace Kedust.Services
{
    public interface IOrderService
    {
        Task<int> Save(SaveOrder saveOrder);

        Task<IEnumerable<Order>> GetUnprintedOrders();
    }
}