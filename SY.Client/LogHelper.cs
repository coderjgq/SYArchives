using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace SY.Client
{
    class LogHelper
    {
        private ILog logger; 

        public LogHelper(Type type)
        {
            SetConfig();
            logger = LogManager.GetLogger(type);
        }

        private static void SetConfig()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("Log4net.xml"));
        }

        public void Warn(string msg)
        {
            logger.Warn(msg);
        }

        public void Debug(string msg)
        {
            logger.Debug(msg);
        }

        public void Error(string msg)
        {
            logger.Error(msg);
        }

        public void Info(string msg)
        {
            logger.Info(msg);
        }

        public void Error(string msg,Exception ex)
        {
            logger.Error(msg,ex);
        }

        public void Debug(string msg, Exception ex)
        {
            logger.Debug(msg, ex);
        }

        public void Warn(string msg, Exception ex)
        {
            logger.Warn(msg, ex);
        }

        public void Info(string msg, Exception ex)
        {
            logger.Info(msg, ex);
        }



    }
}
