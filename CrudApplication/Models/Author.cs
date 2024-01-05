using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApplication.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string? Email { get; set; }
        public string? Quotes { get; set; }
    }
}
