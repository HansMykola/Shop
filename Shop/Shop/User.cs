using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class User
    {
        public int ID { get; private set; }
        public string NameShop { get; private set; }
        public OperationContext MyOperationContext { get; set; }

        public User(int id, string nameShop)
        {
            ID = id;
            NameShop = nameShop;
        }
    }
}