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
    public class ManagersWindow_Controller : NotifyPropertyChanged
    {
        private ObservableCollection<WrapPanel> desktop;
        public ObservableCollection<WrapPanel> Desktop
        {
            get
            {
                return desktop;
            }
            set
            {
                desktop = value;
                OnPropertyChanged("Desktop");
            }
        }

        private Visibility showElemFirst;
        public Visibility ShowElemFirst
        {
            get
            {
                return showElemFirst;
            }
            set
            {
                showElemFirst = value;
                OnPropertyChanged("ShowElemFirst");
            }
        }

        private Visibility showElemSecond;
        public Visibility ShowElemSecond
        {
            get
            {
                return showElemSecond;
            }
            set
            {
                showElemSecond = value;
                OnPropertyChanged("ShowElemSecond");
            }
        }

        public ICommand ShowButton { get; private set; }
        public ICommand EmployeeButton { get; private set; }
        public ICommand TypeButton { get; private set; }
        public ICommand GoodsButton { get; private set; }
        public ICommand ShipmentButton { get; private set; }
        public ICommand CloseButton { get; private set; }

        public ManagersWindow_Controller(Action<object>[] ListAction)
        {
            Desktop = new ObservableCollection<WrapPanel>();
            ShowButton = new DelegateCommand(ListAction[0]);
            EmployeeButton = new DelegateCommand(ListAction[1]);
            GoodsButton = new DelegateCommand(ListAction[2]);
            CloseButton = new DelegateCommand(ListAction[3]);
            TypeButton = new DelegateCommand(ListAction[4]);
            ShipmentButton = new DelegateCommand(ListAction[5]);
        }
    }
}