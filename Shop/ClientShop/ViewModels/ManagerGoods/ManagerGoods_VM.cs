using ClientShop.Models;
using ClientShop.Models.Controller;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ClientShop.ViewModels.ManagerGoods
{
    public class ManagerGoods_VM
    {
        public ManagerGoods_Controller Controller { get; private set; }

        public ManagerGoods_VM()
        {
            Controller = new ManagerGoods_Controller(new Action<object>[] { AddGoods, UpdateGoods, DeleteGoods });

            string command = $"SELECT A.id, A.name, A.price, B.name FROM goods A, type_goods B "
                + $"WHERE A.is_in_bd = 1 "
                + $"AND A.id_type_goods = B.id "
                + $"AND B.id_shop = {User.Man.IDShop} " 
                + $"AND B.is_in_bd = 1 ";
            Database.SelectParams(command, 4);

            var id = Database.GetElementParams<int>(0);
            var name = Database.GetElementParams<string>(1);
            var price = Database.GetElementParams<double>(2);
            var type = Database.GetElementParams<string>(3);

            for(int i = 0; i < id.Count; ++i)
            {
                Controller.MyListGoods.Add(new Goods { ID = id[i],
                    Name = name[i],
                    Type = type[i],
                    Price = price[i].ToString()
                });
            }
        }

        private async Task<bool> AuditLogin()
        {
            bool right = false;
            string listSS = "";

            right = await Task.Factory.StartNew(() =>
            {
                if (Controller.Name == null)
                {
                    listSS += "Ви не ввели ціну\n";
                    return false;
                }
                return true;
            });

            right = await Task.Factory.StartNew(() =>
            {
                if (Controller.SelectTypeGoods == null)
                {
                    listSS += "Ви не вибрали тип\n";
                    return false;
                }
                return true;
            });

            right = await Task.Factory.StartNew(() =>
            {
                if (Controller.Price != null)
                {
                    var sa = Controller.Price;
                    for (int i = 0; i < sa.Length; ++i)
                    {
                        if ((!((sa[i] >= '0') && (sa[i] <= '9'))) && !(sa[i] == ','))
                        {
                            listSS += "Карл якщо пише ціна значить вводь числа\n";
                            return false;
                        }
                    }
                }
                else
                {
                    listSS += "Ви не ввели ціну\n";
                    return false;
                }
                return true;
            });

            if (listSS != "")
            {
                MessageBox.Show(listSS);
            }

            return right;
        }


        private void DeleteGoods(object obj)
        {
            if (Controller.SelectGoods != null)
            {
                string command = $"UPDATE goods SET is_in_bd = 0 WHERE id = {Controller.SelectGoods.ID} ";
                Database.UpdateData(command);

                Controller.SelectGoods = Controller.MyListGoods.Count > 0 ? Controller.MyListGoods[0] : null;
                Controller.MyListGoods.Remove(Controller.SelectGoods);
            }
        }

        private async void UpdateGoods(object obj)
        {
            var can = await AuditLogin();
            if (can)
            {
                string command = $"UPDATE goods SET name = '{Controller.Name}', "
                + $"price = {Controller.Price}, "
                + $"id_type_goods = (SELECT id FROM type_goods WHERE name = '{Controller.SelectTypeGoods}') "
                + $"WHERE id = {Controller.SelectGoods.ID} ";

                Database.UpdateData(command);

                Controller.SelectGoods.Name = Controller.Name;
                Controller.SelectGoods.Price = Controller.Price;
                Controller.SelectGoods.Type = Controller.SelectTypeGoods;
            }
        }

        private async void AddGoods(object obj)
        {
            var can = await AuditLogin();
            if (can)
            {
                string command = $"INSERT INTO goods(name, price, id_type_goods, is_in_bd) "
                    + $"VALUES ('{Controller.Name}', {Controller.Price}, (SELECT DISTINCT id FROM type_goods WHERE name = '{Controller.SelectTypeGoods}' LIMIT 1), 1)";
                Database.InsertData(command);

                Controller.MyListGoods.Add(new Goods
                {
                    ID = Database.GetAElementSelect<int>($"SELECT DISTINCT MAX(id) FROM goods "
                    + $"WHERE name = '{Controller.Name}' "
                    + $"AND price = {Controller.Price} "
                    + $"AND id_type_goods = (SELECT DISTINCT id FROM type_goods WHERE name = '{Controller.SelectTypeGoods}' LIMIT 1)")[0],
                    Name = Controller.Name,
                    Type = Controller.SelectTypeGoods,
                    Price = Controller.Price
                });
            }
        }
    }
}
