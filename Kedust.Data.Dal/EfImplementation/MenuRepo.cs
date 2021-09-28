using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class MenuRepo: BaseRepo<Menu, int>, IMenuRepo
    {
        public MenuRepo(Context context) : base(context)
        {
            
        }
    }
}