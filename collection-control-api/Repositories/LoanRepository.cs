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

        public void Lend(NewLoanInputModel loanInputModel)
        {
            var newLoan = new Loan(loanInputModel.ItemId, loanInputModel.ClientId);

            _collectionContext.loans.Add(newLoan);

            _collectionContext.SaveChanges();

        }

    }
}
