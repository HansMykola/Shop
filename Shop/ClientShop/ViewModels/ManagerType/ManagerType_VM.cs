using ClientShop.Models;
using ClientShop.Models.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientShop.ViewModels.ManagerType
{
    public class ManagerType_VM : NotifyPropertyChanged
    {
        public ManagerType_Controller Controller { get; private set; }

        public ManagerType_VM()
        {
            Controller = new ManagerType_Controller(new Action<object>[] { AddGoods, UpdateGoods, DeleteGoods });

            string command = $"SELECT id, name FROM type_goods WHERE id_shop = {User.Man.IDShop} AND is_in_bd = 1";

            Database.SelectParams(command, 2);

            var id = Database.GetElementParams<int>(0);
            var name = Database.GetElementParams<string>(1);

            Controller.ListTypes = new ObservableCollection<GoodsType>();

            for(int i = 0; i < id.Count; ++i)
            {
                Controller.ListTypes.Add(new GoodsType { ID = id[i], Name = name[i] });
            }
        }

        private void DeleteGoods(object obj)
        {
            if (Controller.SelectGoodsType != null)
            {
                string command = $"UPDATE type_goods SET is_in_bd = 0 WHERE id = {Controller.SelectGoodsType.ID}";
                Database.DeleteData(command);

                Controller.ListTypes.Remove(Controller.SelectGoodsType);
            }
            else
            {
                MessageBox.Show("Ви не вибрали елемент");
            }
        }

        private void UpdateGoods(object obj)
        {
            if (Controller.SelectGoodsType != null)
            {
                string command = $"UPDATE type_goods SET name = '{Controller.Name}' WHERE id = {Controller.SelectGoodsType.ID} AND is_in_bd = 1";
                Database.UpdateData(command);

                Controller.SelectGoodsType.Name = Controller.Name;
            }
            else
            {
                MessageBox.Show("Ви не вибрали елемент");
            }
        }

        private void AddGoods(object obj)
        {
            if (Controller.Name != null)
            {
                string command = $"INSERT INTO type_goods(name, id_shop, is_in_bd) VALUES ('{Controller.Name}', {User.Man.IDShop}, 1)";
                Database.InsertData(command);

                command = $"SELECT MAX(id) FROM type_goods WHERE id_shop = {User.Man.IDShop} AND is_in_bd = 1";
                int id = Database.GetAElementSelect<int>(command)[0];

                Controller.ListTypes.Add(new GoodsType { ID = id, Name = Controller.Name });
            }
            else
            {
                MessageBox.Show("Ви не ввели назву");
            }
        }
    }
}
