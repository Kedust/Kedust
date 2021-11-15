using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore.Query;

namespace Kedust.Data.Dal
{
    public interface IOrderRepo: IBaseRepo<Order,int>
    {
        Task<bool> BulkUpdate(List<Order> orders);

        Task<List<Order>> GetAllForPrinting(CancellationToken token,
            Func<IQueryable<Order>, IIncludableQueryable<Order, object>> include = null);
    }
}