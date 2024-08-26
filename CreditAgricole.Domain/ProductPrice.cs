namespace CreditAgricole.Domain;
public class ProductPrice
{
    public int ProductId { get; private set; }
    public Price Price { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public ProductPrice(
        int productId,
        Price price)
    {
        ProductId = productId;
        Price = price;
        UpdatedAt = DateTime.Now;
    }
}

