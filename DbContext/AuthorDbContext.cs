
using CrudApplication.Models;
using Microsoft.EntityFrameworkCore;

    public class AuthorDbContext : DbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
    }
