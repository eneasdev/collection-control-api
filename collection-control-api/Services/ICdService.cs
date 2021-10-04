using collection_control_api.Entities;

namespace collection_control_api.Services
{
    public interface ICdService
    {
        Cd Create(Cd newCd);
        Cd Update(Cd updateCd);
    }
}
