using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly CollectionContext _collectionContext;
        public LoanRepository(CollectionContext collectionContext)
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

        public void Lend(NewLoanInputModel loanInputModel)
        {
            var newLoan = new Loan(loanInputModel.ItemId, loanInputModel.ClientId);

            _collectionContext.loans.Add(newLoan);

            _collectionContext.SaveChanges();

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
