using collection_control_api.Entities;

namespace collection_control_api.Interfaces
{
    public interface IBookRepository
    {
        Book GetById(int id);
        void Create(Book newBook);
        void Update(Book updateBook);
        void Delete(int id);
    }
}
