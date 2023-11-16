//Factory Method Pattern
namespace YourProjectNamespace{
    
}
public class ProductManager
{
    private readonly IProductFactory _productFactory;

    public ProductManager(IProductFactory productFactory)
    {
        _productFactory = productFactory;
    }

    // Factory Method
    public Product CreateProduct()
    {
        return _productFactory.CreateProduct();
    }
}
