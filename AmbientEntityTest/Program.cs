using Domain;
using Infrastructure;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbientEntityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterTypes.Ioc.Configure();

            Console.WriteLine("Configuration done...");

            Console.WriteLine("You have below options:");

            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Get Product By Id");
            Console.WriteLine("3. Get All Products");

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "q")
                    break;

                var repo = RegisterTypes.Ioc.GetType<ProductRepository>();
                if (input == "1")
                {
                    var randomProduct = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 8);
                    var product = new Product { ProductId = randomProduct, ProductName = "Sample Product: " + randomProduct, Description = "Sample description: " + randomProduct, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
                    repo.Add(product as IProduct).Wait();
                    Console.WriteLine("Product added: " + randomProduct);
                }
                else if(input == "3")
                {
                    var products = repo.GetAll().Result;
                    foreach(var product in products)
                    {
                        Console.WriteLine("{0} \t {1} \t", product.ProductName, product.Description);
                    }
                }
            }

        }
    }
}
