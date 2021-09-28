using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kedust.Services
{
    public interface IMenuService
    {
        Task<Menu.Menu> GetById(int id);
        Task<int> Save(Menu.Menu menu);
        Task<IEnumerable<Menu.Menu>> GetAll();
        Task<IEnumerable<Menu.Choice>> GetByTableCode(string tableCode);
        Task<bool> Delete(int id);
    }
}