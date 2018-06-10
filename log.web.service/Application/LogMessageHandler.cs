namespace Log.Web.Service.Application
{
    using System;
    using NLog.Targets;
    using Serilog.Events;

    public interface ILogMessageHandler
    {
        void LogMessage(Message e);

        event EventHandler<Message> LogMessageRecieved;
    }

    public class LogMessageHandler : ILogMessageHandler
    {
        public LogMessageHandler() { }
        //        private static LogMessageHandler instance = null;

        // public static LogMessageHandler CreateInstance()
        // {
        //     return instance;
        // }
        // static LogMessageHandler()
        // {
        //     if (instance == null)
        //         instance = new LogMessageHandler();
        // }

        public virtual void LogMessage(Message e)
        {

            if (LogMessageRecieved != null)
            {
                LogMessageRecieved(this, e);
            }
        }

        public event EventHandler<Message> LogMessageRecieved;
    }
}
