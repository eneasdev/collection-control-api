using collection_control_api.Application.Validators;
using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using collection_control_api.Models.InputModels.Book;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.BooksTests
{
    public class CreateTests
    {
        private NewBookValidator validator = new NewBookValidator();

        [Fact]
        public void ValidCdObjectIsPassed_ExecuteCreate_CreateShouldReturnAOkResult()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookRepository>();
            var bookController = new BooksController(bookServiceMock.Object);

            var newBook = new NewBookInputModel();

            // Act
            var resultado = bookController.Create(newBook);

            // Assert
            Assert.IsType<OkResult>(resultado);
        }

        [Fact]
        public void ObjectNullIsPassed_ExecuteCreate_CreateShouldReturnBadRequestObjectResult()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookRepository>();
            var bookController = new BooksController(bookServiceMock.Object);

            NewBookInputModel newBook = null;

            // Act
            var resultado = bookController.Create(newBook);
            
            // Assert
            Assert.IsType<BadRequestResult>(resultado);
        }

        [Fact]
        public void NullIsPassedInTitle_ValidatorExecuted_ShouldHaveValidationErrorForTitleAndNotHaveErrorForTheRestParameters()
        {
            // Arrange

            var newBook = CreateNewBook();
            newBook.Title = null;

            // Act
            var result = validator.TestValidate(newBook);

            // Assert
            result.ShouldHaveValidationErrorFor(newBook => newBook. Title);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Author);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Description);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.PagesNumber);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.ReleasedYear);
        }

        [Fact]
        public void NullIsPassedInAuthor_ValidatorExecuted_ShouldHaveValidationErrorForAuthorAndNotHaveErrorForTheRestParameters()
        {
            // Arrange

            var newBook = CreateNewBook();
            newBook.Author = null;

            // Act
            var result = validator.TestValidate(newBook);

            // Assert
            result.ShouldHaveValidationErrorFor(newBook => newBook.Author);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Title);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Description);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.PagesNumber);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.ReleasedYear);
        }

        [Fact]
        public void NullIsPassedInDescription_ValidatorExecuted_ShouldHaveValidationErrorForDescriptionAndNotHaveErrorForTheRestParameters()
        {
            // Arrange

            var newBook = CreateNewBook();
            newBook.Description = null;

            // Act
            var result = validator.TestValidate(newBook);

            // Assert
            result.ShouldHaveValidationErrorFor(newBook => newBook.Description);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Title);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Author);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.PagesNumber);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.ReleasedYear);
        }

        [Fact]
        public void ZeroPagesIsPassed_ValidatorExecuted_ShouldHaveValidationErrorForPagesNumberAndNotHaveErrorForTheRestParameters()
        {
            // Arrange

            var newBook = CreateNewBook();
            newBook.PagesNumber = 0;

            // Act
            var result = validator.TestValidate(newBook);

            // Assert
            result.ShouldHaveValidationErrorFor(newBook => newBook.PagesNumber);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Title);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Author);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Description);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.ReleasedYear);
        }

        [Fact]
        public void InvalidYearIsPassed_ValidatorExecuted_ShouldHaveValidationErrorForReleasedYearAndNotHaveErrorForTheRestParameters()
        {
            // Arrange

            var newBook = CreateNewBook();
            newBook.ReleasedYear = 0;

            // Act
            var result = validator.TestValidate(newBook);

            // Assert
            result.ShouldHaveValidationErrorFor(newBook => newBook.ReleasedYear);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Title);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Author);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.Description);
            result.ShouldNotHaveValidationErrorFor(newBook => newBook.PagesNumber);
        }

        public NewBookInputModel CreateNewBook()
        {
            return new NewBookInputModel()
            {
                Title = "Titulo Fake",
                Author = "Nome Fake",
                Description = "Descrição Fake",
                PagesNumber = 300,
                ReleasedYear = 2021
            };
        }
    }
}
