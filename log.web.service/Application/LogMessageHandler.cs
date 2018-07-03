namespace Log.Web.Service.Application
{
    using System;
    using Log.Web.Contracts;
    using NLog.Targets;
    using Serilog.Events;

    public interface ILogMessageHandler
    {
        void Log(LogRequest e);

        event EventHandler<LogRequest> LogItemReceived;
    }

    public class LogMessageHandler : ILogMessageHandler
    {
        public LogMessageHandler() { }

        public virtual void Log(LogRequest e)
        {

            if (LogItemReceived != null)
            {
                LogItemReceived(this, e);
            }
        }

        public event EventHandler<LogRequest> LogItemReceived;
    }
}
