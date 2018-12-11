using ClientShop.Models;
using ClientShop.Models.Controller;
using ClientShop.Views.ManagerEmployee;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ClientShop.ViewModels.Manager
{
    public class PageUser_VM : NotifyPropertyChanged
    {
        private Employee mEmployee { get; set; }
        private Action<Employee> Layoffs { get; set; }

        public PageUser_Controller Controller { get; private set; }

        public int ID { get; set; }


        public PageUser_VM(Action<Employee> layoffs, Employee employee)
        {
            Controller = new PageUser_Controller(UpdateEmployee);

            Layoffs = layoffs;
            UpdateThisPage(employee);
        }

        private void UpdateEmployee(object obj)
        {
            EditorEmployeeWindow window = new EditorEmployeeWindow();
            window.DataContext = new EditorEmployeeWindow_VM(Layoffs, UpdateThisPage, mEmployee);
            window.ShowDialog();
        }

        private void UpdateThisPage(Employee employee)
        {
            ID = employee.ID;
            mEmployee = employee;
            Controller.Type = mEmployee.Type;
            Controller.FullName = mEmployee.Surname + " " + mEmployee.Name;
            Controller.Phone = mEmployee.Phone;
            Controller.Picture = LoadImage(mEmployee.Image);
        }

        private BitmapImage LoadImage(byte[] imageData)
        {
            if ((imageData == null) || (imageData.Length == 0))
            {
                return null;
            }

            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }

            image.Freeze();
            return image;
        }
    }
}
