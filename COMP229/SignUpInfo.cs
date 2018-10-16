using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP229
{
    public class SignUpInfo
    {
        public string userName { get; set; }
        public string eMailAddress { get; set; }
        public string passWord { get; set; }
        public SignUpInfo(string uname, string email, string pword)
        {
            userName = uname;
            eMailAddress = email;
            passWord = pword;

        }
    }
}