using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Grocery.Soti.Project.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/soti/products")]
    public class ProductsController : ApiController
    {
        private readonly IProduct _product = null;
        public ProductsController(IProduct product)
        {
            _product = product;
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

        [HttpGet]

        [Route("getProductByCategoryId/{CategoryId}")]
        public IHttpActionResult ListProducts([FromUri] int CategoryId)
        {
            var searchProduct = _product.ListProducts(CategoryId);

            if (searchProduct == null)
            {
                return NotFound();
            }
            return Ok(searchProduct);
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
            var dt = _product.EditProduct(productId, product.ProductName, product.Description, product.UnitPrice, product.UnitsInStock, product.Discontinued, product.CategoryId, product.ProductImage);
            if (!dt)
            {
                return BadRequest();
            }
            return Ok(dt);
        }

        // add new product

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
