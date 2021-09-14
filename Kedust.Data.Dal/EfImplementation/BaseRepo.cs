using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class BaseRepo<T, TId> : IBaseRepo<T, TId> where T:BaseEntity<TId>
    {
        protected readonly Context Context;

        protected BaseRepo(Context context)
        {
            Context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsEnumerable();
        }

        public async Task<T> GetById(TId id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        

        public async Task<T> Insert(T obj)
        {
            var result = await Context.AddAsync(obj);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<T> Update(T obj)
        {
            var result = Context.Update(obj);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<T> Delete(T obj)
        {
            var result = Context.Set<T>().Remove(obj);
            await Context.SaveChangesAsync();
            return result.Entity;
        }
    }
}