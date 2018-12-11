using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShop.Models
{
    public class Shipment : NotifyPropertyChanged
    {
        public int ID { get; set; }

        private string typeName;
        public string TypeName
        {
            get
            {
                return typeName;
            }
            set
            {
                typeName = value;
                OnPropertyChanged("TypeName");
            }
        }

        private string goodsName;
        public string GoodsName
        {
            get
            {
                return goodsName;
            }
            set
            {
                goodsName = value;
                OnPropertyChanged("GoodsName");
            }
        }

        private string number;
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        private string price;
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value.Replace(",", ".");
                OnPropertyChanged("Price");
            }
        }
    }
}
