using E_CommerceSystemWithRestAPI.Attributes;
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
        CustomerRepository customerRepository = new CustomerRepository();
        ProductRepository productRepository = new ProductRepository();
        OrderRepository orderRepository = new OrderRepository();
        
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(orderItemRepository.GetAll());
        }

        

        [Route("{username}")]
        public IHttpActionResult GetItemsInCart(string username)
        {
            Customer customer = customerRepository.GetAll().Where(s => s.Username == username).FirstOrDefault();
            List<OrderedItem> orderItem = orderItemRepository.GetAll().Where(s => s.CustomerId == customer.CustomerId && s.OderItemStatus == "incart").ToList();
            foreach(var item in orderItem)
            {
                item.Customer = customer;
                item.Product = productRepository.Get(item.ProductId);
            }
            return Ok(orderItem);
        }

        [Route("{username}/{productId}")]
        public IHttpActionResult GetCheckDublicate(string username,int productId)
        {
            Customer customer = customerRepository.GetAll().Where(s => s.Username == username).FirstOrDefault();
            OrderedItem orderedItem = orderItemRepository.GetAll().Where(s => s.ProductId == productId && s.CustomerId == customer.CustomerId && s.OderItemStatus=="incart").FirstOrDefault();
            if (orderedItem == null)
            {
                return Ok(customer.CustomerId);
            }
            else
            {
                return StatusCode(HttpStatusCode.Conflict);
            }



        }

       /* [Route("{pid}")]
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
        }*/

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
        [Route("updatecart/{username}")]
        public IHttpActionResult PutUpdateCart([FromUri] string username)
        {
            Customer customer = customerRepository.GetAll().Where(s => s.Username == username).FirstOrDefault();
            List<OrderedItem> orderedItems = orderItemRepository.GetAll().Where(s => s.CustomerId == customer.CustomerId && s.OrderId==null).ToList();
            Order order = orderRepository.GetAll().Where(s=>s.CustomerId==customer.CustomerId).LastOrDefault();
            foreach (var item in orderedItems)
            {
                item.CustomerId = customer.CustomerId;
                item.OderItemStatus = "purchased";
                item.OrderId = order.OrderId;
                orderItemRepository.Update(item);
            }
            return Ok();
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
