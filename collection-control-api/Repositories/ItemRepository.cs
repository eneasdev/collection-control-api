using collection_control_api.Entities;
using collection_control_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly CollectionContext _collectionContext;
        public ItemRepository(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
        }

        public List<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Item> GetItemSearch(string stringSearch)
        {
            throw new NotImplementedException();
        }

        public void Lend(Item item, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
