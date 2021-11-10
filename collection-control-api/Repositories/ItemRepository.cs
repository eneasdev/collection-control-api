using collection_control_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Repositories
{
    public class ItemRepository
    {
        private readonly CollectionContext _collectionContext;
        public ItemRepository(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;

        }

        public List<Item> GetAll()
        {
            return _collectionContext.items.ToList();
        }

        public List<Item> GetItemSearch(string stringSearch)
        {
            return _collectionContext.items
                .Where(i => i.Title.Contains(stringSearch) || i.Description.Contains(stringSearch))
                .ToList();
        }

    }
}
