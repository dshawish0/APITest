using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IAuthenticationService
    {
        public string Authentication_jwt(api_loginAuth api_LoginAuth);
        public void UpdateVerificationCode(api_loginAuth api_LoginAuth);
    }
}
