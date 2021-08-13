using System;
using System.Collections.Generic;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal
{
    public interface IBaseRepo<T, Tid> where T:IDbLiteEntity<Tid>
    {
        T Insert(T obj);
        T Update(T obj);
        T Delete(T obj);
    }
}