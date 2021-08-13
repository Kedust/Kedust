using Kedust.Data.Domain;

namespace Kedust.Data.Dal.LiteDbImplementation
{
    public class OrderItemRepo : BaseRepo<OrderItem, int>, IOrderItemRepo
    {
        public OrderItemRepo(LiteDbContext liteDb) : base(liteDb)
        {
        }
    }
}