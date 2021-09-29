using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Entities
{
    public class Book : Item
    {
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
        public string Author { get; private set; }
        public int PagesNumber { get; private set; }
    }
}
