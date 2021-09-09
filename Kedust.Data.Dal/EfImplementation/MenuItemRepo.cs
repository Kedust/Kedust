using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class MenuItemRepo: BaseRepo<MenuItem, int>, IMenuItemRepo
    {
        public MenuItemRepo(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<MenuItem>> GetByTableCode(string tableCode)
        {
            var SQL = Context
                .Tables
                .Where(t => t.Code == tableCode)
                .Select(t => t.Menu)
                .SelectMany(m => m.MenuItems)
                .ToQueryString();
            
            return await Context
                .Tables
                .Where(t => t.Code == tableCode)
                .Select(t => t.Menu)
                .SelectMany(m => m.MenuItems)
                .ToListAsync();
        }
    }
}