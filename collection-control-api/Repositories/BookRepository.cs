using AutoMapper;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using collection_control_api.Models.InputModels.Book;
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
        private readonly IMapper _mapper;

        public BookRepository(CollectionContext collectionContext, IMapper mapper)
        {
            _collectionContext = collectionContext;
            _mapper = mapper;
        }

        public void Create(NewBookInputModel inputModel)
        {
            Book newBook = _mapper.Map<Book>(inputModel);

            _collectionContext.books.Add(newBook);

            _collectionContext.SaveChanges();
        }
        

        public void Delete(int id)
        {
            var book = _collectionContext.books
                .FirstOrDefault(b => b.Id == id);

            _collectionContext.books
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

            updateBook = _mapper.Map<Book>(inputModel);

            _collectionContext.books.Update(updateBook);

            _collectionContext.SaveChanges();
        }
    }
}
