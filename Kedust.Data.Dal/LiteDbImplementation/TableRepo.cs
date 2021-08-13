using Kedust.Data.Domain;

namespace Kedust.Data.Dal.LiteDbImplementation
{
    public class TableRepo : BaseRepo<Table, string>, ITableRepo
    {
        public TableRepo(LiteDbContext liteDb) : base(liteDb)
        {
        }
    }
}