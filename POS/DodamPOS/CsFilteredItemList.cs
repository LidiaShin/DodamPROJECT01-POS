using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsFilteredItemList
    {
        public DataTable fiTable { get; set; }

        public string keyiName { get; set; }
        public string keyiNote { get; set; }

        public CsFilteredItemList(string kname,string knote,DataTable ftable)
        {
            keyiName = kname;
            keyiNote = knote;
            fiTable = ftable;
        }

            
            
    }
}