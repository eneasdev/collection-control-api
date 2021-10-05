using collection_control_api.Entities;

namespace collection_control_api.Services
{
    public interface ICdService
    {
        Cd GetById(int id);
        void Create(Cd newCd);
        void Update(Cd updateCd);
        void Delete(int id);
    }
}
