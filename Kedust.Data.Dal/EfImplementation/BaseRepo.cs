using System;
using System.Linq;
using System.Threading.Tasks;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Kedust.Data.Dal.EfImplementation
{
    internal class BaseRepo<T, TId> : IBaseRepo<T, TId> where T : BaseEntity<TId> where TId : IEquatable<TId>
    {
        protected readonly Context Context;

        protected BaseRepo(Context context)
        {
            Context = context;
        }

        public virtual IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = Context.Set<T>().AsQueryable();
            if (include != null)
                query = include.Invoke(query);
            return query;
        }

        public virtual async Task<T> GetById(TId id,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = GetAll(include);
            return await query.FirstOrDefaultAsync(t => t.Id.Equals(id));
        }


        public virtual async Task<T> Insert(T obj)
        {
            var result = await Context.AddAsync(obj);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<T> Update(T obj)
        {
            var result = Context.Update(obj);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<T> Delete(T obj)
        {
            var result = Context.Set<T>().Remove(obj);
            await Context.SaveChangesAsync();
            return result.Entity;
        }
    }
}