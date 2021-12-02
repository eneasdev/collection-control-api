using AutoMapper;
using collection_control_api.Entities;
using collection_control_api.Models.InputModels.Cd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Mapper
{
    public class CdProfile : Profile
    {
        public CdProfile()
        {
            this.CreateMap<NewCdInputModel, Cd>();
            this.CreateMap<UpdateCdInputModel, Cd>();
        }
    }
}
