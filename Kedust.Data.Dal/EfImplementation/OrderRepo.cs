using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class OrderRepo : BaseRepo<Order, int>, IOrderRepo
    {
        private DbSet<Order> OrderSet => Context.Orders;

        public OrderRepo(Context context) : base(context)
        {
        }

        public async Task<bool> BulkUpdate(List<Order> orders)
        {
            OrderSet.UpdateRange(orders);
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<List<Order>> GetAll(DateTime from, DateTime till, CancellationToken token,
            Func<IQueryable<Order>, IIncludableQueryable<Order, object>> include = null)
        {
            var query = OrderSet.AsQueryable();
            if (include != null)
                query = include.Invoke(query);
            return await query.Where(x => x.TimeOrderPlaced > from && x.TimeOrderPlaced < till).ToListAsync(token);
        }

        public async Task<List<Order>> GetAllForPrinting(CancellationToken token,
            Func<IQueryable<Order>, IIncludableQueryable<Order, object>> include = null)
        {
            var query = OrderSet.AsQueryable();
            if (include != null)
                query = include.Invoke(query);
            return await query.Where(x => x.Status == OrderStatus.New && x.TimeOrderPlaced < DateTime.Now.AddSeconds(-15)).ToListAsync(token);
        }
    }
}