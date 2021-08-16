using System;
using System.Collections.Generic;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal
{
    public interface IBaseRepo<T, Tid>
    {
        T GetById(Tid id);
        T Insert(T obj);
        T Update(T obj);
        T Delete(T obj);
    }
}