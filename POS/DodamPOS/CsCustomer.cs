using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsCustomer
    {
        public string cNumber { get; set; }
        public string cFirstName { get; set; }
        public string cLastName { get; set; }

        public string cAddress { get; set; }
        public string cCity { get; set; }
        public string cProvince { get; set; }
        public string cPostalCode { get; set; }
        public string cPhone { get; set; }
        public string cEmail { get; set; }
        public string cRegisterDate { get; set; }
        public string cLevel { get; set; }

        public string cNote { get; set; }

        public CsCustomer(string cnum,string fname,string lname,string address,string city,string prov,string pcode,
            string phone,string email,string note,string rdate,string level)
        {
            cNumber = cnum;
            cFirstName = fname;
            cLastName = lname;
            cAddress = address;
            cCity = city;
            cProvince = prov;
            cPostalCode = pcode;
            cPhone = phone;
            cEmail = email;
            cNote = note;
            cRegisterDate = rdate;
            cLevel = level;
        }
    }


}