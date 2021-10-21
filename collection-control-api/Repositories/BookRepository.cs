using collection_control_api.Entities;
using collection_control_api.Interfaces;
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

        public void Create(Book newBook)
        {
            _colletionContext.books.Add(newBook);

            _colletionContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _colletionContext.books.FirstOrDefault(b => b.Id == id);

            _colletionContext.books.Remove(book);

            _colletionContext.SaveChanges();
        }

        public Book GetById(int id)
        {
            return _colletionContext.books.FirstOrDefault(b => b.Id == id);
        }

        public void Update(Book updateBook)
        {
            _colletionContext.books.Update(updateBook);

            _colletionContext.SaveChanges();
        }
    }
}
