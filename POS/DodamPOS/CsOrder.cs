using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsOrder
    {
        public string OrderNumber { get; set; }
        public string CustomerNumber { get; set; }
        public string OrderDate { get; set; }

        public CsOrder(string onum, string cnum, string odate)
        {
            OrderNumber = onum;
            CustomerNumber = cnum;
            OrderDate = odate;
        }


    }
}