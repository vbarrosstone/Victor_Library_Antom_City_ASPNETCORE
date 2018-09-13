using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Victor_Library_Antom_City_ASPNETCORE.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Victor_Library_Antom_City_ASPNETCORE.Controllers
{
    [Route("[controller]")]
    public class PublishersController : Controller
    {
        //Consult all already posted.
        // GET: /<controller>
        [HttpGet]
        [Route("Get")]
        public List<PublishingCompany> Get()
        {
            return Repository.Publishers;
        }
        //Post news to repository.
        // POST /<controller>
        [HttpPost]
        [Route("Post")]
        public void Post([FromBody]PublishingCompany publishingCompany)
        {
            Repository.PostPublishingCompanyToRepository(publishingCompany);
        }
        //Update datas already posted in all repositories.
        // PUT /<controller>/5
        [HttpPut("{id}")]
        [Route("Put/{id}")]
        public void Put(int id, [FromBody] PublishingCompany publishingCompany)
        {
            Repository.Publishers[id - 1].Name = publishingCompany.Name;
        }
    }
}
