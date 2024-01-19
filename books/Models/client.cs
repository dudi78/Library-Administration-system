using books.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace books.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        public string ClientName { get; set; }

        // Navigation property for borrow relationships
        public ICollection<ClientBook> ClientBooks { get; set; }
    }
}
