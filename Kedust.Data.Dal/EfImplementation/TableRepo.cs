using System;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class TableRepo : BaseRepo<Table, int>, ITableRepo
    {
        public TableRepo(Context context) : base(context)
        {
        }

        public async Task<Table> GetByCode(string code,
            Func<IQueryable<Table>, IIncludableQueryable<Table, object>> include = null)
        {
            var query = Context.Tables.AsQueryable();
            if (include != null)
                query = include.Invoke(query);
            return await query.FirstOrDefaultAsync(t => t.Code == code);
        }
        public async Task<Table> GetByDescription(string description,
            Func<IQueryable<Table>, IIncludableQueryable<Table, object>> include = null)
        {
            var query = Context.Tables.AsQueryable();
            if (include != null)
                query = include.Invoke(query);
            return await query.SingleOrDefaultAsync(t => t.Description.Contains(description));
        }
    }
}