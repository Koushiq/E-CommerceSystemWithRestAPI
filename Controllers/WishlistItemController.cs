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
    [RoutePrefix("api/customers/{id}/wishlist")]
    public class WishlistItemController : ApiController
    {
        WishlistItemRepository wishListItemRepository = new WishlistItemRepository();
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(wishListItemRepository.GetAll());
        }

        [Route("{wid}", Name = "GetWishlistById")]
        public IHttpActionResult Get(int wid)
        {
            var wishlistItem = wishListItemRepository.Get(wid);
            if (wishlistItem == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(wishListItemRepository.Get(wid));
        }

        [Route("")]
        public IHttpActionResult Post(WishlistItem wishlistItem)
        {
            wishListItemRepository.Insert(wishlistItem);
            string uri = Url.Link("GetWishlistById", new { wid = wishlistItem.WishlistItemId });
            return Created(uri, wishlistItem);
        }

        [Route("{wid}")]
        public IHttpActionResult Put([FromUri] int wid, [FromBody] WishlistItem wishlistItem)
        {
            wishlistItem.WishlistItemId = wid;
            wishListItemRepository.Update(wishlistItem);
            return Ok(wishlistItem);
        }

        [Route("{wid}")]
        public IHttpActionResult Delete(int wid)
        {
            wishListItemRepository.Delete(wid);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
