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

        public void Create(NewBookInputModel inputModel)
        {
            var newBook = new Book(inputModel.Title, inputModel.Author, inputModel.PagesNumber)
            {
                Description = inputModel.Description,
                ReleasedYear = inputModel.ReleasedYear
            };

            _collectionContext.books.Add(newBook);

            _collectionContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _collectionContext.books
                .FirstOrDefault(b => b.Id == id);

            _collectionContext.items
                .Remove(book);

            _collectionContext.SaveChanges();
        }

        public Book GetById(int id)
        {
            var goted = _collectionContext.books
                .OfType<Book>()
                .FirstOrDefault(b => b.Id == id);
            return goted;
        }

        public void Update(UpdateBookInputModel inputModel)
        {
            var updateBook = GetById(inputModel.Id);

            updateBook.Description = inputModel.Description;

            _collectionContext.books.Update(updateBook);

            _collectionContext.SaveChanges();
        }
    }
}
