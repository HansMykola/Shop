using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Shop
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceShop" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(ICallBackUpdate))]
    public interface IServiceShop
    {
        [OperationContract]
        int Connect(string nameShop);

        [OperationContract]
        bool IsElements(string textCommand);

        [OperationContract(IsOneWay = true)]
        void UpdateAllDate(string name);

        [OperationContract(IsOneWay = true)]
        void SaveData(string textCommand);

        [OperationContract(IsOneWay = true)]
        void SaveDataImage(string textCommand, byte[] image);

        [OperationContract]
        object[] GetListData(string textCommand);

        [OperationContract]
        List<List<object>> GetListChooseElem(string textCommand, short number);

        [OperationContract]
        List<byte[]> GetImageBytes(string comandSql);
    }

    public interface ICallBackUpdate
    {
        [OperationContract(IsOneWay = true)]
        void CallBackUpdate();
    }
}
