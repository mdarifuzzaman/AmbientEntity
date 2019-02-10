using Domain;
using Infrastructure.Data;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProductRepository: IRepository
    {
        private readonly IEntitySet<Product> _products;
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        public ProductRepository(IEntitySet<Product> products, IDbContextScopeFactory dbContextScopeFactory)
        {
            this._products = products;
            this._dbContextScopeFactory = dbContextScopeFactory;
        }

        public async Task Add(IProduct product)
        {
            using (var scope = this._dbContextScopeFactory.CreateWithTransaction(System.Data.IsolationLevel.Unspecified))
            {
                var productEntity = new Product
                {
                    ProductId = product.ProductId,
                    DateCreated = product.DateCreated,
                    DateModified = product.DateModified,
                    Description = product.Description,
                    ProductName = product.ProductName
                };

                _products.Add(productEntity);
                await scope.SaveChangesAsync();
            }
        }

        public async Task<IProduct> Get(string id)
        {
            using(var scope = this._dbContextScopeFactory.CreateReadOnly())
            {
                var product = this._products.SingleOrDefault(e => e.ProductId == id);
                return await Task.FromResult(product);
            }
        }

        public async Task<IEnumerable<IProduct>> GetAll()
        {
            using (var scope = this._dbContextScopeFactory.CreateReadOnly())
            {
                var products = this._products.ToList();
                return await Task.FromResult(products);
            }
        }
    }
}
