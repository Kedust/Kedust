using Kedust.Data.Domain;

namespace Kedust.Data.Dal.LiteDbImplementation
{
    public class MenuRepo : BaseRepo<Menu, int>, IMenuRepo
    {
        public MenuRepo(LiteDbContext liteDb) : base(liteDb)
        {
        }
    }
}