using CatalogAPI.Entities;
using CatalogAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public CatalogController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productRepository.GetProductsAsync();

        return Ok(products);
    }


    [HttpGet("{id:length(24)}", Name = "GetProduct")]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);

        if (product is null) return NotFound();

        return Ok(product);
    }


    [Route("[action]/{category}", Name = "GetProductByCategory")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
    {
        if (category is null) return BadRequest("Invalid category");

        var products = await _productRepository.GetProductByCategoryAsync(category);

        return Ok(products);
    }


    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        if (product is null) return BadRequest("Invalid product");

        await _productRepository.CreateProductAsync(product);

        return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        if (product is null) return BadRequest("Invalid product");

        return Ok(await _productRepository.UpdateProductAsync(product));
    }


    [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
    public async Task<IActionResult> DeleteProductById(string id)
    {
        return Ok(await _productRepository.DeleteProductByIdAsync(id));
    }

}
