using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Grocery.Soti.Project.WebAPI.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private readonly IProduct _product = null;

        public ProductsController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        [Route("AllProducts")]
        public IHttpActionResult GetProducts()
        {
            var dt = _product.GetAllProducts();
            if (dt == null)
            {
                return BadRequest();
            }
            return Ok(dt);
        }

        [HttpPut]
        [Route("updateProduct/{productId}")]
        public IHttpActionResult UpdateProduct([FromUri] int productId, [FromBody] Product product)
        {
            var dt = _product.EditProduct(productId, product.ProductName, product.Description, product.UnitPrice,product.UnitsInStock,product.Discontinued,product.CategoryId);
            if (!dt)
            {
                return BadRequest();
            }
            return Ok(dt);
        }
    }
}
