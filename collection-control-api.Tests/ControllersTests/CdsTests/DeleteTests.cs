using collection_control_api.Controllers;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.CdsTests
{
    public class DeleteTests
    {
        [Fact]
        public void ValidIdIsPassed_DeleteExecuted_DeleteShouldReturnNoContentResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);
            var id = 1;
            // Act
            var resultado = cdController.Delete(id) as NoContentResult;

            // Assert
            Assert.True(resultado.StatusCode == 204);
        }

        [Fact]
        public void InvalidIdIsPassed_DeleteExecuted_DeleteShouldReturnNotFoundResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);
            var id = -1;
            // Act
            var resultado = cdController.Delete(id) as NotFoundResult;

            // Assert
            Assert.True(resultado.StatusCode == 404);
        }
    }
}
