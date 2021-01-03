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
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        OrderRepository orderRepository = new OrderRepository();

        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(orderRepository.GetAll());
        }

        [Route("{id}", Name = "GetOrderById")]
        public IHttpActionResult Get(int id)
        {
            var category = orderRepository.Get(id);
            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(orderRepository.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Order order)
        {
            orderRepository.Insert(order);
            string uri = Url.Link("GetOrderById", new { id = order.OrderId });
            return Created(uri, order);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Order order)
        {
            order.OrderId = id;
            orderRepository.Update(order);
            return Ok(order);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            orderRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
