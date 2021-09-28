using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kedust.Services
{
    public interface ITableService
    {
        Task<Menu.Table> GetById(int id);
        Task<IEnumerable<Menu.Table>> GetAll();
        Task<bool> Delete(int id);
    }
}