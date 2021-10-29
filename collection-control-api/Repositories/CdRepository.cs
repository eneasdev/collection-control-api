using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Repositories
{
    public class CdRepository : ICdRepository
    {
        private readonly CollectionContext _collectionContext;
        public CdRepository(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
        }
        public void Create(NewCdInputModel inputCd)
        {
            var newCd = new Cd("Barões da pisadinha", "Um cara ai", 5)
            {
                Description = inputCd.Description,
                ReleasedYear = inputCd.ReleasedYear
            };

            _collectionContext.cds.Add(newCd);

            _collectionContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var cd = GetById(id);

            _collectionContext.cds
                .Remove(cd);

            _collectionContext.SaveChanges();
        }

        public Cd GetById(int id)
        {
            var cd = _collectionContext.cds
                .OfType<Cd>()
                .FirstOrDefault(c => c.Id == id);

            return cd;
        }

        public void Update(UpdateItemInputModel inputCd)
        {
            var updateCd = GetById(inputCd.Id);

            updateCd.Description = inputCd.Description;

            _collectionContext.cds.Update(updateCd);

            _collectionContext.SaveChanges();
        }
    }
}
