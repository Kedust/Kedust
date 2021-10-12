using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class OrderRepo : BaseRepo<Order, int>, Dal.IOrderRepo
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
    }
}