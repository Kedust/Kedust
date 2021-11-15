using System.Threading.Tasks;
using Kedust.Data.Dal;
using Kedust.Data.Domain;

namespace Kedust.Services.Implementation
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepo _settingRepo;

        public SettingService(ISettingRepo settingRepo)
        {
            _settingRepo = settingRepo;
        }

        public async Task<(bool succes, string value)> TryGetByKey(string key)
        {
            Setting setting = await _settingRepo.GetByKey(key);
            if (setting == null) return (false, null);
            return (true, setting.Value);
        }

        public async Task SetByKey(string key, string value)
        {
            Setting setting = await _settingRepo.GetByKey(key);
            if (setting != null)
            {
                setting.Value = value;
                await _settingRepo.Update(setting);
            }
            else
            {
                await _settingRepo.Insert(new Setting
                {
                    Key = key, Value = value
                });
            }
            
            
        }
    }
}