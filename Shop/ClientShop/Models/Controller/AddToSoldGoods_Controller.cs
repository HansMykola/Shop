using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientShop.Models.Controller
{
    public class AddToSoldGoods_Controller : NotifyPropertyChanged
    {
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

        public ICommand AddGoodsButton { get; private set; }
        public ICommand CloseButton { get; private set; }

        public AddToSoldGoods_Controller(Action<object>[] ListAction)
        {
            AddGoodsButton = new DelegateCommand(ListAction[0]);
            AddGoodsButton = new DelegateCommand(ListAction[1]);
        }
    }
}
