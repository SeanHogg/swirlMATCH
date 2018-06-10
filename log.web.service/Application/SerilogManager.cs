namespace Log.Web.Service.Application
{
    using Serilog;
    using Serilog.Events;

    public class SerilogManager : CustomLogManager
    {
        public override void LogMessage(object sender, Message message)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .CreateLogger();
        }
    }
}