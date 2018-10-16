using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsProvincelist
    {


        public DataTable Provinces { get; set; }

        public CsProvincelist(DataTable pv)
        {
            Provinces = pv;
        }
    }
}