using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal
{
    public interface ISettingRepo : IBaseRepo<Setting, int>
    {
        Task<Setting> GetByKey(string key);
    }
}