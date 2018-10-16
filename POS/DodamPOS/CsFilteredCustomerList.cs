using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsFilteredCustomerList
    {
        public DataTable fCustomerList { get; set; }

        public string kWordName { get; set; }
        public string kWordEmail { get; set; }

        public CsFilteredCustomerList(string kname, string kemail, DataTable fclist)
        {
            fCustomerList = fclist;
            kWordName = kname;
            kWordEmail = kemail;
        }
    }
}