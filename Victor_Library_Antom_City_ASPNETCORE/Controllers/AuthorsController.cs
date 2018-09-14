using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Victor_Library_Antom_City_ASPNETCORE.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Victor_Library_Antom_City_ASPNETCORE.Controllers
{
    [Route("[controller]")]
    public class AuthorsController : Controller
    {
        //Consult all already posted.
        // GET: /<controller>
        //[HttpGet]
        [Route("Get")]
        public List<Author> Get()
        {
            return Repository.Authors;
        }
        //Post news to repository.
        // POST /<controller>
        //[HttpPost]
        [Route("Post")]
        public void Post([FromBody]Author author)
        {
            Repository.Insert(author, Repository.Authors);
        }
        //Update datas already posted in all repositories.
        // PUT /<controller>/5
        //[HttpPut("{id}")]
        [Route("Put/{id}")]
        public void Put(int id, [FromBody] Author author)
        {
            Repository.Update(id, author);
        }
    }
}
