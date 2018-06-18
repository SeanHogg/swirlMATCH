namespace Log.Web.Service.Application
{
    using System;
    using System.Collections.Concurrent;
    using NLog;
    using NLog.Config;
    using NLog.Targets;

    public class NLogManager : CustomLogManager
    {
        private ConcurrentDictionary<string, Logger> _loggers;

        public NLogManager()
        {
            this._loggers = new ConcurrentDictionary<string, Logger>();
        }

        public override void LogMessage(Object sender, Message message)
        {
            var logger = Initialize(message.TenantId);
            logger.Log(LogLevel.Info, message);
        }

        private Logger Initialize(string instanceName)
        {
            var target = new FileTarget
            {
                Name = instanceName,
                FileName = "c:/temp/${instanceName}/${shortdate}.log",
                Layout = "${date:format=HH\\:MM\\:ss} ${logger} ${message}"
            };

            var config = new LoggingConfiguration();
            config.AddTarget(instanceName, target);

            var rule = new LoggingRule("*", LogLevel.Info, target);
            config.LoggingRules.Add(rule);

            //Have to initialize this everytime b/c it retains the last initialized configuration and we need to reset it.
            LogManager.Configuration = config;
            return _loggers.GetOrAdd(instanceName, LogManager.GetLogger(instanceName));

        }
    }
}