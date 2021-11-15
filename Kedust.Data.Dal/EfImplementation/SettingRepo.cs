using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class SettingRepo : BaseRepo<Setting, int>, ISettingRepo
    {
        public SettingRepo(Context context) : base(context)
        {
        }

        public Task<Setting> GetByKey(string key) => Context.Settings.FirstOrDefaultAsync(s => s.Key == key);
    }
}