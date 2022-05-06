namespace JShop.Infrastructure.Dto.Tax
{
    public class TaxResponse
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public TaxResponse(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
