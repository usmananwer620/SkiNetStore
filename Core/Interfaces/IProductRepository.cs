using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int productId);
        Task<ProductBrand> GetProductBrandByIdAsync(int productBrandId);
        Task<ProductType> GetProductTypeByIdAsync(int productTypeId);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<Product> GetProductAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}
