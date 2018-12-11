using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClientShop.Models
{
    public class ButtonGoods : Button, INotifyPropertyChanged
    {
        private SoldGoods MySoldGoods { get; set; }
        private Action<SoldGoods> StartSold { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ButtonGoods(Action<SoldGoods> startSold, SoldGoods soldGoods)
        {
            StartSold = startSold;
            MySoldGoods = soldGoods;
            MySoldGoods.UpdateButton = UpdateContent;
            MySoldGoods.UpdateButton();
            Command = new DelegateCommand(ClickForButton);
        }

        public void UpdateContent()
        {
            Content = $"{MySoldGoods.Name}\n{MySoldGoods.Price}₴\n{MySoldGoods.Number}";
        }

        private void ClickForButton(object obj)
        {
            StartSold(MySoldGoods);
        }
    }
}
