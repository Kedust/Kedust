using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class TableRepo: BaseRepo<Table, int>, ITableRepo
    {
        public TableRepo(Context context) : base(context)
        {
        }

        public async Task<bool> CodeExists(string code) => await Context.Tables.AnyAsync(t => t.Code == code);
    }
}