using log4net;
using System;


#nullable enable
namespace InvestSupTool.Util
{
    internal class LogUtil
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(LogUtil));

        public static void Debug(string message) => LogUtil._log.Debug((object)message);

        public static void Info(string message) => LogUtil._log.Info((object)message);

        public static void Warn(string message) => LogUtil._log.Warn((object)message);

        public static void Error(string message, Exception ex = null)
        {
            if (ex != null)
                LogUtil._log.Error((object)message, ex);
            else
                LogUtil._log.Error((object)message);
        }
    }
}
