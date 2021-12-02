using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using collection_control_api.Models.InputModels.Dvd;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.DvdsTests
{
    public class UpdateTests
    {
        [Fact]
        public void ValidDvdObjectIsPassed_ExecuteUpdate_UpdateShouldReturnANoContentResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdRepository>();
            var dvdController = new DvdsController(dvdServiceMock.Object);

            var updateDvd = new UpdateDvdInputModel();

            // Act
            var resultado = dvdController.Update(updateDvd) as NoContentResult;

            // Assert
            Assert.True(resultado.StatusCode == 204);
        }

        [Fact]
        public void NullIsPassed_ExecuteUpdate_UpdateShouldReturnBadRequestResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdRepository>();
            var dvdController = new DvdsController(dvdServiceMock.Object);

            UpdateDvdInputModel updateDvd = null;

            // Act
            var resultado = dvdController.Update(updateDvd) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }
    }
}
