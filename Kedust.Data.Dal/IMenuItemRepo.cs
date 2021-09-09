using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal
{
    public interface IMenuItemRepo: IBaseRepo<MenuItem, int>
    {
        Task<IEnumerable<MenuItem>> GetByTableCode(string tableCode);
    }
}