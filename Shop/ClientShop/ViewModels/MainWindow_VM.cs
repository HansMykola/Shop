using ClientShop.Models;
using ClientShop.Views.Employee;
using ClientShop.Views.ManagerEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientShop.ViewModels
{
    public class MainWindow_VM : NotifyPropertyChanged
    {
        public MainWindow_Controller Controller { get; private set; }
        private User Man { get; set; }
        public MainWindow_VM()
        {
            User.Create();
            Man = User.Man;
            Controller = new MainWindow_Controller(new Action<object>[] { SignIn, GoOut });
        }

        private async void SignIn(object obj)
        {
            string command = $"SELECT A.id_shop FROM user A, type_user B, shop C "
                + $" WHERE A.login = '{Controller.Login}' "
                + $" AND A.password = '{Controller.Password}' "
                + $" AND A.id_type_user = B.id "
                + $" AND B.name = '{Controller.SelectTypeUser}' "
                + $" AND C.name = '{Controller.SelectNameShop}' "
                + $" AND C.id = A.id_shop";

            bool next = await AuditLogin();
            if (next)
            {
                if (Database.IsElem(command))
                {
                    Man.IDShop = Database.GetAElementSelect<int>(command)[0];
                    Man.Login = Controller.Login;
                    Man.Password = Controller.Password;
                    Man.Type = Controller.SelectTypeUser;
                    Man.Oblast = Controller.SelectOblast;
                    Man.City = Controller.SelectCity;
                    Man.NameShop = Controller.SelectNameShop;

                    //if (Man.Type == "Менеджер")
                    //{

                    //}
                    ManagersWindow managers = new ManagersWindow();
                    managers.ShowDialog();

                    //EmployeeWindowWork employee = new EmployeeWindowWork();
                    //employee.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неправильні дані");
                }
            }
        }

        private async Task<bool> AuditLogin()
        {
            bool right = false;
            string listSS = "";

            right = await Task.Factory.StartNew(() =>
            {
                if (Controller.Login != null)
                {
                    var sa = Controller.Login;
                    for (int i = 0; i < sa.Length; ++i)
                    {
                        if (!((sa[i] >= 'a') && (sa[i] <= 'z')))
                        {
                            listSS += "Логін може містити символи (a-z)\n";
                            return false;
                        }
                    }
                }
                else
                {
                    listSS += "Ви не ввели логін\n";
                    return false;
                }
                return true;
            });

            right = await Task.Factory.StartNew(() =>
            {
                if ((Controller.Password != null)
                && (Controller.Password.Length == 4))
                {
                    var sa = Controller.Password;
                    for (int i = 0; i < sa.Length; ++i)
                    {
                        if (!((sa[i] >= '0') && (sa[i] <= '9')))
                        {
                            listSS += "Пароль може містити символи (0-9)\n";
                            return false;
                        }
                    }
                }
                else
                {
                    listSS += "Пароль має складатись з 4 символів\n";
                    return false;
                }
                return true;
            });

            right = await Task.Factory.StartNew(() =>
            {
                if (Controller.SelectTypeUser != null)
                {
                    return true;
                }
                listSS += "Ви не вибрали посаду\n";
                return false;
            });

            right = await Task.Factory.StartNew(() =>
            {
                if (Controller.SelectOblast != null)
                {
                    return true;
                }
                listSS += "Ви не вибрали область\n";
                return false;
            });

            right = await Task.Factory.StartNew(() =>
            {
                if (Controller.SelectCity != null)
                {
                    return true;
                }
                listSS += "Ви не вибрали місто\n";
                return false;
            });

            right = await Task.Factory.StartNew(() =>
            {
                if (Controller.SelectNameShop != null)
                {
                    return true;
                }
                listSS += "Ви не вибрали магазин\n";
                return false;
            });

            if (listSS != "")
            {
                MessageBox.Show(listSS); 
            }

            return right;
        }

        private void GoOut(object obj)
        {
            ((Window)obj).Close();
        }


    }
}
