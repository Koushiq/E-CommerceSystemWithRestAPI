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
    [RoutePrefix("api/orderitems")]
    public class OrderedItemController : ApiController
    {
        OrderedItemRepository orderItemRepository = new OrderedItemRepository();

        public IHttpActionResult GetAll()
        {
            return Ok(orderItemRepository.GetAll());
        }


        [Route("")]
        public IHttpActionResult GetAll(int id)
        {
            return Ok(orderItemRepository.GetAll().Where(s => s.OrderedItemId == id));
        }

        [Route("{pid}")]
        public IHttpActionResult Get(int pid)
        {
            OrderedItem admin = orderItemRepository.Get(pid);
            if (admin == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(admin);
            }
        }

        [Route("")]
        public IHttpActionResult Post(OrderedItem orderedItem)
        {
            if (ModelState.IsValid)
            {
                orderItemRepository.Insert(orderedItem);
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }
        [Route("{pid}")]
        public IHttpActionResult Put([FromUri] int pid, [FromBody] OrderedItem orderedItem)
        {
            orderedItem.OrderedItemId = pid;
            if (ModelState.IsValid)
            {
                orderItemRepository.Update(orderedItem);
                return Ok(orderedItem);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("{pid}")]
        public IHttpActionResult Delete(int pid)
        {
            orderItemRepository.Delete(pid);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
