namespace CreditAgricole.Domain
{
    public class Product : BaseModel
    {
        public string Name { get; private set; }

        public Product(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
