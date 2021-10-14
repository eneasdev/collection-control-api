using collection_control_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Services
{
    public interface IItemService
    {
        void Lend(Item item, Client client);
        List<Item> GetAll();
        List<Item> GetItemSearch(string stringSearch);
    }
}
