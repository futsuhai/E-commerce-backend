using Microsoft.AspNetCore.Mvc;

namespace e_commerce_server.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(
        ILogger<ProductController> logger,
         IProductService productService
         )
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet("GetProducts")]
    public async Task<List<Product>> GetProducts()
    {
        var products = await _productService.GetAllAsync();
        return products.ToList();
    }

    [HttpGet("GetProduct/{productId}")]
    public async Task<Product> GetProduct(Guid productId)
    {
        var product = await _productService.GetAsync(productId);
        return product;
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        await _productService.CreateAsync(product);
        return Ok("Продукт добавлен");
    }

    [HttpPost("DeleteProduct/{productId}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        await _productService.DeleteAsync(productId);
        return Ok("Продукт удален");
    }

    [HttpPut("UpdateProduct/{productId}")]
    public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] Product product)
    {
        await _productService.UpdateAsync(productId, product);
        return Ok("Продукт изменен");
    }
}
