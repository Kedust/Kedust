using System.Collections.Generic;

namespace Kedust.Services.Menu
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Choice> Choices { get; set; }
    }
}