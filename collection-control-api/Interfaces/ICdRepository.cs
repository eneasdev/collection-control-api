using collection_control_api.Entities;
using collection_control_api.Models.InputModels;

namespace collection_control_api.Interfaces
{
    public interface ICdRepository
    {
        Cd GetById(int id);
        void Create(NewCdInputModel newCdInputModel);
        void Update(UpdateItemInputModel updateCdInputModel);
        void Delete(int id);
    }
}
