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
    [RoutePrefix("api/admins")]
    public class AdminController : ApiController
    {
        AdminRepository adminRepository = new AdminRepository();

        public IHttpActionResult GetAll()
        {
            return Ok(adminRepository.GetAll());
        }

        [Route("")]
        public IHttpActionResult GetAll(int id)
        {
            return Ok(adminRepository.GetAll().Where(s => s.AdminId == id));
        }

        [Route("{pid}")]
        public IHttpActionResult Get(int pid)
        {
            Admin admin = adminRepository.Get(pid);
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
        public IHttpActionResult Post(Admin admin)
        {
            if (ModelState.IsValid)
            {
                adminRepository.Insert(admin);
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }
        [Route("{pid}")]
        public IHttpActionResult Put([FromUri] int pid, [FromBody] Admin admin)
        {
            admin.AdminId = pid;
            if (ModelState.IsValid)
            {
                adminRepository.Update(admin);
                return Ok(admin);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("{pid}")]
        public IHttpActionResult Delete(int pid)
        {
            adminRepository.Delete(pid);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
