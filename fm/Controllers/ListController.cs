using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using fm.Providers;
using System.IO;

namespace fm.Controllers
{
    [Route("[controller]")]
    public class ListController : Controller
    {
        [HttpGet("{*id}")]
        public IActionResult Get(String id)
        {
            try
            {
                return Ok(FileSystemProvider.GetFIs(id).ToArray());
            }
            catch (DirectoryNotFoundException)
            {
                return NotFound();
            }
            catch (FileNotFoundException) {
                return NotFound();
            }
            catch (AccessViolationException)
            {
                return Forbid();
            }
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
