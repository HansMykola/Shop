using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientShop.Models
{
    public class MainWindow_Controller : NotifyPropertyChanged
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

        //ListOblast-------------------------------
        private List<string> listOblast;
        public List<string> ListOblast
        {
            get
            {
                return listOblast;
            }
            set
            {
                listOblast = value;
                OnPropertyChanged("ListOblast");
            }
        }

        private string selectOblast;
        public string SelectOblast
        {
            get
            {
                return selectOblast;
            }
            set
            {
                selectOblast = value;
                string command = $" SELECT A.name FROM town A, oblast B " 
                    +   $"WHERE A.id_oblast = B.id AND B.name = '{SelectOblast}' ";
                ListCity = Database.GetAElementSelect<string>(command);
                OnPropertyChanged("SelectOblast");
            }
        }
        //ListOblast-------------------------------

        //ListCity-------------------------------
        private List<string> listCity;
        public List<string> ListCity
        {
            get
            {
                return listCity;
            }
            set
            {
                listCity = value;
                OnPropertyChanged("ListCity");
            }
        }

        private string selectCity;
        public string SelectCity
        {
            get
            {
                return selectCity;
            }
            set
            {
                selectCity = value;
                string command = $" SELECT A.name FROM shop A, town B "
                    + $"WHERE A.id_town = B.id AND B.name = '{selectCity}' ";
                ListNameShop = Database.GetAElementSelect<string>(command);
                OnPropertyChanged("SelectCity");
            }
        }
        //ListCity-------------------------------

        //ListNameShop-------------------------------
        private List<string> listNameShop;
        public List<string> ListNameShop
        {
            get
            {
                return listNameShop;
            }
            set
            {
                listNameShop = value;
                OnPropertyChanged("ListNameShop");
            }
        }

        private string selectNameShop;
        public string SelectNameShop
        {
            get
            {
                return selectNameShop;
            }
            set
            {
                selectNameShop = value;
                OnPropertyChanged("SelectNameShop");
            }
        }
        //ListNameShop-------------------------------

        public ICommand SignInButton { get; private set; }
        public ICommand GoOutButton { get; private set; }

        public MainWindow_Controller(Action<object>[] ListAction)
        {
            string command = "SELECT name FROM type_user";
            ListTypeUser = Database.GetAElementSelect<string>(command);

            command = "SELECT name FROM oblast";
            ListOblast = Database.GetAElementSelect<string>(command);

            SignInButton = new DelegateCommand(ListAction[0]);
            GoOutButton = new DelegateCommand(ListAction[1]);
        }
    }
}
