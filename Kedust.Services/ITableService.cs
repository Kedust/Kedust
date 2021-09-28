using System.Collections.Generic;
using System.Threading.Tasks;
using Kedust.Services.DTO;

namespace Kedust.Services
{
    public interface ITableService
    {
        Task<Table> GetById(int id);
        Task<IEnumerable<Table>> GetAll();
        Task<bool> Delete(int id);
        Task<int> Save(Table table);
        Task<string> GenerateCode();
    }
}