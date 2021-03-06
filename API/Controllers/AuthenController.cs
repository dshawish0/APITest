using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenticationService authenticationservice;
        public AuthenController(IAuthenticationService authenticationservice)
        {
            this.authenticationservice = authenticationservice;
        }

        [HttpPost]
        public IActionResult authen([FromBody] api_loginAuth login)
        {
            var RESULT = authenticationservice.Authentication_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized(); //401
            }
            else
            {
                return Ok(RESULT); //200
            }
        }

        [HttpGet]
        [Route("verificationCode/{code}")]
        public IActionResult verificationCode(string code)
        {
            if(Global.api_LoginAuth != null)
            {
                if (Global.api_LoginAuth.verificationCode != null)
                {
                    if (Global.api_LoginAuth.verificationCode.ToString().Equals(code))
                        return Ok("verificationCode Successful");
                }
                return Ok("verificationCode Invalid");
            }
            return Ok("no login request");
        }
    }
}
