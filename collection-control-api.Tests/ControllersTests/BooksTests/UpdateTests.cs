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
    public class UpdateTests
    {
        private UpdateBookValidator validator = new UpdateBookValidator();

        [Fact]
        public void ValidObjectIsPassed_ExecuteUpdate_UpdateShouldReturnANoContentResult()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookRepository>();
            var bookController = new BooksController(bookServiceMock.Object);

            var id = 1;
            var updateBook = new UpdateBookInputModel() { Description = "Nice Game"};

            // Act
            var resultado = bookController.Update(id, updateBook) as NoContentResult;

            // Assert
            Assert.True(resultado.StatusCode == 204);
        }

        [Fact]
        public void NullObjectIsPassed_ExecuteUpdate_UpdateShouldReturnBadRequestObjectResult()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookRepository>();
            var bookController = new BooksController(bookServiceMock.Object);

            var id = 1;

            UpdateBookInputModel updateBook = null;

            // Act
            var resultado = bookController.Update(id, updateBook) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void NullDescriptionIsPassed_ValidatorExecuted_ShouldHaveValidationErrorForDescription()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookRepository>();
            var bookController = new BooksController(bookServiceMock.Object);

            var updateBook = new UpdateBookInputModel();
            updateBook.Description = null;

            // Act
            var result = validator.TestValidate(updateBook);

            // Assert
            result.ShouldHaveValidationErrorFor(updateBook => updateBook.Description);
        }
    }
}
