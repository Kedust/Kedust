using LiteDB;

namespace Kedust.Data.Domain
{
    public interface IDbLiteEntity<T>
    {
        [BsonId]
        public T Id { get; set; }
    }
}