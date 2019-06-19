using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace WebUI.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }

}