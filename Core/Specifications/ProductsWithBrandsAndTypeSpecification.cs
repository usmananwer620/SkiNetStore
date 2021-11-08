using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithBrandsAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndTypeSpecification(string sort, int? brandId, int? typeId)
            : base(x =>
             (!brandId.HasValue || x.ProductBrandId == brandId) &&
             (!typeId.HasValue || x.ProductTypeId == typeId))
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
            AddOrderBy(p => p.Name);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceASC":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDESC":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductsWithBrandsAndTypeSpecification(int id)
            : base(p => p.Id == id)
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
        }
    }
}
