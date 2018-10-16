using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsItemlist
    {
        public DataTable itemList { get; set; }


      
        public CsItemlist(DataTable items)
        {
            itemList = items;
        }
    }
}