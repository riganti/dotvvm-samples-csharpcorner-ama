using System.Collections.Generic;
using System.Linq;
using DotvvmAMADemos.Products.Model;
using DotvvmAMADemos.Products.Database;

namespace DotvvmAMADemos.Products.Services
{
    public class ProductService
    {
        private readonly AppDbContext dbContext;

        public ProductService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<ProductListDTO> GetProducts()
        {
            return dbContext.Products
                .Select(p => new ProductListDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    UnitPrice = p.UnitPrice
                })
                .ToList();
        }

    }
}