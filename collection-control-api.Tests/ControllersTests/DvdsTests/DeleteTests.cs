using collection_control_api.Controllers;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.DvdsTests
{
    public class DeleteTests
    {
        [Fact]
        public void ValidIdIsPassed_DeleteExecuted_DeleteShouldReturnNoContentResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdRepository>();
            var dvdController = new DvdsController(dvdServiceMock.Object);
            var id = 1;
            // Act
            var resultado = dvdController.Delete(id) as NoContentResult;

            // Assert
            Assert.True(resultado.StatusCode == 204);
        }

        [Fact]
        public void InvalidIdIsPassed_DeleteExecuted_DeleteShouldReturnNotFoundResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdRepository>();
            var dvdController = new DvdsController(dvdServiceMock.Object);
            var id = -1;
            // Act
            var resultado = dvdController.Delete(id) as NotFoundResult;

            // Assert
            Assert.True(resultado.StatusCode == 404);
        }
    }
}
