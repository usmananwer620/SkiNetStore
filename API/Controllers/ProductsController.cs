using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storeContext;

        public ProductsController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _storeContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("product")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var product = await _storeContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product == null)
                return NotFound($"Product with id {productId} is not found.");

            return Ok(product);
        }

    }
}