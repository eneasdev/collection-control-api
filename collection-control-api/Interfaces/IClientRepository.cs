using collection_control_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Interfaces
{
    public interface IClientRepository
    {
        Client GetById(int id);
        void Create(string inputClientName);
    }
}
