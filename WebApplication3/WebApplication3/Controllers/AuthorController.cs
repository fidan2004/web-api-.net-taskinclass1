using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private static List<Author> _authors = new List<Author>();

        [HttpGet("author/get")]
        public List<Author> GetAll()
        {
            return _authors;
        }

        [HttpPost("author/create")]
        public IActionResult CreateAuthor(Author author)
        {
            if (author.Id == null)
            {
                return NotFound();
            }
            else
            {
                _authors.Add(author);
                return Created($"api/Author/{author.Id}", author);
            }
        }
        [HttpPost("author/book/create")]

        public IActionResult AddBook(int Authorid, Book book)
        {
            Author Searchauthor = _authors.FirstOrDefault(m => m.Id == Authorid);
            if (Searchauthor == null)
            {
                return NotFound();
            }
            else
            {
                Searchauthor.books.Add(book);
                return Ok(book);
                // return Created($"api/Createdbooks/{Searchauthor.Id}", Searchauthor);
            }

        }
        [HttpGet("author/book/{id}")]
        public IActionResult SearchAuthorByBookName(string BookName) 
        
        {
            foreach (Author author in _authors)
            {
                if (author.books.FirstOrDefault(m => m.Name == BookName) != null)
                {
                    return Ok(author);
                }
            }
                return NotFound("not founddd");
            }

    }
}
