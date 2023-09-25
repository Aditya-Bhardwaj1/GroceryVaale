using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Grocery.Soti.Project.WebAPI.Controllers
{
    [System.Web.Http.Cors.EnableCors("*","*","*")]
    [RoutePrefix("api/soti/products")]
    public class ProductsController : ApiController
    {
        private readonly IProduct _product = null;
        public ProductsController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult getAllProduct()
        {
            var product = _product.GetAllProducts();
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getProductById/{productId}")]
        public IHttpActionResult getProductById([FromUri] int productId)
        {
            var product = _product.GetProductById(productId);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getSearchedProducts")]
        public IHttpActionResult getSearchedProducts([FromUri] string productName, [FromUri] decimal? productPrice)
        {
            var product = _product.searchProduct(productName, productPrice);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("addProduct")]
        public IHttpActionResult addProduct([FromBody] Product p)
        {
            var product = _product.AddProduct(p);
            if (product)
            {
                return Ok(product);
            }
            return BadRequest();
        }
    }
}
