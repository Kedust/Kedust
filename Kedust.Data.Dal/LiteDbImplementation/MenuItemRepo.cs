using Kedust.Data.Domain;

namespace Kedust.Data.Dal.LiteDbImplementation
{
    public class MenuItemRepo : BaseRepo<MenuItem, int>, IMenuItemRepo
    {
        public MenuItemRepo(LiteDbContext liteDb) : base(liteDb)
        {
        }
    }
}