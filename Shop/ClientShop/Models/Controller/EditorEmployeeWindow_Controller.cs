using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ClientShop.Models.Controller
{
    public class EditorEmployeeWindow_Controller : NotifyPropertyChanged
    {
        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value.Replace("'", "`");
                OnPropertyChanged("Surname");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value.Replace("'", "`"); ;
                OnPropertyChanged("Name");
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

        //ListTypeUser-------------------------------
        private List<string> listTypeUser;
        public List<string> ListTypeUser
        {
            get
            {
                return listTypeUser;
            }
            set
            {
                listTypeUser = value;
                OnPropertyChanged("ListTypeUser");
            }
        }

        private string selectTypeUser;
        public string SelectTypeUser
        {
            get
            {
                return selectTypeUser;
            }
            set
            {
                selectTypeUser = value;
                OnPropertyChanged("SelectTypeUser");
            }
        }
        //ListTypeUser-------------------------------

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

        public ICommand UpdateButton { get; private set; }
        public ICommand DeleteButton { get; private set; }
        public ICommand GoOutButton { get; private set; }
        public ICommand ChangeImageButton { get; private set; }

        public EditorEmployeeWindow_Controller(Action<object>[] ListAction)
        {
            string command = "SELECT name FROM type_user";
            ListTypeUser = Database.GetAElementSelect<string>(command);

            UpdateButton = new DelegateCommand(ListAction[0]);
            DeleteButton = new DelegateCommand(ListAction[1]);
            GoOutButton = new DelegateCommand(ListAction[2]);
            ChangeImageButton = new DelegateCommand(ListAction[3]);
        }
    }
}
