using collection_control_api.Entities;

namespace collection_control_api.Interfaces
{
    public interface IDvdRepository
    {
        Dvd GetById(int id);
        void Create(Dvd newDvd);
        void Update(Dvd updateDvd);
        void Delete(int id);
    }
}
