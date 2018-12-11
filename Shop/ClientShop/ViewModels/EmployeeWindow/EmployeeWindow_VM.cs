using ClientShop.Models;
using ClientShop.Models.Controller;
using ClientShop.Views.Employee;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClientShop.ViewModels.EmployeeWindow
{
    public class EmployeeWindow_VM : NotifyPropertyChanged
    {
        public EmployeeWindow_Controller Controller { get; set; }
           
        public EmployeeWindow_VM()
        {
            Controller = new EmployeeWindow_Controller(Build, new Action<object>[] { SoldOutButton, RemoveButton, CloseButton });
        }

        private void CloseButton(object obj)
        {
            ((Window)obj).Close();
        }

        private void RemoveButton(object obj)
        {
            Controller.ListSoldGoods.Remove(Controller.SelectSoldGoods);
        }

        private void SoldOutButton(object obj)
        {
            
        }

        private async void Build(int id)
        {
            Controller.MyListGoods = new ObservableCollection<WrapPanel>();
            Controller.ListSoldGoods = new ObservableCollection<SoldGoods>();
            string command = $"SELECT id, name, price FROM goods "
                + $"WHERE id_type_goods = {id}";

            Database.SelectParams(command, 3);

            var idGoods = Database.GetElementParams<int>(0);
            var name = Database.GetElementParams<string>(1);
            var price = Database.GetElementParams<double>(2);

            WrapPanel wrap = new WrapPanel();

            for (int i = 0; i < name.Count; ++i)
            {
                command = $"SELECT A.balance_of_quantity FROM shipment A, goods B "
                + $"WHERE A.id_goods = B.id AND B.name = '{name[i]}'";
                var number = Database.GetAElementSelect<int>(command);
                int numberSum = await Task.Factory.StartNew(() =>
                {
                    int s = 0;
                    for (int j = 0; j < number.Count; ++j)
                    {
                        s += number[j];
                    }
                    return s;
                });

                Controller.ListSoldGoods.Add(new SoldGoods
                {
                    ID = idGoods[i],
                    Name = name[i],
                    Number = numberSum,
                    Price = price[i],
                    NumberSold = 0
                });

                wrap.Children.Add(new ButtonGoods(AddListSold, Controller.ListSoldGoods[i])
                {                    
                    Width = 180,
                    Height = 100,

                    Margin = new Thickness
                    {
                        Left = 30,
                        Top = 30,
                        Right = 0,
                        Bottom = 0
                    }
                });
            }
            Controller.MyListGoods.Add(wrap);
        }

        private void AddListSold(SoldGoods elem)
        {
            AddToSoldGoods openWondow = new AddToSoldGoods();
            ((AddToSoldGoods_VM)openWondow.DataContext).AddToList = AddElemToList;
            ((AddToSoldGoods_VM)openWondow.DataContext).Sold = elem;
            openWondow.ShowDialog();
        }

        private void AddElemToList(SoldGoods elem)
        {
            Controller.ListSoldGoods.Add(elem);
        }
    }
}
