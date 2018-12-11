using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientShop.Models.Controller
{
    public class ManagerType_Controller : NotifyPropertyChanged
    {
        private ObservableCollection<GoodsType> listTypes;
        public ObservableCollection<GoodsType> ListTypes
        {
            get
            {
                return listTypes;
            }
            set
            {
                listTypes = value;
                OnPropertyChanged("ListTypes");
            }
        }

        private GoodsType selectGoodsType;
        public GoodsType SelectGoodsType
        {
            get
            {
                return selectGoodsType;
            }
            set
            {
                selectGoodsType = value;

                if (selectGoodsType != null)
                {
                    Name = selectGoodsType.Name;
                }
                else
                {
                    Name = "";
                }

                OnPropertyChanged("SelectGoodsType");
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

        public ICommand AddButton { get; private set; }
        public ICommand UpdateButton { get; private set; }
        public ICommand DeleteButton { get; private set; }

        public ManagerType_Controller(Action<object>[] ListAction)
        {
            AddButton = new DelegateCommand(ListAction[0]);
            UpdateButton = new DelegateCommand(ListAction[1]);
            DeleteButton = new DelegateCommand(ListAction[2]);
        }
    }
}
