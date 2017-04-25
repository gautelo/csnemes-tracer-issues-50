using System.Collections.Generic;
using System.Web.Http;
using Microsoft.Extensions.Logging;

namespace LogWeb5.Controllers
{
    public class SomeController : ApiController
    {
        private readonly ISomethingSvc _somethingSvc;
        private readonly ILogger<SomeController> _logger;

        public SomeController(ISomethingSvc somethingSvc, ILogger<SomeController> logger)
        {
            _somethingSvc = somethingSvc;
            _logger = logger;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {

            using (_logger.BeginScope("Get"))
            {
                _logger.LogTrace("Some asked to get it!");

                _somethingSvc.DoSomething();

                return new[] {"value1", "value2"};
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}