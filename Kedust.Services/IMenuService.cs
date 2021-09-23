using System.Collections.Generic;
using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Services
{
    public interface IMenuService
    {
        Task<int> Save(Menu menu, IEnumerable<Choice> choices);
    }
}