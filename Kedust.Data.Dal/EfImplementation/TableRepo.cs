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

        public async Task<int> CodeExists(string code) => (await Context.Tables.FirstOrDefaultAsync(t => t.Code == code))?.Id ?? 0;
    }
}