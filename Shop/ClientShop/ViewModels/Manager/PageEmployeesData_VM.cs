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
    public class PageEmployeesData_VM : NotifyPropertyChanged
    {
        public PageEmployeesData_Controller Controller { get; private set; }
        public ObservableCollection<Frame> ListFrame { get; set; }

        private List<Employee> Employees { get; set; }
        private WrapPanel MyWrapPanel { get; set; }
        private Frame FirstFrame { get; set; }
        private Frame LastFrame { get; set; }

        public PageEmployeesData_VM()
        {
            Employees = GetListEmployees();
            ListFrame = new ObservableCollection<Frame>();
            Controller = new PageEmployeesData_Controller();

            MyWrapPanel = new WrapPanel();
            FirstFrame = new Frame { Width = 140, Height = 230,
                                     Margin = new Thickness { Bottom = 0, Left = 10, Right = 0, Top = 20 },
                                     Source = new Uri("Views/ManagerEmployee/AddEmployee.xaml", UriKind.Relative) };
            MyWrapPanel.Children.Add(FirstFrame);

            for(int i = 0; i < Employees.Count; ++i)
            {
                ListFrame.Add(new Frame {  Width = 140, Height = 230,
                                           Margin = new Thickness { Bottom = 0, Left = 10, Right = 0, Top = 20 },
                                           Source = new Uri("Views/ManagerEmployee/PageUser.xaml", UriKind.Relative) });
                MyWrapPanel.Children.Add(ListFrame[i]);
            }

            LastFrame = ListFrame[Employees.Count - 1];
            Controller.ListEmployees.Add(MyWrapPanel);

            Task.Factory.StartNew(() =>
            {
                ConnectFrame(0, true);
            });
        }

        private void ConnectFrame(int index, bool first)
        {
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new Action(() =>
                {
                    while (LastFrame.DataContext == null)
                    {
                        Thread.Sleep(10);
                    }

                    if (first)
                    {
                        var addPage = (AddEmployee)FirstFrame.Content;
                        addPage.DataContext = new AddEmployee_VM(AddNewEmployee);
                    }

                    for (int j = index; j < ListFrame.Count; ++j)
                    {
                        var elem = (PageUser)ListFrame[j].Content;
                        elem.DataContext = new PageUser_VM(Layoffs, Employees[j]);
                    }
                }));
        }

        private void Layoffs(Employee employee)
        {
            var element = ListFrame.ToList().FindLast(elem =>
                ((PageUser_VM)((PageUser)elem.Content).DataContext).ID == employee.ID);
            MyWrapPanel.Children.Remove(element);
            Employees.Remove(employee);
        }

        private List<Employee> GetListEmployees()
        {
            string command = $"SELECT DISTINCT A.surname, A.name, A.login, A.password, A.phone, B.name, A.id FROM user A, type_user B "
                + $"WHERE A.id_shop = {User.Man.IDShop} AND B.id = A.id_type_user GROUP BY A.id";

            Database.SelectParams(command, 7);

            List<Employee> employees = new List<Employee>();

            var surnames = Database.GetElementParams<string>(0);
            var names = Database.GetElementParams<string>(1);
            var logins = Database.GetElementParams<string>(2);
            var passwords = Database.GetElementParams<string>(3);
            var phones = Database.GetElementParams<string>(4);
            var types = Database.GetElementParams<string>(5);
            var id = Database.GetElementParams<int>(6);
            
            command = $"SELECT DISTINCT image FROM user WHERE id_shop = {User.Man.IDShop}";

            var images = Database.GetArrayBytesImage(command);

            for (int i = 0; i < names.Count; ++i)
            {
                employees.Add(new Employee
                {
                    ID = id[i],
                    Surname = surnames[i],
                    Name = names[i],
                    Login = logins[i],
                    Password = passwords[i],
                    Phone = phones[i],
                    Type = types[i],
                    Image = images[i]
                });
            }

            return employees;
        }

        private void AddNewEmployee(Employee employee)
        {
            Employees.Add(employee);
            ListFrame.Add(new Frame { Width = 140,
                                        Height = 230,
                                        Margin = new Thickness { Bottom = 0, Left = 10, Right = 0, Top = 20 },
                                        Source = new Uri("Views/ManagerEmployee/PageUser.xaml", UriKind.Relative) });

            int lastIndex = Employees.Count - 1;
            MyWrapPanel.Children.Add(ListFrame[lastIndex]);
            LastFrame = ListFrame[lastIndex];

            Task.Factory.StartNew(() => {
                ConnectFrame(lastIndex, false);
            });
        }
    }
}
