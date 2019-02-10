using System;
using Domain;
using Infrastructure.Data;
using Mehdime.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Infrastructure.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void ProductShouldAddSuccessfullyToRepo()
        {
            var products = Moq.Mock.Of<IEntitySet<Product>>();
            var mockFactory = new Mock<IDbContextScopeFactory>();
            var mockScope = new Mock<IDbContextScope>();
            bool saved = false;
            mockScope.Setup(e => e.SaveChangesAsync()).Callback(()=> {
                saved = true;
            });
            mockFactory.Setup(e => e.CreateWithTransaction(System.Data.IsolationLevel.Unspecified)).Returns(mockScope.Object);

            var repo = new ProductRepository(products, mockFactory.Object);

            var testProduct = new Product { ProductId = "test1234" };
            repo.Add(testProduct);
            Assert.IsTrue(saved);
        }
    }
}
