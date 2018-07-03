namespace Log.Web.Service.Application
{
    using Log.Web.Contracts;
    using Serilog;
    using Serilog.Events;

    public class SerilogManager : CustomLogManager
    {
        public override void Log(object sender, LogRequest message)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .CreateLogger();

            switch (message.Level)
            {

                case Microsoft.Extensions.Logging.LogLevel.Critical:
                    Serilog.Log.Logger.Fatal(message.Message, message);
                    break;
            }
        }
    }
}