using collection_control_api.Entities;
using System.Collections.Generic;

namespace collection_control_api.Interfaces
{
    public interface IItemRepository
    {
        void Lend(Item item, Client client);
        List<Item> GetAll();
        List<Item> GetItemSearch(string stringSearch);
    }
}
