using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using fm.Providers;
using fm.Model;


namespace fm.Controllers
{
    [Route("[controller]")]
    public class ListController : Controller
    {
        [HttpGet("{*id}")]
        public FI[] Get(String id)
        {
            return FileSystemProvider.GetFIs(id).ToArray();
        }
        
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
