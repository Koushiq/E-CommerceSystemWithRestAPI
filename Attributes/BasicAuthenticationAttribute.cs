using E_CommerceSystemWithRestAPI.Models;
using E_CommerceSystemWithRestAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace E_CommerceSystemWithRestAPI.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private CustomerRepository customerRepository = new CustomerRepository();
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if(actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodedString = actionContext.Request.Headers.Authorization.Parameter;
                string decodeString = Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
                string[] splittedText = decodeString.Split(new char[] { ':' });
                Customer customer = customerRepository.GetAll().Where(s => s.Username == splittedText[0] && s.Password == splittedText[1]).FirstOrDefault();
                if(customer==null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(customer.Username),null);
                }
            }
        }
    }
}