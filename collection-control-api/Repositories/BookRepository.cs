using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly CollectionContext _colletionContext;
        public BookRepository(CollectionContext collectionContext)
        {
            _colletionContext = collectionContext;
        }

        public void Create(NewBookInputModel newBookInputModel)
        {
            var newBook = new Book(newBookInputModel.Title, newBookInputModel.Author)
            {
                Description = newBookInputModel.Description,
                ReleasedYear = newBookInputModel.ReleasedYear
            };

            _colletionContext.books.Add(newBook);

            _colletionContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _colletionContext.books
                .FirstOrDefault(b => b.Id == id);

            _colletionContext.books.Remove(book);

            _colletionContext.SaveChanges();
        }

        public Book GetById(int id)
        {
            var goted = _colletionContext.books
                .FirstOrDefault(b => b.Id == id);
            return goted;
        }

        public void Update(Book updateBook)
        {
            var getBook = GetById(updateBook.Id);

            getBook.Title = updateBook.Title;
            getBook.Description = updateBook.Description;
            getBook.ReleasedYear = updateBook.ReleasedYear;
            getBook.AddAuthor(updateBook.Author);
            getBook.AddPagesNumber(updateBook.PagesNumber);

            _colletionContext.books.Update(getBook);

            _colletionContext.SaveChanges();
        }
    }
}
