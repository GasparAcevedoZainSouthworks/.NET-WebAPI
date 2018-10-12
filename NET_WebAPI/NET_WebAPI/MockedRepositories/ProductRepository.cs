using NET_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_WebAPI.Repositories
{
    public class ProductRepository
    {
        private static ProductRepository repository = null;
        private List<Product> products;

        private ProductRepository()
        {
            SetProducts();
        }

        private void SetProducts()
        {
            products = new List<Product>();

            for (int i = 1; i <= 20; i++)
            {
                products.Add(new Product
                {
                    Id = i,
                    Name = "Product_" + i,
                    Category = "Category_" + (i % 10),
                    Price = i * 10 + ((decimal)i / 10)
                });
            }
        }

        public static ProductRepository GetRepository()
        {
            if (repository == null)
                repository = new ProductRepository();
            return repository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}