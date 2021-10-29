using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Repositories
{
    public class DvdRepository : IDvdRepository
    {
        private readonly CollectionContext _collectionContext;
        public DvdRepository(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
        }
        public void Create(NewDvdInputModel inputDvd)
        {
            var newDvd = new Dvd("Tubarão", "Van Damme", 138)
            {
                Description = inputDvd.Description,
                ReleasedYear = inputDvd.ReleasedYear
            };

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

        public void Update(UpdateItemInputModel inputDvd)
        {
            var updateDvd = GetById(inputDvd.Id);

            updateDvd.Description = inputDvd.Description;

            _collectionContext.dvds.Update(updateDvd);

            _collectionContext.SaveChanges();
        }
    }
}
