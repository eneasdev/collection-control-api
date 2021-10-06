using collection_control_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Services
{
    public interface IDvdService
    {
        Dvd GetById(int id);
        void Create(Dvd newDvd);
        void Update(Dvd updateDvd);
        void Delete(int id);
    }
}
