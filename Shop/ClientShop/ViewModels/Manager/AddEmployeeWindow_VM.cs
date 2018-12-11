using ClientShop.Models;
using ClientShop.Models.Controller;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ClientShop.ViewModels.Manager
{
    public class AddEmployeeWindow_VM
    {
        public EditorEmployeeWindow_Controller Controller { get; set; }
        public Action<Employee> AddEmployeeMet { get; set; }
        private Employee MyEmployee { get; set; }
        private byte[] ArrayBytes { get; set; }

        public AddEmployeeWindow_VM(Action<Employee> addEmployeeMet)
        {
            MyEmployee = new Employee();
            AddEmployeeMet = addEmployeeMet;
            Controller = new EditorEmployeeWindow_Controller(new Action<object>[] { Add, null, Close, ChangeImage });
        }

        private void Close(object obj)
        {
            ((Window)obj).Close();
        }

        private async void Add(object obj)
        {
            var canUpdate = await CanUpdate();
            if (canUpdate)
            {
                MyEmployee.Login = Controller.Login;
                MyEmployee.Password = Controller.Password;
                MyEmployee.Phone = Controller.Phone;
                MyEmployee.Surname = Controller.Surname;
                MyEmployee.Name = Controller.Name;
                MyEmployee.Type = Controller.SelectTypeUser;
                MyEmployee.Image = ArrayBytes;

                string command = $"INSERT INTO user(surname, name, login, password, id_type_user, id_shop, phone, image) "
                               + $" VALUES ('{Controller.Surname}', "
                               + $"'{Controller.Name}', "
                               + $"'{Controller.Login}', "
                               + $"'{Controller.Password}', "
                               + $"(SELECT DISTINCT id FROM type_user WHERE name = '{MyEmployee.Type}'), "
                               + $"'{User.Man.IDShop}', "
                               + $"'{Controller.Phone}', "
                               + $"@Content)";
                Database.InsertDataAndImage(command, ArrayBytes);

                AddEmployeeMet(MyEmployee);
                ((Window)obj).Close();
            }
        }

        private async Task<bool> CanUpdate()
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
                if ((Controller.Surname == null)
                || (Controller.Surname.Length < 1))
                {
                    listSS += "Ви не ввели прізвище\n";
                    return false;
                }
                return true;
            });

            right = await Task.Factory.StartNew(() =>
            {
                if ((Controller.Name == null)
                || (Controller.Name.Length < 1))
                {
                    listSS += "Ви не ввели ім`я\n";
                    return false;
                }
                return true;
            });

            right = await Task.Factory.StartNew(() =>
            {
                if ((Controller.Phone != null)
                && (Controller.Phone.Length == 4))
                {
                    var sa = Controller.Phone;
                    for (int i = 0; i < sa.Length; ++i)
                    {
                        if (!((sa[i] >= '0') && (sa[i] <= '9')))
                        {
                            listSS += "Номер мобільного може містити символи (0-9)\n";
                            return false;
                        }
                    }
                }
                else
                {
                    listSS += "Номер мобільного має складатись з 10 символів (0-9)\n";
                    return false;
                }
                return true;
            });

            right = await Task.Factory.StartNew(() =>
            {
                if (ArrayBytes == null)
                {
                    listSS += "Вставте картинку\n";
                    return false;
                }
                return true;
            });

            if (!right)
            {
                MessageBox.Show(listSS);
            }

            return right;
        }

        private void ChangeImage(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ".png |* .jpg";

            if (openFileDialog.ShowDialog() == true)
            {
                TransformImageInArrayBytes(openFileDialog.FileName);
                Controller.Picture = LoadImage(ArrayBytes);
            }
        }

        private void TransformImageInArrayBytes(string way)
        {
            using (FileStream file = new FileStream(way, FileMode.Open))
            {
                ArrayBytes = new byte[file.Length];
                file.Read(ArrayBytes, 0, ArrayBytes.Length);
            }
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