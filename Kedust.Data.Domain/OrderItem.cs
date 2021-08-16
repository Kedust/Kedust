namespace Kedust.Data.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Amount { get; set; }
    }
}