using CrudApplication.Pagination;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaginationController : ControllerBase
    {
        private readonly AuthorDbContext _authorDbContext;

        public PaginationController(AuthorDbContext authorDbContext)
        {
            _authorDbContext = authorDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuthors([FromQuery] PaginationFilter filter)
        {
            var data = await _authorDbContext.Authors.ToListAsync();
            var pagedData = data
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();
            return Ok(pagedData);
        }
    }
}
