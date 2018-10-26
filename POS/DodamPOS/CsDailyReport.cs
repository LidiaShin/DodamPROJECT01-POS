using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsDailyReport
    {
        public string Number { get; set; }
        public DataTable aTable { get; set; } // TODAY REPORT (BY CATEGORY)
        public DataTable bTable { get; set; } // TODAY REPORT (SUMUP TOTAL)
        public DataTable cTable { get; set; } // PREVIOUS 7 DAYS (SUMUP TOTAL)
        public DataTable dTable { get; set; } // ITEM CHART TODAY

        public DataTable eTable { get; set; } // ITEM CHART PREVIOUS 7 DAYS


        public CsDailyReport (string num, DataTable at, DataTable bt, DataTable ct, DataTable dt, DataTable et)
        {
            Number = num;
            aTable = at;
            bTable = bt;
            cTable = ct;
            dTable = dt;
            eTable = et;
        }




    }
}