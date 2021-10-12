using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal
{
    public interface ITableRepo: IBaseRepo<Table, int>
    {
        Task<int> CodeExists(string code);
    }
}