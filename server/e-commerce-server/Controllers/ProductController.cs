using Microsoft.AspNetCore.Mvc;

namespace e_commerce_server.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{

    private readonly ProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(
        ILogger<ProductController> logger,
         ProductService productService
         )
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet("GetProducts")]
    public async Task<List<Product>> GetProducts()
    {
        var products = await _productService.GetAll();
        return products.ToList();
    }

    [HttpGet("GetProduct/{productId}")]
    public async Task<Product> GetProduct(int productId){
        var product = await _productService.Get(productId);
        return product;
    }
}
