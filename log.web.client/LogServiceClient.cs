using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace Log.Web.Client
{
    public static class LogServiceClientLoggerExtensions
    {
        public static ILoggingBuilder AddLogServiceClient(this ILoggingBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerProvider, LogServiceClientProvider>();
            return builder;
        }
    }

    public interface ILogServiceClient: ILogger
    {
        string TenantId { get; }

        string EndPoint { get; }
    }

    public class LogServiceClientLogger : ILogServiceClient
    {
        public string TenantId { get; }

        public string EndPoint { get; }

        public LogServiceClientLogger(string tenantId, string endpoint)
        {
            this.TenantId = tenantId;
            this.EndPoint = endpoint;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //Call the Endpoint with the message

            //throw new NotImplementedException();
        }
    }

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

            return _loggers.GetOrAdd(categoryName, name => new LogServiceClientLogger(endpoint, tenantId));
        }

        public void Dispose()
        {
            this._loggers.Clear();
        }
    }
}
