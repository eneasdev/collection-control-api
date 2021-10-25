using collection_control_api.Entities;
using collection_control_api.Models.InputModels;

namespace collection_control_api.Interfaces
{
    public interface IBookRepository
    {
        Book GetById(int id);
        void Create(NewBookInputModel newBook);
        void Update(Book updateBook);
        void Delete(int id);
    }
}
