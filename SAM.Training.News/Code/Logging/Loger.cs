using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using log4net;
using log4net.Config;
namespace SAM.Training.News.Code.Logging
{
    public class Loger{      
        
        public  static void LogException<T>(string e, String message) {
            ILog logger = LogManager.GetLogger(typeof(T));
            logger.Error(String.Format("Exception: {0}, \n Client message: {1}", e, message));
        }       
        internal static void LogException<T>(string e, string message, Uri url, string userAgent)
        {
            ILog logger = LogManager.GetLogger(typeof(T));
            logger.Error(String.Format("Exception: {0} \n Client message: {1}, url: {2}, \n userAgent: {3}", e, message, url, userAgent));
        }
    }
}