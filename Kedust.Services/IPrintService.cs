using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Services
{
    public interface IPrintService
    {
         Task PrintOrder(Order order);
    }
}