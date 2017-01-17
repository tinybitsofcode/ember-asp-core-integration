using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ember_asp_test.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Profiles")]
    public class ProfilesController : Controller
    {
        // GET: api/Profiles
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Profiles/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Profiles
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Profiles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
