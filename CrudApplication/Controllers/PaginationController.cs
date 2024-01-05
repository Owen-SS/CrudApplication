using CrudApplication.Pagination;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudApplication.Services;
using CrudApplication.Controllers.Helpers;

namespace CrudApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaginationController : ControllerBase
    {
        private readonly AuthorDbContext _authorDbContext;
        private readonly IUriService _uriService;

        public PaginationController(AuthorDbContext authorDbContext, IUriService uriService)
        {
            _authorDbContext = authorDbContext;
            _uriService = uriService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorDbContext.Authors.Where( a => a.Id == id ).FirstOrDefaultAsync();
            if(author == null)
            {
                return NotFound();
            }
            return Ok(new Response<Author>(author));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuthors([FromQuery] PaginationFilter filter)
        {
            //var route = Request.Path.Value;
            var pagedData = await _authorDbContext.Authors
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            //var totalRecords = await _authorDbContext.Authors.CountAsync();
            //var pagedResponse = PaginationHelper.CreatePagedReponse<Author>(pagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedData);
        }
    }
}
