using System.Collections.Generic;
using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal
{
    public interface IOrderRepo: IBaseRepo<Order,int>
    {
        Task<bool> BulkUpdate(List<Order> orders);
    }
}