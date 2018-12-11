using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientShop.Models.Controller
{
    public class ManagerGoods_Controller : NotifyPropertyChanged
    {
        private ObservableCollection<Goods> myListGoods;
        public ObservableCollection<Goods> MyListGoods
        {
            get
            {
                return myListGoods;
            }
            set
            {
                myListGoods = value;
                OnPropertyChanged("MyListGoods");
            }
        }

        //ListTypeGoods-------------------------------
        private List<string> listTypeGoods;
        public List<string> ListTypeGoods
        {
            get
            {
                return listTypeGoods;
            }
            set
            {
                listTypeGoods = value;
                OnPropertyChanged("ListTypeGoods");
            }
        }

        private string selectTypeGoods;
        public string SelectTypeGoods
        {
            get
            {
                return selectTypeGoods;
            }
            set
            {
                selectTypeGoods = value;
                OnPropertyChanged("SelectTypeGoods");
            }
        }
        //ListTypeGoods-------------------------------

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value.Replace("'", "`"); ;
                OnPropertyChanged("Name");
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

        private Goods selectGoods;
        public Goods SelectGoods
        {
            get
            {
                return selectGoods;
            }
            set
            {
                selectGoods = value;
                if (selectGoods != null)
                {
                    Name = selectGoods.Name;
                    Price = selectGoods.Price;
                    SelectTypeGoods = selectGoods.Type;
                }
                else
                {
                    Name = "";
                    Price = "";
                }
                OnPropertyChanged("SelectGoods");
            }
        }

        public ICommand AddButton { get; private set; }
        public ICommand UpdateButton { get; private set; }
        public ICommand DeleteButton { get; private set; }


        public ManagerGoods_Controller(Action<object>[] ListAction)
        {
            string command = $"SELECT name FROM type_goods WHERE id_shop = {User.Man.IDShop} AND is_in_bd = true";
            ListTypeGoods = Database.GetAElementSelect<string>(command);

            MyListGoods = new ObservableCollection<Goods>();

            AddButton = new DelegateCommand(ListAction[0]);
            UpdateButton = new DelegateCommand(ListAction[1]);
            DeleteButton = new DelegateCommand(ListAction[2]);
        }
    }
}
