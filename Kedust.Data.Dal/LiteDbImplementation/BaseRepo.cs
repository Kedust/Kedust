using Kedust.Data.Domain;

namespace Kedust.Data.Dal.LiteDbImplementation
{
    public abstract class BaseRepo<T, Tid> : IBaseRepo<T, Tid> where T : IDbLiteEntity<Tid>
    {
        private readonly LiteDbContext _liteDb;

        public BaseRepo(LiteDbContext liteDb)
        {
            _liteDb = liteDb;
        }

        public T Insert(T obj)
        {
            var bson = _liteDb.Get<T>().Insert(obj);
            return _liteDb.Get<T>().FindById(bson);
        }

        public T Update(T obj)
        {
            var bson = _liteDb.Get<T>().Insert(obj);
            return _liteDb.Get<T>().FindById(bson);
        }

        public T Delete(T obj)
        {
            var bson = _liteDb.Get<T>().Insert(obj);
            return _liteDb.Get<T>().FindById(bson);
        }
    }
}