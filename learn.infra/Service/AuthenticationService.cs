using API;
using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using MailKit.Net.Smtp;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            API.Global.api_LoginAuth = result;

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

            Random r = new Random();
            int rInt = r.Next(1000, 100000);
            result.verificationCode = rInt.ToString();
            authentication.UpdateVerificationCode(result);
            UpdateVerificationCode(result);


            Thread thread = new Thread(thr);
            thread.Start();

            //Thread.Sleep(20000);
            //Task.Delay(20000);

            //authentication.UpdateVerificationCode(Global.api_LoginAuth);

            return tokenHandeler.WriteToken(generateToken);
        }

        public void UpdateVerificationCode(api_loginAuth api_LoginAuth)
        {
            MimeMessage obj = new MimeMessage();
            MailboxAddress emailfrom = new MailboxAddress("user", "teeeeeestemail@gmail.com");
            MailboxAddress emailto = new MailboxAddress("user", api_LoginAuth.userName);

            obj.From.Add(emailfrom);
            obj.To.Add(emailto);
            obj.Subject = "verificationCode";
            BodyBuilder bb = new BodyBuilder();
            //onclick="window.location.href='https://w3docs.com';">
            //bb.HtmlBody = "<html>" + "<button window.location.href="+"'"+"https://localhost:44353/api/Authen/verificationCode/" + api_LoginAuth.verificationCode+"';"+">"+ 
            //    "verificationCode" + "</button>" + "</html>";
            bb.HtmlBody = "<html>" + "<h1>" + api_LoginAuth.verificationCode + "</h1>" + "</html>";
            obj.Body = bb.ToMessageBody();

            SmtpClient emailClinet = new SmtpClient();
            emailClinet.Connect("smtp.gmail.com", 465, true);
            emailClinet.Authenticate("teeeeeestemail@gmail.com", "zvvugvfrinavklfj");
            emailClinet.Send(obj);

            emailClinet.Disconnect(true);
            emailClinet.Dispose();
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        void thr()
        {
            Thread.Sleep(20000);
            Task.Delay(20000);
            Global.api_LoginAuth.verificationCode = null;

            authentication.UpdateVerificationCode(Global.api_LoginAuth);
        }
    }
}
