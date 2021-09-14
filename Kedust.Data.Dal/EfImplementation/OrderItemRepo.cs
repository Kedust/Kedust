using Kedust.Data.Domain;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class OrderItemRepo : BaseRepo<OrderItem, int>, Dal.IOrderItemRepo
    {
        public OrderItemRepo(Context context) : base(context)
        {
        }
    }
}