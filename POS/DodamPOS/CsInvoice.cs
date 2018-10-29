using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsInvoice
    {
        public DataTable InvoiceList { get; set; }

        public CsInvoice(DataTable invoice)
        {
            InvoiceList = invoice;
        }
    }
}