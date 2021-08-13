using System.Collections.Generic;

namespace Kedust.Data.Domain
{
    public class Menu : IDbLiteEntity<int>
    {
        public int Id { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}