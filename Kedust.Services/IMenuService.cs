using System.Collections.Generic;
using System.Threading.Tasks;
using Kedust.Services.DTO;

namespace Kedust.Services
{
    public interface IMenuService
    {
        Task<Menu> GetById(int id);
        Task<int> Save(Menu menu);
        Task<IEnumerable<Menu>> GetAll();
        Task<IEnumerable<Choice>> GetByTableCode(string tableCode);
        Task<bool> Delete(int id);
    }
}