using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class TableRepo: BaseRepo<Table, int>, ITableRepo
    {
        public TableRepo(Context context) : base(context)
        {
        }
    }
}