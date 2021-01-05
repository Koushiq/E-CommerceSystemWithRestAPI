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
    [RoutePrefix("api/walletentry")]
    public class WalletEntryController : ApiController
    {
        WalletEntryRepository _walletEntryRepository = new WalletEntryRepository();
        CustomerRepository _customerRepository = new CustomerRepository();

        // GET: api/WalletEntry
        public IHttpActionResult Get()
        {
            return Ok(_walletEntryRepository.GetAll());
        }

        // GET: api/WalletEntry/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_walletEntryRepository.Get(id));
        }

        // POST: api/WalletEntry
        public IHttpActionResult Post([FromBody] WalletEntry walletEntry)
        {
            if (ModelState.IsValid)
            {
                walletEntry.RequestedAt = DateTime.UtcNow;
                walletEntry.Status = "Pending";
                _walletEntryRepository.Insert(walletEntry);
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [Route("approve/{id}")]
        [HttpGet]
        public IHttpActionResult Approve(int id)
        {
            var walletEntry = _walletEntryRepository.Get(id);
            if(walletEntry is null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            var customer = _customerRepository.Get(walletEntry.CustomerId);
            if (customer is null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            customer.Balance += walletEntry.Amount;

            walletEntry.ActionAt = DateTime.UtcNow;
            walletEntry.Status = "Approved";
            _walletEntryRepository.Update(walletEntry);

            _customerRepository.Update(customer);

            return StatusCode(HttpStatusCode.OK);
        }

        [Route("reject/{id}")]
        [HttpGet]
        public IHttpActionResult Reject(int id)
        {
            var walletEntry = _walletEntryRepository.Get(id);
            if (walletEntry is null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            walletEntry.ActionAt = DateTime.UtcNow;
            walletEntry.Status = "Rejected";
            _walletEntryRepository.Update(walletEntry);

            return StatusCode(HttpStatusCode.OK);
        }
    }
}
