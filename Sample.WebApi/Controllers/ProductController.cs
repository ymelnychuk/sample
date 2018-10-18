using Sample.Data.Entity;
using Sample.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Sample.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> Get(int skip, int take, String orderBy)
        {
            return _productRepository.GetAll().Skip(skip).Take(take).OrderBy(p => p.ProductName);
        }
    }
}
