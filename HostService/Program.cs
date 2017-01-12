using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace HostService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "档案服务端程序";
            ServiceHost host = new ServiceHost(typeof(HostService.Services.ArchivesService));
            host.Opened += delegate
            {
                Console.WriteLine("档案服务端程序已开启");
            };
            host.Open();
            Console.ReadLine();
        }
    }
}
