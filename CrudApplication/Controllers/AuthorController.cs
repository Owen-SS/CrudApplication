using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorDbContext _authorDbContext;

        public AuthorController(AuthorDbContext authorDbContext)
        {
            _authorDbContext = authorDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors() 
        {
            if(_authorDbContext.Authors == null)
            {
                return NotFound();
            }
            return _authorDbContext.Authors.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var author = _authorDbContext.Authors.Find(id);
            if(author == null)
            {
                return NotFound();
            }
            return author;
        }

        [HttpPost]
        public ActionResult<Author> CreateAuthor (Author author)
        {
            if(author == null)
            {
                return BadRequest();
            }
            _authorDbContext.Authors.Add(author);
            _authorDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetAuthor), new {id = author.Id}, author);
        }

        [HttpDelete]
        public ActionResult DeleteAuthor(int id)
        {
            var author = _authorDbContext.Authors.Find(id);
            if(author == null)
            {
                return NotFound();
            }
            _authorDbContext.Authors.Remove(author);
            _authorDbContext.SaveChanges();
            return Ok(author);
        }

    }
}
