using collection_control_api.Entities;
using collection_control_api.Models.InputModels;

namespace collection_control_api.Interfaces
{
    public interface IDvdRepository
    {
        Dvd GetById(int id);
        void Create(NewDvdInputModel newDvdInputModel);
        void Update(UpdateItemInputModel updateDvdInputModel);
        void Delete(int id);
    }
}
