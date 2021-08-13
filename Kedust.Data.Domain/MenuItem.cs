namespace Kedust.Data.Domain
{
    public class MenuItem: IDbLiteEntity<int>
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}