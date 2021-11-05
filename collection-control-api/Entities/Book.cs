using collection_control_api.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Entities
{
    public class Book : Item
    {
        public Book() { }

        public Book(string title, string author, int pagesNumber)
        {
            Title = title;
            AddAuthor(author);
            AddPagesNumber(pagesNumber);
        }

        public string Author { get; private set; }
        public int PagesNumber { get; private set; }

        public void AddAuthor(string author)
        {
            Author = author;
        }
        public void AddPagesNumber(int pagesNumber)
        {
            PagesNumber = pagesNumber;
        }

        //public bool TitleIsValid(string title)
        //{
        //    if (string.IsNullOrEmpty(title) || title.Length > 255) 
        //        return false;
        //
        //    return true;
        //}
        //
        //private bool AuthorIsValid(string author)
        //{
        //    if (string.IsNullOrEmpty(author) || author.Length > 255 || author.Length < 3)
        //        return false;
        //
        //    return true;
        //}
        //
        //private bool PagesNumberIsValid(int pagesNumber)
        //{
        //    if (pagesNumber < 50)
        //        return false;
        //
        //    return true;
        //}
    }
}
