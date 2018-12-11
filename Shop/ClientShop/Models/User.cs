using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShop.Models
{
    public class User
    {
        public static User Man { get; set; }

        private User()
        {}

        public static void Create()
        {
            if (Man == null)
            {
                Man = new User();
            }
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Oblast { get; set; }
        public string City { get; set; }
        public string NameShop { get; set; }
        public int IDShop { get; set; }
    }
}
