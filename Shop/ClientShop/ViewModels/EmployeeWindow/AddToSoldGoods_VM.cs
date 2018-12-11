using ClientShop.Models;
using ClientShop.Models.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientShop.ViewModels.EmployeeWindow
{
    public class AddToSoldGoods_VM
    {
        public SoldGoods Sold { get; set; }
        public Action<SoldGoods> AddToList { get; set; }
        public AddToSoldGoods_Controller Controller { get; private set; }

        public AddToSoldGoods_VM()
        {            
            Controller = new AddToSoldGoods_Controller(new Action<object>[] { AddButton, CloseButton });
        }

        private void CloseButton(object obj)
        {
            ((Window)obj).Close();
        }

        private void AddButton(object obj)
        {
            if (Convert.ToInt32(Sold.Number) <= Convert.ToInt32(Controller.Number))
            {
                Sold.NumberSold += Convert.ToInt32(Controller.Number);
                AddToList(Sold);
                Sold.Number = Convert.ToInt32(Sold.Number) - Sold.NumberSold;
                Sold.UpdateButton();
                ((Window)obj).Close();
            }
            else
            {
                MessageBox.Show($"На складі є {Sold.Number}");
            }
        }
    }
}
