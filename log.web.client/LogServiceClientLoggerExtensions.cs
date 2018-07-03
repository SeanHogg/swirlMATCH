namespace Log.Web.Client
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;
    using System;

    public static class LogServiceClientLoggerExtensions
    {
        public static ILoggingBuilder AddLogServiceClient(this ILoggingBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerProvider, LogServiceClientProvider>(f =>
            {
                var config = f.GetService<IConfiguration>();
                var logger = new LogServiceClientProvider(config);
                return logger;
            });
            return builder;
        }
    }
}
