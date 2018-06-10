using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Log.Web.Service.Application;
using Microsoft.AspNetCore.Mvc;

namespace log.web.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogMessageHandler handler;
        public ValuesController(ILogMessageHandler handler){
            this.handler = handler;
        }
  
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            // LogMessageHandler handler = LogMessageHandler.CreateInstance();
            handler.LogMessage(new Message(){ TenantId = "Nlog" });
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
