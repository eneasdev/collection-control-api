using AutoMapper;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using collection_control_api.Models.InputModels.Cd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Repositories
{
    public class CdRepository : ICdRepository
    {
        private readonly CollectionContext _collectionContext;
        private readonly IMapper _mapper;

        public CdRepository(CollectionContext collectionContext, IMapper mapper)
        {
            _collectionContext = collectionContext;
            _mapper = mapper;
        }
        public void Create(NewCdInputModel inputCd)
        {
            Cd newCd = _mapper.Map<Cd>(inputCd);

            _collectionContext.Cds.Add(newCd);

            _collectionContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var cd = GetById(id);

            _collectionContext.Cds
                .Remove(cd);

            _collectionContext.SaveChanges();
        }

        public Cd GetById(int id)
        {
            var cd = _collectionContext.Cds
                .OfType<Cd>()
                .FirstOrDefault(c => c.Id == id);

            return cd;
        }

        public void Update(UpdateCdInputModel inputCd)
        {
            var updateCd = GetById(inputCd.Id);

            updateCd = _mapper.Map<Cd>(inputCd);

            _collectionContext.Cds.Update(updateCd);

            _collectionContext.SaveChanges();
        }
    }
}
