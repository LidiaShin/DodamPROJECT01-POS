using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsSearchInvoice
    {
        public string KeyWord1 { get; set; }
        public string Keyword2 { get; set; }
        public DataTable Invoicelist { get; set; }

        public CsSearchInvoice(string kword1,string kword2, DataTable ilist)
        {
            KeyWord1 = kword1;
            Keyword2 = kword2;
            Invoicelist = ilist;
        }
    }
}