using System.Threading.Tasks;

namespace Kedust.Services
{
    public interface ISettingService
    {
        Task<(bool succes, string value)> TryGetByKey(string key);
        Task SetByKey(string key, string value);
    }
}