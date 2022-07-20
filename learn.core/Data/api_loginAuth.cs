using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Data
{
    public class api_loginAuth
    {
        public int LoginId { get; set; }
        public string userName { get; set; }
        public string Ppassword { get; set; }
        public string roleNmae { get; set; }
        public string verificationCode { get; set; }
    }
}
