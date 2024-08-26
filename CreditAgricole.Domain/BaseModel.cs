namespace CreditAgricole.Domain
{
    public abstract class BaseModel
    {
        public int Id { get; private set; }

        internal BaseModel(int id)
        {
            Id = id;
        }
    }
}
