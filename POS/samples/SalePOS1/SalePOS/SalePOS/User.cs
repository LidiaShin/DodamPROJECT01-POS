using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalePOS
{
    public class User
    {
        public int userID { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Position { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public User(string id, string userName, string pass, string position, string name, string surname, string phone, string add)
        {
            userID = Convert.ToInt32(id);
            UserName = userName;
            Password = pass;
            Position = position;
            FirstName = name;
            LastName=surname;
            Phone=phone;
            Address=add;

        }
        
    }
}
