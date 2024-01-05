using CrudApplication.Pagination;

namespace CrudApplication.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
