using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using HostService.Services;

namespace SY.Client
{
    class ServerProxy
    {
        public static string IP = "localhost";
        public static string PORT = "6666";
        public static IArchivesService channelProxy = null;
        public static IArchivesService GetProxy()
        {
            try
            {
                channelProxy.ColumnExist("");
            }
            catch
            {
                EndpointAddress address = new EndpointAddress("net.tcp://" + IP + ":" + PORT + "/Archives");
                NetTcpBinding binding = new NetTcpBinding();
                binding.Security.Mode = SecurityMode.None;
                ChannelFactory<IArchivesService> factory = new ChannelFactory<IArchivesService>(binding, address);
                channelProxy = factory.CreateChannel();
            }
            return channelProxy;
        }
        public static bool CheckConnect()
        {
            try
            {
                EndpointAddress address = new EndpointAddress("net.tcp://" + IP + ":" + PORT + "/Archives");
                NetTcpBinding binding = new NetTcpBinding();
                binding.Security.Mode = SecurityMode.None;
                ChannelFactory<IArchivesService> factory = new ChannelFactory<IArchivesService>(binding, address);
                channelProxy = factory.CreateChannel();
                channelProxy.ColumnExist("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
