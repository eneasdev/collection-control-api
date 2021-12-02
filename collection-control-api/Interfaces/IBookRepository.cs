using collection_control_api.Entities;
using collection_control_api.Models.InputModels;
using collection_control_api.Models.InputModels.Book;

namespace collection_control_api.Interfaces
{
    public interface IBookRepository
    {
        Cd GetById(int id);
        void Create(NewBookInputModel inputModel);
        void Update(UpdateBookInputModel inputModel);
        void Delete(int id);
    }
}
