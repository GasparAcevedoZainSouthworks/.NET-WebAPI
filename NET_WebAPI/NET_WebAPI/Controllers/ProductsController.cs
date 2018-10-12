using NET_WebAPI.Models;
using NET_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NET_WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductRepository repository;
        private IEnumerable<Product> products;

        private ProductsController()
        {
            repository = ProductRepository.GetRepository();
            products = repository.GetProducts();
        }

        [ActionName("GetAll")]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int Id)
        {
            var product = products.FirstOrDefault(p => p.Id == Id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}
