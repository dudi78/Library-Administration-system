using books.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace books.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        // Navigation property for books written by this author
        public ICollection<Book> Books { get; set; }
    }
}
