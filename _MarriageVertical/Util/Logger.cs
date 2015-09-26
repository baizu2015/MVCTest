[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace _MarriageVertical.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    /// <summary>
    /// App   error
    /// </summary>
    public enum AppError
    {
        /// <summary>
        /// warning status
        /// </summary>
        WARN = 0,

        /// <summary>
        /// error satus
        /// </summary>
        EROR = 1,

        /// <summary>
        /// fatl satus
        /// </summary>
        FATL = 2,

        /// <summary>
        /// info satus
        /// </summary>
        INFO = 3
    }

    /// <summary>

    /// </summary>
    public class Logger
    {
        /// <summary>
        /// log    info
        /// </summary>
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("TrendMicro.Darslog.Logging.Info");

        /// <summary>
        /// log    lebug
        /// </summary>
        private static readonly log4net.ILog logdebug = log4net.LogManager.GetLogger("TrendMicro.Darslog.Logging.Debug");

        /// <summary>
        /// log   error
        /// </summary>
        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("TrendMicro.Darslog.Logging.Error");

        /// <summary>
        /// Info level log function
        /// </summary>
        /// <param name="codeInfo">code info</param>
        /// <param name="userName">userName</param>
        /// <param name="message">message</param>
        public static void LogInfo(string codeInfo, string userName, string message)
        {
            if (loginfo.IsInfoEnabled)
            {
                string logMessage = string.Format("[Info]Code information:" + codeInfo + " ;current user:" + userName + " ;Content:" + message);
                loginfo.Info(logMessage);
            }

        }

        /// <summary>
        /// Debug level log function
        /// </summary>
        /// <param name="codeInfo">code info</param>
        /// <param name="userName">userName</param>
        /// <param name="message">message</param>
        public static void LogDebug(string codeInfo, string userName, string message)
        {
            if (logdebug.IsDebugEnabled)
            {
                string logMessage = string.Format("[Debug]Code information:" + codeInfo + " ;current user:" + userName + " ;Content:" + message);
                logdebug.Debug(logMessage);
            }

        }

        /// <summary>
        /// Error level log function
        /// </summary>
        /// <param name="codeInfo">code info</param>
        /// <param name="userName">userName</param>
        /// <param name="message">message</param>
        public static void LogError(string codeInfo, string userName, string message, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                string logMessage = string.Format("[Error]Code information:" + codeInfo + " ;current user:" + userName + " ;Content:" + message + " ;Exception message:" + (ex == null ? "" : ex.Message.ToString()) + " ;StackTrace:" + (ex == null ? "" : ex.StackTrace));
                logerror.Error(logMessage);
            }
        }
    }
}