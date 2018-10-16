using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsRegisterEmail
    {
        public string emailSubject { get; set; }
        public string emailContent { get; set; }
        public string emailAddress { get; set; }

        public CsRegisterEmail(string esubject,string econtent,string eaddress)
        {
            emailSubject = esubject;
            emailContent = econtent;
            emailAddress = eaddress;
        }
    }
}