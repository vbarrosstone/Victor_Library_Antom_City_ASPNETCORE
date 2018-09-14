using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Victor_Library_Antom_City_ASPNETCORE.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Victor_Library_Antom_City_ASPNETCORE.Controllers
{
    [Route("[controller]")]
    public class BooksController : Controller
    {
        //Consult all already posted.
        // GET: /<controller>
        //[HttpGet]
        [Route("Get")]
        public List<Book> Get()
        {
            return Repository.Books;
        }

        //Route that bring the list of books written by the specific Author.
        // GET: /<controller>/GetByAuthor/name
        //[HttpGet]
        [Route("GetByAuthorName/{id}")]
        public List<Book> GetByAuthorName(string id)
        {
            string name = id;
            return Repository.GetBooksByAuthorName(name);
        }

        //Route that bring the list of books published by the specific company.
        // GET: /<controller>/GetByPublishingCompany/name
        //[HttpGet]
        [Route("GetByPublishingCompanyName/{id}")]
        public List<Book> GetByPublishingCompanyName(string id)
        {
            string name = id;
            return Repository.GetBooksByPublisherName(name);
        }

        //Post news to repository.
        // POST api/<controller>
        //[HttpPost]
        [Route("Post")]
        public void Post([FromBody]Book book)
        {
            Repository.InsertBook(book);
        }

        //Update datas already posted in all repositories.
        // PUT /<controller>/5
        //[HttpPut("{id}")]
        [Route("Put/{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            Repository.Books[id - 1].Title = book.Title;
            Repository.Authors[id - 1].Name = book.author.Name;
            Repository.Publishers[id - 1].Name = book.publishingCompany.Name;
        }
    }
}
