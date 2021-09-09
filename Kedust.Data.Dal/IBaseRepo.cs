using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal
{
    public interface IBaseRepo<T, Tid>
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(Tid id);
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(T obj);
    }
}