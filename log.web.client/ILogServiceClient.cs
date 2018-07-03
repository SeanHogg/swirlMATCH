using Microsoft.Extensions.Logging;

namespace Log.Web.Client
{
    public interface ILogServiceClient: ILogger
    {
        string TenantId { get; }

        string EndPoint { get; }
    }
}
