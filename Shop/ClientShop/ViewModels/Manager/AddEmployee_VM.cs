using ClientShop.Models;
using ClientShop.Models.Controller;
using ClientShop.Views.ManagerEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientShop.ViewModels.Manager
{
    public class AddEmployee_VM
    {
        public Action<Employee> AddEmployeeMet { get; set; }
        public AddEmployee_VM_Controller Controller { get; private set; }

        public AddEmployee_VM(Action<Employee> addEmployeeMet)
        {
            AddEmployeeMet = addEmployeeMet;
            Controller = new AddEmployee_VM_Controller(AddNewEmployee);
        }

        private void AddNewEmployee(object obj)
        {
            if (User.Man.Type == "Менеджер")
            {
                AddEmployeeWindow window = new AddEmployeeWindow();
                window.DataContext = new AddEmployeeWindow_VM(AddEmployeeMet);
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Додавати і редагувати може тільки менеджер");
            }
        }
    }
}
