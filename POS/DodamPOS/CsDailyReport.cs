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
        public DataTable bTable { get; set; } // ITEM CHART TODAY
        public DataTable cTable { get; set; } // 
        public DataTable dTable { get; set; } // PAST 7 DAYS REPORT (BY CATEGORY)

        public DataTable eTable { get; set; } // PAST 7 DAYS REPORT (EACH DAY)


        public DataTable fTable { get; set; } // PAST 7 DAYS REPORT (BY CATEGORY)

        public DataTable gTable { get; set; } // PAST 7 DAYS REPORT (EACH DAY)



        public CsDailyReport 
        (string num, DataTable at, DataTable bt, DataTable ct, DataTable dt, DataTable et,DataTable ft,DataTable gt)
        {
            Number = num;
            aTable = at;
            bTable = bt;
            cTable = ct;
            dTable = dt;
            eTable = et;

            fTable = ft;
            gTable = gt;
        }




    }
}