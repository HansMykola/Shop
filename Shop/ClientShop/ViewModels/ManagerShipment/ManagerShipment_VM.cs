using ClientShop.Models;
using ClientShop.Models.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientShop.ViewModels.ManagerShipment
{
    public class ManagerShipment_VM
    {
        public ManagerShipment_Controller Controller { get; set; }

        public ManagerShipment_VM()
        {
            Controller = new ManagerShipment_Controller(new Action<object>[] { AddButton, UpdateButton, DeleteButton });
        }

        private void DeleteButton(object obj)
        {
            if (Controller.SelecteShipment != null)
            {
                string command = $"DELETE FROM shipment WHERE id = {Controller.SelecteShipment.ID} ";
                Database.DeleteData(command);

                Controller.ListShipments.Remove(Controller.SelecteShipment);
                Controller.Price = "";
                Controller.Number = "";
            }
            else
            {
                MessageBox.Show("Ви не вибрали поставку");
            }
        }

        private void UpdateButton(object obj)
        {
            if (Controller.SelecteShipment != null)
            {
                string command = $"UPDATE shipment SET price = {Controller.Price}, " 
                    + $" number = {Controller.Number}, "
                    + $" balance_of_quantity = {Controller.Number}, "
                    + $" id_goods = (SELECT DISTINCT id FROM goods WHERE name = '{Controller.SelectGoods}' LIMIT 1), "
                    + $" date = '{Controller.MyCalendar.ToString("yyyy/MM/dd").Replace(".", "-")}' "
                    + $" WHERE id = {Controller.SelecteShipment.ID} ";
                Database.UpdateData(command);

                Controller.SelecteShipment.Price = Controller.Price;
                Controller.SelecteShipment.Number = Controller.Number;
                Controller.SelecteShipment.GoodsName = Controller.SelectGoods;
                Controller.SelecteShipment.TypeName = Controller.SelectTypeGoods;
            }
            else
            {
                MessageBox.Show("Ви не вибрали поставку");
            }
        }

        private void AddButton(object obj)
        {
            string command = $"INSERT INTO shipment(number, price, date, balance_of_quantity, id_goods) " 
                + $"VALUES ({Controller.Number}, " 
                + $"{Controller.Price}, " 
                + $"'{Controller.MyCalendar.ToString("yyyy/MM/dd").Replace(".", "-")}', " 
                + $"{Controller.Number}, " 
                + $"(SELECT DISTINCT id FROM goods WHERE name = '{Controller.SelectGoods}' LIMIT 1))";
            Database.InsertData(command);

            command = $"SELECT MAX(id) FROM shipment " 
                + $"WHERE id_goods = (SELECT DISTINCT id FROM goods WHERE name = '{Controller.SelectGoods}' LIMIT 1)";

            var id = Database.GetAElementSelect<int>(command)[0];

            Controller.ListShipments.Add(new Shipment {
                ID = id,
                Number = Controller.Number,
                Price = Controller.Price,
                GoodsName = Controller.SelectGoods,
                TypeName = Controller.SelectTypeGoods
            });
        }
    }
}
