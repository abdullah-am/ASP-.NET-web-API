using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SI_system.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var token = AuthService.Authenticate(login.Username, login.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpPost]
        [Route("signup")]
        public HttpResponseMessage SignUp(SignUpDTO signup)
        {
            try
            {
                bool result = AuthService.SignUp(signup);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Sign-up successful.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Username or Email already exists.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpGet]
        [Route("logout")]
        public HttpResponseMessage Logout()
        {
            var key = Request.Headers.Authorization;
            if (key == null) return Request.CreateResponse(HttpStatusCode.InternalServerError, "You might forgot to supply token to logout");
            try
            {

                var token = AuthService.LogoutToken(key.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, token);


            }
            catch (Exception ex)
            {
                // return Request.CreateResponse(HttpStatusCode.InternalServerError, "You might forgot to supply token to logout");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }



        }


    }
}
