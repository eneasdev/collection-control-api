using collection_control_api.Models.InputModels.Cd;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Application.Validators
{
    public class UpdateCdValidator : AbstractValidator<UpdateCdInputModel>
    {

        public UpdateCdValidator()
        {
            RuleFor(p => p.Description)
                .NotNull()
                .Length(0, 255)
                .WithMessage("Maximum lenght of description is 255 characteres and can not be empty.");
        }
    }
}
