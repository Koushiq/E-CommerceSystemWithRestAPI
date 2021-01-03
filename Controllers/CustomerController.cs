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
    [RoutePrefix("api/customers")]
    public class CustomerController : ApiController
    {
        CustomerRepository customerRepository = new CustomerRepository();

        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(customerRepository.GetAll());
        }
        [Route("login")]
        public IHttpActionResult PostLogin(Customer customer)
        {
            Customer c = customerRepository.GetAll().Where(s => s.Username == customer.Username && s.Password == customer.Password).FirstOrDefault();
            if(c!=null)
            {
                return Ok(customer);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }


        [Route("{id}")]
        public IHttpActionResult GetAll(int id)
        {
            return Ok(customerRepository.GetAll().Where(s => s.CustomerId == id));
        }

        [Route("{pid}")]
        public IHttpActionResult Get(int pid)
        {
            Customer admin = customerRepository.Get(pid);
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
        public IHttpActionResult Post(Customer  customer)
        {
            if (ModelState.IsValid)
            {
                customerRepository.Insert(customer);
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }
        [Route("{pid}")]
        public IHttpActionResult Put([FromUri] int pid, [FromBody] Customer customer)
        {
            customer.CustomerId = pid;
            if (ModelState.IsValid)
            {
                customerRepository.Update(customer);
                return Ok(customer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("{pid}")]
        public IHttpActionResult Delete(int pid)
        {
            customerRepository.Delete(pid);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
