using ECommerceEntities;
using EcommerceServices;
using Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthWebAPI.Controllers
{
    public class AuthController : ApiController
    {
        public IHttpActionResult Post([FromBody] credential crednetial)
        {
            IAuthService svc = new AuthService();
            if (svc.Login(crednetial.Email, crednetial.Password))
            {
                return Ok("login successful");
            }
            else
            {
                return Unauthorized();

            }

        }
    }
}
