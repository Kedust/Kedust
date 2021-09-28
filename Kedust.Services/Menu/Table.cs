using System.Collections.Generic;

namespace Kedust.Services.Menu
{
    public class Table
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Menu Menu { get; set; }
    }
}