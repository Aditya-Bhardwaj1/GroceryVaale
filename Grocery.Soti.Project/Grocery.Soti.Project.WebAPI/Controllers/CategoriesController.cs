using System;
using System.Collections.Generic;
using System.Linq;
using Grocery.Soti.Project.DAL;
using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Grocery.Soti.Project.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategory _categories = null;

        public CategoriesController(ICategory category)
        {
            _categories = category;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IHttpActionResult GetAllCategories()
        {
            var dt = _categories.GetAllCategories();
            if (dt == null)
            {
                return BadRequest();
            }
            return Ok(dt);
        }

        [HttpPost]
        [Route("AddCategory")]
        public IHttpActionResult InsertCategory([FromBody] Category category)
        {
            var dt = _categories.InsertCategory(category.CategoryName, category.CategoryImage);
            if (!dt)
            {
                return BadRequest();
            }
            return Ok(dt);
        }
    }
}
