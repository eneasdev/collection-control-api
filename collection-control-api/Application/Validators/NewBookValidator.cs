using collection_control_api.Models.InputModels.Book;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Application.Validators
{
    public class NewBookValidator : AbstractValidator<NewBookInputModel>
    {
        public NewBookValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("The title can not be empty.")
                .NotNull()
                .MaximumLength(255).WithMessage("The title maximum length is 255 .");


            RuleFor(p => p.Author)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255).WithMessage("The author's name maximum lenght is 255 characteres and can not be empty.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255).WithMessage("The book description maximum lenght is 255 characteres and can not be empty.");

            RuleFor(p => p.PagesNumber)
                .GreaterThan(0)
                .LessThan(1000)
                .NotEmpty().WithMessage("The number of pages maximum lenght is 1000 and can not be empty.");

            RuleFor(p => p.ReleasedYear)
                .NotEmpty()
                .LessThan(DateTime.Now.Year)
                .GreaterThan(0)
                .WithMessage("Please enter a valid year");
        }
    }
}
