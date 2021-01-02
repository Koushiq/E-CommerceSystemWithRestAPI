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
    [RoutePrefix("api/categories/{id}/products")]
    public class ProductController : ApiController
    {
        ProductRepository productRepository = new ProductRepository();

        [Route("~/api/products")]
        public IHttpActionResult GetAll()
        {
            return Ok(productRepository.GetAll());
        }


        [Route("")]
        public IHttpActionResult GetAll(int id)
        {
            return Ok(productRepository.GetAll().Where(s=>s.CategoryId==id));
        }

        [Route("{pid}")]
        public IHttpActionResult Get(int pid)
        {
            Product product = productRepository.Get(pid);
            if (product == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(product);
            }
        }

        [Route("")]
        public IHttpActionResult Post(Product product)
        {
            if (ModelState.IsValid )
            {
                productRepository.Insert(product);
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }
        [Route("{pid}")]
        public IHttpActionResult Put([FromUri]int pid, [FromBody]Product prodcut)
        {
            prodcut.ProductId = pid;
            if(ModelState.IsValid)
            {
                productRepository.Update(prodcut);
                return Ok(prodcut);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("{pid}")]
        public IHttpActionResult Delete(int pid)
        {
            productRepository.Delete(pid);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
