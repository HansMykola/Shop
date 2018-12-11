using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShop.Models
{
    public class SoldGoods : NotifyPropertyChanged
    {
        public int ID { get; set; }

        private double sum;
        public double Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }

        private int number;
        public int Number
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

        private int numberSold;
        public int NumberSold
        {
            get
            {
                return numberSold;
            }
            set
            {
                numberSold = value;
                OnPropertyChanged("NumberSold");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public Action UpdateButton { get; set; }
    }
}
