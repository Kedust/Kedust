using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class ChoiceRepo: BaseRepo<Choice, int>, IChoiceRepo
    {
        public ChoiceRepo(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Choice>> GetByTableCode(string tableCode)
        {
            return await Context
                .Tables
                .Where(t => t.Code == tableCode)
                .Select(t => t.Menu)
                .SelectMany(m => m.MenuItems)
                .ToListAsync();
        }
    }
}