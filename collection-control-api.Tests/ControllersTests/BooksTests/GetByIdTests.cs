using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.BooksTests
{
    public class GetByIdTests
    {
        [Fact]
        public void ValidIdIsPassed_GetByIdExecuted_GetByIdShouldReturnOkObjectResult()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookRepository>();
            var bookController = new BooksController(bookServiceMock.Object);

            var id = 1;

            var book = new Book() { Id = 1, Description = "Not a fun game" };

            bookServiceMock.Setup(b => b.GetById(id)).Returns(book);

            // Act
            var resultado = bookController.GetById(id) as OkObjectResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void InvalidIdIsPassed_GetByIdExecuted_GetByIdShouldReturnBadRequestResult()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookRepository>();
            var bookController = new BooksController(bookServiceMock.Object);
            var id = -1;

            // Act
            var resultado = bookController.GetById(id) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void ValidIdIsPassedButBookDoesNotExist_GetByIdExecuted_GetByIdShouldReturnNotFoundResult()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookRepository>();
            var bookController = new BooksController(bookServiceMock.Object);

            var id = 1;

            Book nullBook = null;

            bookServiceMock.Setup(b => b.GetById(1)).Returns(nullBook);

            // Act
            var resultado = bookController.GetById(id) as NotFoundResult;

            // Assert
            Assert.True(resultado.StatusCode == 404);
        }
    }
}
