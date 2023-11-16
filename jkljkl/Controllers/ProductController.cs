// File: Controllers/ProductController.cs

using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductManager _productManager;

        public ProductController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("simple")]
        public ActionResult<Product> GetSimpleProduct()
        {
            // Using the Factory Method
            return _productManager.CreateProduct();
        }

        [HttpGet("special")]
        public ActionResult<Product> GetSpecialProduct()
        {
            // Creating a Special Product using a different factory
            var specialProductFactory = new SpecialProductFactory();
            var specialProductManager = new ProductManager(specialProductFactory);

            // Using the Factory Method with a different factory
            return specialProductManager.CreateProduct();
        }

        [HttpGet("custom")]
        public ActionResult<Product> GetCustomProduct()
        {
            // Using the Builder Pattern to create a custom product
            var customProduct = new ProductBuilder()
                .WithName("Custom Product")
                .WithPrice(49.99m)
                .Build();

            return customProduct;
        }
    }
}
