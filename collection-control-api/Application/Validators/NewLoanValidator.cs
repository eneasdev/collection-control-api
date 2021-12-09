using collection_control_api.Models.InputModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Application.Validators
{
    public class NewLoanValidator : AbstractValidator<NewLoanInputModel>
    {
        public NewLoanValidator()
        {
            RuleFor(p => p.ClientId) .GreaterThan(0);
            RuleFor(p => p.ItemId).GreaterThan(0);
        }
    }
}
