using System.Collections.Generic;
using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal
{
    public interface IChoiceRepo: IBaseRepo<Choice, int>
    {
        Task<IEnumerable<Choice>> GetByTableCode(string tableCode);
        Task<IEnumerable<Choice>> GetByMenuId(int id);
    }
}