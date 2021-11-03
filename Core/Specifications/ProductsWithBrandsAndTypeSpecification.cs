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
        public ProductsWithBrandsAndTypeSpecification()
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
        }

        public ProductsWithBrandsAndTypeSpecification(int id) 
            : base(p=>p.Id==id)
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
        }
    }
}
