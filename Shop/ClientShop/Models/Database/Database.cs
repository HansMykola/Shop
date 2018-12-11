using ClientShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientShop.Models
{
    public class Database
    {
        private static object[][] Elements { get; set; }
        private static ServiceShopClient Client = MyServiceClient.myServiceClient.Client;

        public static void SelectParams(string ss, short legth)
        {
            if (Client.IsElements(ss))
            {
                Elements = Client.GetListChooseElem(ss, legth); 
            }
            else
            {
                Elements = null;
            }
        }

        public static bool IsElem(string command)
        {
            return Client.IsElements(command);
        }

        public static List<T> GetElementParams<T>(int index)
        {
            if (Elements == null)
            {
                return new List<T>();
            }
            else
            {
                return Array.ConvertAll(Elements[index], x => (T)x).ToList();
            }
        }

        public static List<T> GetAElementSelect<T>(string ss)
        {
            if (Client.IsElements(ss))
            {
                var h = Client.GetListData(ss);
                return Array.ConvertAll(h, x => (T)x).ToList(); 
            }
            else
            {
                return new List<T>();
            }
        }

        public static List<byte[]> GetArrayBytesImage(string command)
        {
            return Client.GetImageBytes(command).ToList();
        }

        public static void InsertData(string command)
        {
            Client.SaveData(command);
        }

        public static void InsertDataAndImage(string command, byte[] image)
        {
            Client.SaveDataImage(command, image);
        }

        public static void UpdateData(string command)
        {
            Client.SaveData(command);
        }

        public static void UpdateDataAndImage(string command, byte[] image)
        {
            Client.SaveDataImage(command, image);
        }

        public static void DeleteData(string command)
        {
            Client.SaveData(command);
        }
    }
}
