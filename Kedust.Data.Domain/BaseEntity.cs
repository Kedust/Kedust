using System.ComponentModel.DataAnnotations;

namespace Kedust.Data.Domain
{
    public class BaseEntity<TId>
    {
        [Key]
        public TId Id { get; set; }
    }
}