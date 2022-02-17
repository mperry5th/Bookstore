using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.ViewModels
{
    public class BooksViewModel
    {
        public IEnumerable<Books> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
