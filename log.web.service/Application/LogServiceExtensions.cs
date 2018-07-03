namespace Log.Web.Service.Application
{
    using Microsoft.Extensions.DependencyInjection;
    public static  class LogServiceExtensions{

    public static void AddLogServiceHandlers(this IServiceCollection serviceCollection)
    {
        //LogMessageHandler handler = LogMessageHandler.CreateInstance();
        var services = serviceCollection.BuildServiceProvider();
        var handler = services.GetService<ILogMessageHandler>();
        NLogManager manager = new  NLogManager();
        SerilogManager sManager = new   SerilogManager();
        handler.LogItemReceived += sManager.Log;
        handler.LogItemReceived += manager.Log;
    }
}
}