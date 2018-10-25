using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsReceipt
    {
        public string OrderNum { get; set; }
        public DataTable ReceiptTable { get; set; }

        public DataTable TotalTable { get; set; }
      

        public CsReceipt (string onum,DataTable rtable,DataTable ttable)
        {
            OrderNum = onum;
            ReceiptTable = rtable;
            TotalTable = ttable;
        }
    }
}