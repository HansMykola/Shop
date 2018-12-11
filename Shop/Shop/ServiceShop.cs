using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceShop" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceShop : IServiceShop
    {
        private int IdUser { get; set; } = 1;
        private List<User> Users { get; set; } = new List<User>();
        private string connStrss = "server=127.0.0.1;user=root;database=shop;password=;SslMode=none;";

        public int Connect(string nameShop)
        {
            Users.Add(new User(IdUser, nameShop) {
                MyOperationContext = OperationContext.Current
            });

            ++IdUser;

            return IdUser;
        }

        public void UpdateAllDate(string name)
        {
            var elements = Users.FindAll(x => x.NameShop == name);

            foreach(var elem in elements)
            {
                elem.MyOperationContext.GetCallbackChannel<ICallBackUpdate>().CallBackUpdate();
            }
        }

        //---------SQL-----------------------------

        // INSERT AND UPDATE
        public void SaveData(string textCommand)
        {
            using (MySqlConnection mySqlConnect = new MySqlConnection(connStrss))
            {
                mySqlConnect.Open();
                MySqlCommand command = new MySqlCommand(textCommand, mySqlConnect);
                command.ExecuteNonQuery();
            }
        }

        // INSERT AND UPDATE WITH IMAGE
        public void SaveDataImage(string textCommand, byte[] image)
        {
            using (MySqlConnection mySqlConnect = new MySqlConnection(connStrss))
            {
                mySqlConnect.Open();
                MySqlCommand command = new MySqlCommand(textCommand, mySqlConnect);
                command.Parameters.Add(new MySqlParameter("@Content", MySqlDbType.MediumBlob, 0));
                command.Parameters["@Content"].Value = image;
                command.ExecuteNonQuery();
            }
        }

        // SELECT A ELEMENT
        public object[] GetListData(string textCommand)
        {
            List<object> list = new List<object>();

            using (MySqlConnection mySqlConnect = new MySqlConnection(connStrss))
            {
                mySqlConnect.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(textCommand, mySqlConnect);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                
                while (reader.Read())
                {
                    list.Add(reader[0]);
                }

                reader.Close();
            }

            return list.ToArray();
        }

        // SELECT ELEMENTS
        public List<List<object>> GetListChooseElem(string textCommand, short number)
        {
            List<List<object>> list;
            using (MySqlConnection mySqlConnect = new MySqlConnection(connStrss))
            {
                mySqlConnect.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(textCommand, mySqlConnect);
                list = ReadReader(mySqlCommand, number).Result;
            }
            return list;
        }

        private async Task<List<List<object>>> ReadReader(MySqlCommand mySqlCommand, short number)
        {
            return await Task.Factory.StartNew(() => {
                List<List<object>> list = new List<List<object>>();

                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                for (int i = 0; i < number; ++i)
                {
                    list.Add(new List<object>());
                }

                while (reader.Read())
                {
                    for (int i = 0; i < number; i++)
                    {
                        list[i].Add(reader[i]);
                    }
                }
                reader.Close();

                return list;
            }); 
        }

        // SELECT Image
        public List<byte[]> GetImageBytes(string comandSql)
        {
            List<byte[]> ImageArrayBytes = new List<byte[]>();

            MySqlConnection mySqlConnect = new MySqlConnection(connStrss);
            mySqlConnect.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(comandSql, mySqlConnect);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();


            while (reader.Read())
            {
                ImageArrayBytes.Add((byte[])reader[0]);
            }

            reader.Close();

            return ImageArrayBytes;
        }

        public bool IsElements(string textCommand)
        {
            bool isElem = false;
            using (MySqlConnection mySqlConnect = new MySqlConnection(connStrss))
            {
                mySqlConnect.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(textCommand, mySqlConnect);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
            }

            return isElem;
        }
    }
}
