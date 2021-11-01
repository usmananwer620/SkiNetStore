using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
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
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("product")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null)
                return NotFound($"Product with id {productId} is not found.");

            return Ok(product);
        }

        [HttpGet]
        [Route("product_brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _productRepository.GetProductBrandsAsync();
            if (productBrands == null)
                return BadRequest(StatusCodes.Status404NotFound);
            return Ok(productBrands);
        }

        [HttpGet]
        [Route("product_types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var productTypes = await _productRepository.GetProductTypesAsync();
            if (productTypes == null)
                return BadRequest(StatusCodes.Status404NotFound);

            return Ok(productTypes);
        }

        [HttpGet]
        [Route("product_type")]
        public async Task<ActionResult<ProductType>> GetProductTypeById(int productTypeId)
        {
            var productType = await _productRepository.GetProductTypeByIdAsync(productTypeId);
            if (productType == null)
                return BadRequest(StatusCodes.Status404NotFound);

            return Ok(productType);
        }

        [HttpGet]
        [Route("product_brand")]
        public async Task<ActionResult<ProductBrand>> GetProductBrandById(int productBrandId)
        {
            var productBrand = await _productRepository.GetProductBrandByIdAsync(productBrandId);
            if (productBrand == null)
                return BadRequest(StatusCodes.Status404NotFound);

            return Ok(productBrand);
        }
    }
}