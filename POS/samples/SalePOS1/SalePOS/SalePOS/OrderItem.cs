using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalePOS
{
    class OrderItem
    {
        public static int id = 0;
        public string Name { get; private set; }
        public int productID { get; private set; }

        public int Qty { get; private set; }
        public string Category { get; private set; }

        

        public double Prize { get; private set; }

        public OrderItem(string proID,string name,string categ, double prize, int qty = 1)
        {

            productID = Convert.ToInt32(proID);
            Category = categ;
            Name = name;
            Prize = prize;
            Qty = qty;
            id++;
        }

    }
}
