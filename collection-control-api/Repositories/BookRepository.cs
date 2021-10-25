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
        private readonly CollectionContext _collectionContext;
        public BookRepository(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
        }

        public void Create(NewBookInputModel newBookInputModel)
        {
            var newBook = new Book(newBookInputModel.Title, newBookInputModel.Author)
            {
                Description = newBookInputModel.Description,
                ReleasedYear = newBookInputModel.ReleasedYear
            };

            _collectionContext.books.Add(newBook);

            _collectionContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _collectionContext.books
                .FirstOrDefault(b => b.Id == id);

            _collectionContext.items.Remove(book);

            _collectionContext.SaveChanges();
        }

        public Book GetById(int id)
        {
            var goted = _collectionContext.books
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

            _collectionContext.books.Update(getBook);

            _collectionContext.SaveChanges();
        }
    }
}
