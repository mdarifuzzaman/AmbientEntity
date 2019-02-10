using Domain;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class NonAmbientProductRepository: IRepository
    {
        private readonly ProductDbContext _context;
        public NonAmbientProductRepository()
        {
            _context = new ProductDbContext();
        }

        public async Task Add(IProduct product)
        {
            var productEntity = new Product
            {
                ProductId = product.ProductId,
                DateCreated = product.DateCreated,
                DateModified = product.DateModified,
                Description = product.Description,
                ProductName = product.ProductName
            };
            _context.Products.Add(productEntity);

            await _context.SaveChangesAsync();
        }

        public Task<IProduct> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IProduct>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
