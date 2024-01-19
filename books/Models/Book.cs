
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace books.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        // Foreign key for Category
        public int CategoryId { get; set; }

        // Navigation property for Category
        public Categorie Category { get; set; }

        // Foreign key for Author
        public int AuthorId { get; set; }

        // Navigation property for Author
        public Author Author { get; set; }

        // Navigation property for borrow relationships
        public ICollection<ClientBook> ClientBooks { get; set; }
    }
}

