namespace Kedust.Services.DTO
{
    public class Choice
    {
        public int Id { get; set; }
        public bool IsKitchen { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Image { get; set; }

        public int Sorting { get; set; }
    }
}