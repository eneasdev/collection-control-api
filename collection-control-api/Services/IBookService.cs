using collection_control_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Services
{
    public interface IBookService
    {
        Book GetById(int id);
    }
}
