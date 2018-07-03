namespace Log.Web.Client
{
    using Log.Web.Contracts;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Text;

    public class LogServiceClientLogger : ILogServiceClient
    {
        private static readonly HttpClient client = new HttpClient();

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
            string result = formatter(state, exception);

            LogType logType = LogType.Message;
            if (exception != null)
            {
                logType = LogType.Error;
                result = result + exception.ToString();
            }

            var versionOneLogEndpoint = $"{this.EndPoint}/api/v1/Log";

            LogRequest request = new LogRequest(logLevel, logType, TenantId, eventId.Id, result, exception);
            var logResult = client.PostAsync(versionOneLogEndpoint, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
        }
    }
}
