using ClientShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClientShop.Models
{
    public class MyServiceClient : IServiceShopCallback
    {
        public static MyServiceClient myServiceClient;
        public ServiceShopClient Client { get; private set; }

        public Action UdateData { get; set; }

        private MyServiceClient()
        {
            myServiceClient = this;
            Client = new ServiceShopClient(new System.ServiceModel.InstanceContext(this));
            
        }

        public static void Init()
        {
            if (myServiceClient == null)
            {
                new MyServiceClient();
            }
        }

        public void CallBackUpdate()
        {
            UdateData();
        }
    }
}
