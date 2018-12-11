using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClientShop.Models.Controller
{
    public class PageEmployeesData_Controller : NotifyPropertyChanged
    {
        private ObservableCollection<WrapPanel> listEmployees;
        public ObservableCollection<WrapPanel> ListEmployees
        {
            get
            {
                return listEmployees;
            }
            set
            {
                listEmployees = value;
                OnPropertyChanged("ListEmployees");
            }
        }

        public PageEmployeesData_Controller()
        {
            ListEmployees = new ObservableCollection<WrapPanel>();
        }
    }
}
