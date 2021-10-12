using System.Collections.Generic;

namespace Kedust.Services.DTO
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Choice> Choices { get; set; }
    }
}