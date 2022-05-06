namespace JShop.Infrastructure.Dto.Tax
{
    public class TaxRequest
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public TaxRequest(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
