using AutoMapper;
using collection_control_api.Entities;
using collection_control_api.Models.InputModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            this.CreateMap<NewBookInputModel, Book>();
            this.CreateMap<UpdateBookInputModel, Book>();
        }
    }
}
