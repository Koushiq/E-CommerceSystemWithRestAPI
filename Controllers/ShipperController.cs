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
    [RoutePrefix("api/shippers")]
    public class ShipperController : ApiController
    {
        ShipperRepository shipperRepository = new ShipperRepository();
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(shipperRepository.GetAll());
        }

        [Route("{id}", Name = "GetShipperById")]
        public IHttpActionResult Get(int id)
        {
            var shipper = shipperRepository.Get(id);
            if (shipper == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(shipperRepository.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Shipper shipper)
        {
            shipperRepository.Insert(shipper);
            string uri = Url.Link("GetShipperById", new { id = shipper.ShipperId });
            return Created(uri, shipper);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Shipper shipper)
        {
            shipper.ShipperId = id;
            shipperRepository.Update(shipper);
            return Ok(shipper);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            shipperRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
