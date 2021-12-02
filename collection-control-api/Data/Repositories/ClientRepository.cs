using collection_control_api.Entities;
using collection_control_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CollectionContext _collectionContext;
        public ClientRepository(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
        }

        public void Create(string inputClient)
        {
            var newClient = new Client(inputClient);

            _collectionContext.Clients.Add(newClient);

            _collectionContext.SaveChanges();
        }

        public Client GetById(int id)
        {
            var goted = _collectionContext.Clients.FirstOrDefault(c => c.Id == id);

            return goted;
        }

        public List<Client> GetAll()
        {
            return _collectionContext.Clients.ToList();
        }
    }
}
