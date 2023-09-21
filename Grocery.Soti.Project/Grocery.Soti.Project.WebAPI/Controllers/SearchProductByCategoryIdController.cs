using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SOTI.DAL.DEMO.SEARCH.Interface;
using SOTI.SEARCH_PRODUCT;

namespace SOTI.SEARCH_PRODUCT.Controllers
{
    [RoutePrefix("api/soti/products")]
    public class SearchProductByCategoryIdController : ApiController
    {
        private readonly ISearchProductByCategoryId _Product = null;

        public SearchProductByCategoryIdController(ISearchProductByCategoryId SearchProduct)
        {
            _Product = SearchProduct;
        }

        [HttpGet]

        [Route("{CategoryId}")]

        public IHttpActionResult SearchProductByCategoryId([FromUri] int CategoryId)
        {
            var searchProduct = _Product.SearchProductByCategoryId(CategoryId);

            if (searchProduct == null)
            {
                return NotFound();
            }
            return Ok(searchProduct);
        }


    }
}
