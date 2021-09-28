using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore.Query;

namespace Kedust.Data.Dal
{
    public interface IBaseRepo<T, Tid>
    {
        IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> GetById(Tid id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(T obj);
    }
}