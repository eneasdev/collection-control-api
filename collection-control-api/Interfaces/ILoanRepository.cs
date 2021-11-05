using collection_control_api.Entities;
using collection_control_api.Models.InputModels;
using System.Collections.Generic;

namespace collection_control_api.Interfaces
{
    public interface ILoanRepository
    {
        void Lend(NewLoanInputModel loanInputModel);
        List<Item> GetAll();
        List<Item> GetItemSearch(string stringSearch);
    }
}
