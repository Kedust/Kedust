namespace Kedust.Data.Domain
{
    public class Setting : BaseEntity<int>
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}