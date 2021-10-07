using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class OrderRepo : BaseRepo<Order, int>, Dal.IOrderRepo
    {
        public OrderRepo(Context context) : base(context)
        {
        }

        public Task<List<Order>> GetUnprinted()
        {
            return GetAll(order => order
                    .Include(o => o.Table)
                    .Include(o => o.OrderItems)
                    .ThenInclude(o => o.Choice)
                )
                .Where(o => o.PrintedAt == null)
                .ToListAsync();
        }
    }
}