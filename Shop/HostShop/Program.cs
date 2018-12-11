using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HostShop
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Shop.ServiceShop)))
            {
                host.Open();
                Console.WriteLine("Хост запущений!");
                Console.ReadLine();
            }
        }
    }
}