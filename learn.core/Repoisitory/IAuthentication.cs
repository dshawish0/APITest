using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface IAuthentication
    {
        public api_loginAuth Auth(api_loginAuth api_LoginAuth);
        public void UpdateVerificationCode(api_loginAuth api_LoginAuth);

    }
}
