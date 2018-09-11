using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Victor_Library_Antom_City_ASPNETCORE.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Victor_Library_Antom_City_ASPNETCORE.Controllers
{
    [Route("[controller]")]
    public class BooksController : Controller
    {
        // GET: /<controller>
        [HttpGet]
        [Route("Get")]
        public List<Book> Get()
        {
            return Repository.Books;
        }

        // GET: /<controller>/GetByAuthor/name
        [HttpGet]
        [Route("GetByAuthor/{id}")]
        public List<Book> GetByAuthor(string id)
        {
            string name = id;
            return Repository.GetBooksByAuthorName(name);
        }

        // GET: /<controller>/GetByPublishingCompany/name
        [HttpGet]
        [Route("GetByPublishingCompany/{id}")]
        public List<Book> GetByPublishingCompany(string id)
        {
            string name = id;
            return Repository.GetBooksByPublisherName(name);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("Post")]
        public void Post([FromBody]Book book)
        {
            Repository.PostBookToRepository(book);
        }

        // PUT /<controller>/5
        [HttpPut("{id}")]
        [Route("Put/{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            Repository.Books[id - 1].Title = book.Title;
            Repository.Authors[id - 1].Name = book.author.Name;
            Repository.Publishers[id - 1].Name = book.publishingCompany.Name;
        }
    }
}
