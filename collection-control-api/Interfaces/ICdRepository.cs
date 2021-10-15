using collection_control_api.Entities;

namespace collection_control_api.Interfaces
{
    public interface ICdRepository
    {
        Cd GetById(int id);
        void Create(Cd newCd);
        void Update(Cd updateCd);
        void Delete(int id);
    }
}
