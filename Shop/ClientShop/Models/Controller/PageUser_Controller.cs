using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ClientShop.Models.Controller
{
    public class PageUser_Controller : NotifyPropertyChanged
    {
        private ImageSource picture;
        public ImageSource Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
                OnPropertyChanged("Picture");
            }
        }

        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        private string fullName;
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public ICommand UpdateButton { get; private set; }

        public PageUser_Controller(Action<object> UpdateEmployee)
        {
            UpdateButton = new DelegateCommand(UpdateEmployee);
        }
    }
}
