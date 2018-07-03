using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Log.Web.Client
{
    public class LogServiceClientProvider : ILoggerProvider
    {
        private readonly IConfiguration configuration;
        private readonly ConcurrentDictionary<string, LogServiceClientLogger> _loggers = new ConcurrentDictionary<string, LogServiceClientLogger>();

        public LogServiceClientProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ILogger CreateLogger(string categoryName)
        {
            //Read the Configuration and get the values 
            var endpoint = configuration["Endpoints:Logging"];
            var tenantId = configuration["TenantId"];

            return _loggers.GetOrAdd(categoryName, name => new LogServiceClientLogger(tenantId, endpoint));
        }

        public void Dispose()
        {
            this._loggers.Clear();
        }
    }
}
