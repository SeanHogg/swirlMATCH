namespace Log.Web.Service.Application
{
    using System;

    public interface ICustomLogManager
    {
        void LogMessage(Object sender, Message message);
    }

    public abstract class CustomLogManager: ICustomLogManager
    {
        public abstract void LogMessage(Object sender, Message message);
    }
}
