using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!storeContext.ProductBrands.Any())
                {
                    var productBrandsList = new List<ProductBrand>() {
                        new ProductBrand() { Name = "Product Brand One" },
                        new ProductBrand() { Name = "Product Brand Two" } ,
                        new ProductBrand() { Name = "Product Brand Three" },
                        new ProductBrand() { Name = "Product Brand Four" } ,
                        new ProductBrand() { Name = "Product Brand Five" }
                    };
                    //var brandsData = 
                    //    File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    //var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    storeContext.ProductBrands.AddRange(productBrandsList);
                    await storeContext.SaveChangesAsync();
                }
                if (!storeContext.ProductTypes.Any())
                {
                    var productTypesList = new List<ProductType>() {
                        new ProductType() { Name = "Product Type One" },
                        new ProductType() { Name = "Product Type Two" } ,
                        new ProductType() { Name = "Product Type Three" },
                        new ProductType() { Name = "Product Type Four" } ,
                        new ProductType() { Name = "Product Type Five" }
                    };
                    //var brandsData = 
                    //    File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    //var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    storeContext.ProductTypes.AddRange(productTypesList);
                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.Products.Any())
                {
                    var productsList = new List<Product>() {
                        new Product() { Name = "Product One", Description="Product One Description"     , PictureUrl="", Price=100.62M, ProductBrandId= 1, ProductTypeId= 2 },
                        new Product() { Name = "Product Two"   , Description="Product Two Description"  , PictureUrl="", Price=101.63M, ProductBrandId= 2, ProductTypeId= 3 } ,
                        new Product() { Name = "Product Three" , Description="Product Three Description", PictureUrl="", Price=102.64M, ProductBrandId= 2, ProductTypeId= 1 },
                        new Product() { Name = "Product Four"  , Description="Product Four Description" , PictureUrl="", Price=103.65M, ProductBrandId= 3, ProductTypeId= 1 } ,
                        new Product() { Name = "Product Five"  , Description="Product Five Description" , PictureUrl="", Price=104.66M, ProductBrandId= 1, ProductTypeId= 4 }
                    };
                    //var brandsData = 
                    //    File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    //var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    storeContext.Products.AddRange(productsList);
                    await storeContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
