namespace Log.Web.Service.Application
{
    using System;
    using System.Collections.Concurrent;
    using NLog;
    using NLog.Config;
    using NLog.Targets;

    public class NLogManager : CustomLogManager
    {
        public NLogManager()
        {
            this._loggers = new ConcurrentDictionary<string, Logger>();
        }
        private ConcurrentDictionary<string, Logger> _loggers;
        public override void LogMessage(Object sender, Message message)
        {
            var instanceName = message.TenantId;
            Logger logger = null;
            if (!_loggers.ContainsKey(instanceName))
            {
                var target = new FileTarget();
                target.Name = instanceName;
                target.FileName = "c:/temp/${instanceName}/${shortdate}.log";
                target.Layout = "${date:format=HH\\:MM\\:ss} ${logger} ${message}";

                var config = new LoggingConfiguration();
                config.AddTarget(instanceName, target);

                var rule = new LoggingRule("*", LogLevel.Info, target);
                config.LoggingRules.Add(rule);

                LogManager.Configuration = config;

                logger = _loggers.GetOrAdd(instanceName, LogManager.GetLogger(instanceName));
            }
            else
                logger = _loggers.GetOrAdd(instanceName, LogManager.GetLogger(instanceName));
            logger.Log(LogLevel.Info, message);
        }
    }
}