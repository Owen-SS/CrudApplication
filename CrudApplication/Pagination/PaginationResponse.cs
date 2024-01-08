using CrudApplication.Models;

namespace CrudApplication.Pagination
{
    public class PaginationResponse
    {
        public int? TotalPages { get; set; }
        public int? TotalCards { get; set; }

        public List<Author>? Authors { get; set; }
    }
}
