using collection_control_api.Controllers;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.CdsTests
{
    public class GetByIdTests
    {
        [Fact]
        public void ValidIdIsPassed_GetByIdExecuted_GetByIdShouldReturnOkObjectResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);
            var id = 1;
            // Act
            var resultado = cdController.GetById(id) as OkObjectResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void InvalidIdIsPassed_GetByIdExecuted_GetByIdShouldReturnNotFoundResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);
            var id = -1;
            // Act
            var resultado = cdController.GetById(id) as NotFoundResult;

            // Assert
            Assert.True(resultado.StatusCode == 404);
        }
    }
}
