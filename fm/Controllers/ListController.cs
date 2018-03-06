using System;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using fm.Providers;
using fm.Model;

namespace fm.Controllers
{
    [Route("[controller]")]
    public class ListController : Controller
    {
        public String rootPath;

        public ListController(string path = @"C:/") {
            rootPath = path;
        }

        private FI RemovePrefix(FI fi)
        {
            fi.PhysicalPath = fi.PhysicalPath.Remove(0, rootPath.Length - 1);
            return fi;
        }

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
            catch (UnauthorizedAccessException)
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
        [HttpDelete("{*id}")]
        public IActionResult Delete(String id)
        {
            try
            {
                FileSystemProvider.DeleteFI(id);
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (IOException) {
                return BadRequest();
            }
            return Ok();
        }
    }
}
