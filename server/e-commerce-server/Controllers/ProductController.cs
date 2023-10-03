using Microsoft.AspNetCore.Mvc;

namespace e_commerce_server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{

    private readonly ProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, ProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        var products = _productService.GetProducts();
        return products;
    }
}
