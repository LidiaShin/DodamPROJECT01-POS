using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsItemCat
    {
        public DataTable itemCategory { get; set; }

        public CsItemCat(DataTable itemcat)
        {
            itemCategory = itemcat;
        }
    }
}