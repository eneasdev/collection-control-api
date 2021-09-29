using collection_control_api.Entities;
using collection_control_api.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Services
{
    public interface ICdService
    {
        Cd Create(NewCdInputModel inputModel);
    }
}
