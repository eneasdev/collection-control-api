using collection_control_api.Models.InputModels.Cd;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Application.Validators
{
    public class NewCdValidator : AbstractValidator<NewCdInputModel>
    {
        public NewCdValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("The title can not be empty.")
                .NotNull()
                .MaximumLength(255).WithMessage("The title maximum length is 255 .");


            RuleFor(p => p.Singer)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255).WithMessage("The singer's name maximum lenght is 255 characteres and can not be empty.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255).WithMessage("The book description maximum lenght is 255 characteres and can not be empty.");

            RuleFor(p => p.SongsNumber)
                .GreaterThan(0)
                .LessThan(15)
                .NotEmpty().WithMessage("The number of songs maximum lenght is 1000 and can not be empty.");

            RuleFor(p => p.ReleasedYear)
                .NotEmpty()
                .LessThan(NextYear())
                .GreaterThan(0)
                .WithMessage("Please enter a valid year");
        }

        public int NextYear()
        {
            var nextYear = 1 + DateTime.Now.Year;
            return nextYear;
        }
    }
}