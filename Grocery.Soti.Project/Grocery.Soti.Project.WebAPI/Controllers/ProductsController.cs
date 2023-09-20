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
    public class ProductsController : ApiController
    {
        private readonly IProduct _product = null;

        public ProductsController(IProduct product)
        {
            _product = product;
        }

        [HttpPut]
        [Route("Products/UpdateProduct")]
        public IHttpActionResult EditProduct([FromBody] Product product)
        {
            var dt = _product.EditProduct(product.ProductId,product.ProductName,product.Description,product.UnitPrice,product.UnitsInStock,product.Discontinued,product.CategoryId);
            if (!dt)
            {
                return BadRequest();
            }
            return Ok(dt);
        }
    }
}
