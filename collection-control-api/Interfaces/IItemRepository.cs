using collection_control_api.Entities;
using System.Collections.Generic;

namespace collection_control_api.Interfaces
{
    public interface IItemRepository
    {
        void Lend(Loan inputLoan);
        List<Item> GetAll();
        List<Item> GetItemSearch(string stringSearch);
    }
}
