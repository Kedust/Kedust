using System.Collections.Generic;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class MenuRepo: BaseRepo<Menu, int>, IMenuRepo
    {
        public MenuRepo(Context context) : base(context)
        {
        }
    }
}