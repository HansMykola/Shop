using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ClientShop.Models.Controller
{
    public class EmployeeWindow_Controller : NotifyPropertyChanged
    {
        private ObservableCollection<StackPanel> myListType;
        public ObservableCollection<StackPanel> MyListType
        {
            get
            {
                return myListType;
            }
            set
            {
                myListType = value;
                OnPropertyChanged("MyListType");
            }
        }

        private ObservableCollection<WrapPanel> myListGoods;
        public ObservableCollection<WrapPanel> MyListGoods
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

        private SoldGoods selectSoldGoods;
        public SoldGoods SelectSoldGoods
        {
            get
            {
                return selectSoldGoods;
            }
            set
            {
                selectSoldGoods = value;
                OnPropertyChanged("SelectSoldGoods");
            }
        }

        private ObservableCollection<SoldGoods> listSoldGoods;
        public ObservableCollection<SoldGoods> ListSoldGoods
        {
            get
            {
                return listSoldGoods;
            }
            set
            {
                listSoldGoods = value;
                OnPropertyChanged("ListSoldGoods");
            }
        }

        public ICommand SoldOutButton { get; private set; }
        public ICommand RemoveButton { get; private set; }
        public ICommand CloseButton { get; private set; }

        public EmployeeWindow_Controller(Action<int> build, Action<object>[] ListAction)
        {
            ListSoldGoods = new ObservableCollection<SoldGoods>();

            MyListType = new ObservableCollection<StackPanel>();

            string command = $"SELECT DISTINCT name FROM type_goods WHERE id_shop = {User.Man.IDShop} AND is_in_bd = true";
            var nameType = Database.GetAElementSelect<string>(command);

            command = $"SELECT DISTINCT id FROM type_goods WHERE id_shop = {User.Man.IDShop} AND is_in_bd = true";
            var idType = Database.GetAElementSelect<int>(command);

            StackPanel wrap = new StackPanel();
            for(int i = 0; i < nameType.Count; ++i)
            {
                wrap.Children.Add(new ButtonType(build)
                                            {
                                                Content = nameType[i],
                                                IDType = idType[i],
                                                Width = 180,
                                                Height = 80,
                                                Margin = new Thickness {
                                                            Left = 5,
                                                            Top = 30,
                                                            Right = 5,
                                                            Bottom = 0 }
                });
            }
            MyListType.Add(wrap);

            SoldOutButton = new DelegateCommand(ListAction[0]);
            RemoveButton = new DelegateCommand(ListAction[1]);
            CloseButton = new DelegateCommand(ListAction[2]);
        }
    }
}
