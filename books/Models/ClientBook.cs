using books.Models;
using System.ComponentModel.DataAnnotations;

namespace books.Models
{
    public class ClientBook
    {
        [Key] public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}

