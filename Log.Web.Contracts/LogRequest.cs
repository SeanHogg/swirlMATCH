namespace Log.Web.Contracts
{
    using Microsoft.Extensions.Logging;
    using System;

    public enum LogType { Message, Error }

    public class LogRequest
    {
        public LogRequest(LogLevel level, LogType logType, string tenantId, int id, string message, Exception ex = null)
        {
            this.Id = id; this.TenantId = tenantId; this.Message = message; this.Exception = ex; this.Level = level; this.LogType = LogType;
        }

        public string TenantId { get; }
        public int Id { get; set; }
        public string Message { get; }
        public Exception Exception { get; }
        public LogLevel Level { get; }
        public LogType LogType { get; }
    }
}
