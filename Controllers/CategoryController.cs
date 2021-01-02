using E_CommerceSystemWithRestAPI.Models;
using E_CommerceSystemWithRestAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_CommerceSystemWithRestAPI.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        ProductRepository productRepository = new ProductRepository();
        [Route("")]

        public IHttpActionResult GetAll()
        {
            return Ok(categoryRepository.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Category category = categoryRepository.Get(id);
            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(category);
            }
        }

        [Route("")]
        public IHttpActionResult Post(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Insert(category);
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Category category)
        {
            category.CategoryId = id;
            if (ModelState.IsValid)
            {
                categoryRepository.Update(category);
                return Ok(category);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            categoryRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
