//Abstract Factory Pattern
public class SimpleProductFactory : IProductFactory
{
    public Product CreateProduct()
    {
        return new Product();
    }
}

public class SpecialProductFactory : IProductFactory
{
    public Product CreateProduct()
    {
        return new Product
        {
            Name = "Special Product",
            Price = 99.99m
        };
    }
}
