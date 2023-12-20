using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Modals
{
    
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int TokensAvailable { get; set; }

        // Navigation properties
        public ICollection<Book> BooksBorrowed { get; set; }
        public ICollection<Book> BooksLent { get; set; }
    }

}
