using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.CdsTests
{
    public class UpdateTests
    {
        [Fact]
        public void ValidObjectIsPassed_ExecuteUpdate_UpdateShouldReturnANoContentResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);

            var updateCd = new Cd("Bicho Solto", "tazmania");

            // Act
            var resultado = cdController.Update(updateCd) as NoContentResult;

            // Assert
            Assert.True(resultado.StatusCode == 204);
        }

        [Fact]
        public void NullIsPassed_ExecuteUpdate_UpdateShouldReturnBadRequestResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);

            Cd updateCd = null;

            // Act
            var resultado = cdController.Update(updateCd) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }
    }
}
