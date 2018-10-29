using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsReceiptInfo
    {
        public string OrderNum { get; set; }
        public DataTable CustomerInfo { get; set; }

        public CsReceiptInfo(string ONum, DataTable CInfo)
        {
            OrderNum = ONum;
            CustomerInfo = CInfo;
        }
    }
}