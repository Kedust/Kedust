using Kedust.Data.Domain;

namespace Kedust.Data.Dal.LiteDbImplementation
{
    public class OrderRepo: BaseRepo<Order, int>, IOrderRepo
    {
        public OrderRepo(LiteDbContext liteDb) : base(liteDb)
        {
        }
    }
}