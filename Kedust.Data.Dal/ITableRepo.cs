using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal
{
    public interface ITableRepo: IBaseRepo<Table, int>
    {
        Task<bool> CodeExists(string code);
    }
}