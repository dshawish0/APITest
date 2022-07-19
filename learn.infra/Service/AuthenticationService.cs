using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace learn.infra.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthentication authentication;
        public AuthenticationService(IAuthentication authentication)
        {
            this.authentication = authentication;
        }

        public string Authentication_jwt(api_loginAuth api_LoginAuth)
        {

            var result = authentication.Auth(api_LoginAuth);

            if (result == null)
            {
                return null;
            }

            var tokenHandeler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Tolen,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                     new Claim[]
                     {
                         new Claim(ClaimTypes.Email, result.userName),
                         new Claim(ClaimTypes.Role, result.roleNmae),
                         new Claim(ClaimTypes.Name, 1.ToString())
                     }
                    ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var generateToken = tokenHandeler.CreateToken(tokenDescirptor);


            return tokenHandeler.WriteToken(generateToken);
        }
    }
}
