using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DodamPOS
{
    public class CsItem
    {
        public string itemNumber { get; set; }
        public string itemCategory { get; set; }
        public string itemName { get; set; }

        public string itemPPrice { get; set; }
        public string itemRPrice { get; set; }
        public string itemNote { get; set; }
        public string itemImage { get; set; }
        public string itemQuantity { get; set; }

        public string itemRegisterDate { get; set; }

        public CsItem(string inum,string icat,string iname,string ipprice,string irprice,string inote,string iimage,string iqty,string idate)
        {
            itemNumber = inum;
            itemCategory = icat;
            itemName = iname;
            itemPPrice = ipprice;
            itemRPrice = irprice;
            itemNote = inote;
            itemImage = iimage;
            itemQuantity = iqty;
            itemRegisterDate = idate;
        }
    }
}