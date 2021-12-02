using collection_control_api.Entities;
using collection_control_api.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            return _collectionContext.Items
                //.Include(item => item as Book)
                .ToList();
        }

        public List<Item> GetItemSearch(string stringSearch)
        {
            return _collectionContext.Items
                .Where(i => i.Title.Contains(stringSearch) || i.Description.Contains(stringSearch))
                .ToList();
        }

    }
}
