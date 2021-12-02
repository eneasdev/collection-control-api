using AutoMapper;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using collection_control_api.Models.InputModels.Dvd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Repositories
{
    public class DvdRepository : IDvdRepository
    {
        private readonly CollectionContext _collectionContext;
        private readonly IMapper _mapper;

        public DvdRepository(CollectionContext collectionContext, IMapper mapper)
        {
            _collectionContext = collectionContext;
            _mapper = mapper;
        }
        public void Create(NewDvdInputModel inputDvd)
        {
            Dvd newDvd = _mapper.Map<Dvd>(inputDvd);

            _collectionContext.dvds.Add(newDvd);

            _collectionContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var dvd = GetById(id);

            _collectionContext.dvds
                .Remove(dvd);

            _collectionContext.SaveChanges();
        }

        public Dvd GetById(int id)
        {
            var dvd = _collectionContext.dvds
                .OfType<Dvd>()
                .FirstOrDefault(d => d.Id == id);

            return dvd;
        }

        public void Update(UpdateDvdInputModel inputDvd)
        {
            var updateDvd = GetById(inputDvd.Id);

            updateDvd = _mapper.Map<Dvd>(inputDvd);

            _collectionContext.dvds.Update(updateDvd);

            _collectionContext.SaveChanges();
        }
    }
}
