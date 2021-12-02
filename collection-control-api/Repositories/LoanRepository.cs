using AutoMapper;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using collection_control_api.Models.InputModels.ViewModels;
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
        private readonly IMapper _mapper;

        public LoanRepository(CollectionContext collectionContext, IMapper mapper)
        {
            _collectionContext = collectionContext;
            _mapper = mapper;
        }

        public List<Loan> GetAll()
        {
            return _collectionContext.loans
                .ToList();
        }

        public void Lend(NewLoanInputModel loanInputModel)
        {
            var newLoan = new Loan(loanInputModel.ItemId, loanInputModel.ClientId);

            _collectionContext.loans.Add(newLoan);

            _collectionContext.SaveChanges();

        }

    }
}
