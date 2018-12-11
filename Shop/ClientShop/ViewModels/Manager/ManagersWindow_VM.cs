using ClientShop.Models;
using ClientShop.Models.Controller;
using ClientShop.Views.ManagerEmployee;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ClientShop.ViewModels.Manager
{
    public class ManagersWindow_VM : NotifyPropertyChanged
    {
        public ManagersWindow_Controller Controller { get; private set; }

        public ManagersWindow_VM()
        {
            Controller = new ManagersWindow_Controller(new Action<object>[] { ShowElement, EmployeeButton, GoodsButton, CloseWindow, TypeButton, ShipmentButton });

            Controller.ShowElemFirst = Visibility.Visible;
            Controller.ShowElemSecond = Visibility.Hidden;

            Controller.Desktop.Add(GetPage("Views/ManagerEmployee/PageEmployeesData.xaml"));
        }

        private void ShipmentButton(object obj)
        {
            Controller.Desktop = new ObservableCollection<WrapPanel>();
            Controller.Desktop.Add(GetPage("Views/ManagerShipment/ManagerShipment.xaml"));
        }

        private void TypeButton(object obj)
        {
            Controller.Desktop = new ObservableCollection<WrapPanel>();
            Controller.Desktop.Add(GetPage("Views/ManagerType/ManagerType.xaml"));
        }

        private void GoodsButton(object obj)
        {
            Controller.Desktop = new ObservableCollection<WrapPanel>();
            Controller.Desktop.Add(GetPage("Views/ManagerGoods/ManagerGoods.xaml"));
        }

        private void CloseWindow(object obj)
        {
            ((Window)obj).Close();
        }

        private void EmployeeButton(object obj)
        {
            Controller.Desktop = new ObservableCollection<WrapPanel>();
            Controller.Desktop.Add(GetPage("Views/ManagerEmployee/PageEmployeesData.xaml"));
        }

        private WrapPanel GetPage(string way)
        {
            WrapPanel wrapPanel = new WrapPanel();

            Frame frame = new Frame { Source = new Uri(way, UriKind.Relative) };

            wrapPanel.Children.Add(frame);

            return wrapPanel;
        }

        private void ShowElement(object obj)
        {
            if (Controller.ShowElemFirst == Visibility.Hidden)
            {
                Controller.ShowElemFirst = Visibility.Visible;
                Controller.ShowElemSecond = Visibility.Hidden;
            }
            else
            {
                Controller.ShowElemFirst = Visibility.Hidden;
                Controller.ShowElemSecond = Visibility.Visible;
            }
        }
    }
}