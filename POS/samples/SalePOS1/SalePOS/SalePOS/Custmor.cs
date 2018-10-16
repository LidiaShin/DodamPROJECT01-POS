using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalePOS
{
    class Custmor
    {
        public int CustID { get; private set; }
        public string CompName { get; private set; }
        public string ContactName { get; private set; }
        public string ConatctTitle { get; private set; }
        public string Address { get; private set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }
        public string Phone { get; private set; }
        public string Fax { get; private set; }
        public Custmor(string id,string compName,string contactName,string title,string address,string city,string province,string country,string postalCode,string phone,string fax)
        {
            CustID = Convert.ToInt32(id);
            CompName = compName;
            ContactName = contactName;
            ConatctTitle = title;
            Address = address;
            Province = province;
            City = city;
            Country = country;
            PostalCode = postalCode;
            Phone = phone;
            Fax = fax;
        }
    }
}
