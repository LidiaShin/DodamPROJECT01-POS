using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalePOS
{
    class MenuItem
    {
        public string Name { get; private set; }

        public int ID { get; private set; }
        public string Category { get; private set; }
        public double Prize { get; private set; }

        public Image itemImage;
        public MenuItem(string id, string name, string category, string prize,Image im)
        {
            Name = name;
            Category = category;
            Prize = Convert.ToDouble(prize);
            ID = Convert.ToInt32(id);
            itemImage = im;
            //id++;
        }
        public override string ToString()
        {
            return String.Format("ID:{0}, Name:{1}, Category:{2}, Prize:{3}", ID, Name, Category, Prize);
        }
    }
}
