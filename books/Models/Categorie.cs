using books.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace books.Models
{
    public class Categorie
    {
        [Key] 
        public int CategorieId { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation property for books in this category
        public ICollection<Book> Books { get; set; }
    }
}
