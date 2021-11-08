using API.DTOs;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<List<ProductToReturnDTO>>> GetProducts(string sort, int? brandId, int? typeId)
        {
            ProductsWithBrandsAndTypeSpecification specs = new ProductsWithBrandsAndTypeSpecification(sort, brandId, typeId);
            var products = await _productRepo.ListAsync(specs);
            var productsDTOs = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);
            return Ok(productsDTOs);
        }

        [HttpGet]
        [Route("product/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int productId)
        {
            var specs = new ProductsWithBrandsAndTypeSpecification(productId);
            var product = await _productRepo.GetEntityWithSpec(specs);
            if (product == null)
                return NotFound(new ApiResponse(404));

            var productDTO = _mapper.Map<Product, ProductToReturnDTO>(product);
            return Ok(productDTO);
        }

        [HttpGet]
        [Route("product_brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _productBrandRepo.GetAllAsync();
            if (productBrands == null)
                return BadRequest(StatusCodes.Status404NotFound);
            return Ok(productBrands);
        }

        [HttpGet]
        [Route("product_types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var productTypes = await _productTypeRepo.GetAllAsync();
            if (productTypes == null)
                return BadRequest(StatusCodes.Status404NotFound);

            return Ok(productTypes);
        }

        [HttpGet]
        [Route("product_type")]
        public async Task<ActionResult<ProductType>> GetProductTypeById(int productTypeId)
        {
            var productType = await _productTypeRepo.GetByIdAsync(productTypeId);
            if (productType == null)
                return BadRequest(StatusCodes.Status404NotFound);

            return Ok(productType);
        }

        [HttpGet]
        [Route("product_brand")]
        public async Task<ActionResult<ProductBrand>> GetProductBrandById(int productBrandId)
        {
            var productBrand = await _productBrandRepo.GetByIdAsync(productBrandId);
            if (productBrand == null)
                return BadRequest(StatusCodes.Status404NotFound);

            return Ok(productBrand);
        }
    }
}