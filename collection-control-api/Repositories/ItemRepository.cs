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
            return _collectionContext.items.ToList();
        }

        public List<Item> GetItemSearch(string stringSearch)
        {
            return _collectionContext.items
                .Where(i => i.Title == stringSearch || i.Description == stringSearch)
                .Include(i => i.Loan)
                .ToList();
        }

        public void Lend(Item item, Client client)
        {
            var clientLend = GetClientById(client.Id);

            var itemLend = GetItemById(item.Id);

            var newLoan = new Loan();

            _collectionContext.loans.Add(newLoan);

        }

        public Item GetItemById(int id)
        {
            return _collectionContext.items.FirstOrDefault(i => i.Id == id);
        }

        public Client GetClientById(int id)
        {
            return _collectionContext.clients.FirstOrDefault(c => c.Id == id);
        }
    }
}
