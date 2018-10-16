using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsCustomerlist
    {
        public DataTable customerList { get; set; }

        public CsCustomerlist(DataTable customers)
        {
            customerList=customers;
        }
    }
}