namespace Log.Web.Service.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Log.Web.Contracts;
    using Log.Web.Service.Application;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogMessageHandler handler;
        public LogController(ILogMessageHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public string Get()
        {
            handler.Log(new LogRequest(Microsoft.Extensions.Logging.LogLevel.Critical, LogType.Error, "Test", 1, ""));
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] LogRequest value)
        {
            handler.Log(value);
        }
    }
}
