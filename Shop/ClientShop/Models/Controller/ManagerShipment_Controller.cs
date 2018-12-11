using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientShop.Models.Controller
{
    public class ManagerShipment_Controller : NotifyPropertyChanged
    {
        private ObservableCollection<Shipment> listShipments;
        public ObservableCollection<Shipment> ListShipments
        {
            get
            {
                return listShipments;
            }
            set
            {
                listShipments = value;
                OnPropertyChanged("ListShipments");
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
                string command = $"SELECT DISTINCT name FROM goods "
                    + $"WHERE id_type_goods = (SELECT DISTINCT id FROM type_goods WHERE name = '{SelectTypeGoods}' LIMIT 1)";
                ListGoods = Database.GetAElementSelect<string>(command);
                OnPropertyChanged("SelectTypeGoods");
            }
        }
        //ListTypeGoods-------------------------------

        //ListGoods-------------------------------
        private List<string> listGoods;
        public List<string> ListGoods
        {
            get
            {
                return listGoods;
            }
            set
            {
                listGoods = value;
                OnPropertyChanged("ListGoods");
            }
        }

        private string selectGoods;
        public string SelectGoods
        {
            get
            {
                return selectGoods;
            }
            set
            {
                selectGoods = value;
                OnPropertyChanged("SelectGoods");
            }
        }
        //ListGoods-------------------------------

        private DateTime myCalendar;
        public DateTime MyCalendar
        {
            get
            {
                return myCalendar;
            }
            set
            {
                myCalendar = value;
                OnPropertyChanged("MyCalendar");
            }
        }

        private DateTime myDatePicker;
        public DateTime MyDatePicker
        {
            get
            {
                return myDatePicker;
            }
            set
            {
                myDatePicker = value;

                string command = $"SELECT A.id, A.price, A.number, B.name, C.name FROM shipment A, goods B, type_goods C " 
                                 + $"WHERE A.date = '{MyDatePicker.ToString("yyyy/MM/dd")}' " 
                                 + $"AND C.is_in_bd = 1 "
                                 + $"AND C.id = B.id_type_goods "
                                 + $"AND B.is_in_bd = 1 "
                                 + $"AND B.id = A.id_goods";

                Database.SelectParams(command, 5);

                var id = Database.GetElementParams<int>(0);
                var price = Database.GetElementParams<double>(1);
                var number = Database.GetElementParams<int>(2);
                var nameGoods = Database.GetElementParams<string>(3);
                var nameType = Database.GetElementParams<string>(4);

                ListShipments = new ObservableCollection<Shipment>();

                for (int i = 0; i < id.Count; ++i)
                {
                    ListShipments.Add(new Shipment {
                        ID = id[i],
                        Price = price[i].ToString(),
                        Number = number[i].ToString(),
                        GoodsName = nameGoods[i],
                        TypeName = nameType[i]
                    });
                }

                OnPropertyChanged("MyDatePicker");
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
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private Shipment selecteShipment;
        public Shipment SelecteShipment
        {
            get
            {
                return selecteShipment;
            }
            set
            {
                selecteShipment = value;

                if (selecteShipment != null)
                {
                    SelectTypeGoods = SelecteShipment.TypeName;
                    SelectGoods = SelecteShipment.GoodsName;
                    Number = SelecteShipment.Number;
                    Price = SelecteShipment.Price;
                }
                else
                {
                    Number = "";
                    Price = "";
                }

                OnPropertyChanged("SelecteShipment");
            }
        }

        public ICommand AddButton { get; private set; }
        public ICommand UpdateButton { get; private set; }
        public ICommand DeleteButton { get; private set; }

        public ManagerShipment_Controller(Action<object>[] ListAction)
        {
            string command = $"SELECT name FROM type_goods WHERE id_shop = {User.Man.IDShop} AND is_in_bd = true";
            ListTypeGoods = Database.GetAElementSelect<string>(command);

            MyDatePicker = DateTime.Now;
            MyCalendar = DateTime.Now;

            AddButton = new DelegateCommand(ListAction[0]);
            UpdateButton = new DelegateCommand(ListAction[1]);
            DeleteButton = new DelegateCommand(ListAction[2]);
        }
    }
}
