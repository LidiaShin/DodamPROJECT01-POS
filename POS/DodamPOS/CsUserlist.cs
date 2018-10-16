using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsUserlist
    {
        public string username { get; set; }
        public string password { get; set; }

        public CsUserlist(string uname,string pword)
        {
            username = uname;
            password = pword;
        }
    }
}