using System;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore.Query;

namespace Kedust.Data.Dal
{
    public interface ITableRepo : IBaseRepo<Table, int>
    {
        Task<Table> GetByCode(string code, Func<IQueryable<Table>, IIncludableQueryable<Table, object>> include = null);
    }
}