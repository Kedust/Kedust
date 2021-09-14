using Kedust.Data.Domain;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class OrderRepo: BaseRepo<Order,int>, Dal.IOrderRepo
    {
        public OrderRepo(Context context) : base(context)
        {
        }
    }
}