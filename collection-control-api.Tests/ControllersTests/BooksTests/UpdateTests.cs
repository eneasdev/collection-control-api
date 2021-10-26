using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.BooksTests
{
    public class UpdateTests
    {
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
        public void NullIsPassed_ExecuteUpdate_UpdateShouldReturnBadRequestResult()
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
    }
}
