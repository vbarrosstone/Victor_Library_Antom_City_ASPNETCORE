using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Victor_Library_Antom_City_ASPNETCORE.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Victor_Library_Antom_City_ASPNETCORE.Controllers
{
    [Route("[controller]")]
    public class AuthorsController : Controller
    {
        // GET: /<controller>
        [HttpGet]
        [Route("Get")]
        public List<Author> Get()
        {
            return Repository.Authors;
        }

        // POST /<controller>
        [HttpPost]
        [Route("Post")]
        public void Post([FromBody]Author author)
        {
            Repository.PostAuthorToRepository(author);
        }

        // PUT /<controller>/5
        [HttpPut("{id}")]
        [Route("Put/{id}")]
        public void Put(int id, [FromBody] Author author)
        {
            Repository.Authors[id - 1].Name = author.Name;
        }
    }
}
