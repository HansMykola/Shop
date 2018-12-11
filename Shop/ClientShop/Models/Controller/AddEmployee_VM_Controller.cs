using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientShop.Models.Controller
{
    public class AddEmployee_VM_Controller
    {
        public ICommand AddButton { get; set; }

        public AddEmployee_VM_Controller(Action<object> add)
        {
            AddButton = new DelegateCommand(add);
        }
    }
}
