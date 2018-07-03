namespace Log.Web.Service.Application
{
    using Log.Web.Contracts;
    using System;

    public interface ICustomLogManager
    {
        void Log(object sender, LogRequest message);
    }

    public abstract class CustomLogManager: ICustomLogManager
    {
        public abstract void Log(object sender, LogRequest message);
    }
}
