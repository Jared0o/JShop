namespace JShop.Infrastructure.Dto.Tax
{
    public class TaxResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public TaxResponse(int id, string name, int value)
        {
            Id = id;
            Name = name;
            Value = value;
        }
    }
}
