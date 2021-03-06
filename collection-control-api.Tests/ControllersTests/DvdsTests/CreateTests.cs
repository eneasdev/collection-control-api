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
    public class CreateTests
    {
        [Fact]
        public void ValidObjectIsPassed_ExecuteCreate_CreateShouldReturnAOkResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdRepository>();
            var dvdController = new DvdsController(dvdServiceMock.Object);

            var newDvd = new NewDvdInputModel();

            // Act
            var resultado = dvdController.Create(newDvd) as OkResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void NullIsPassed_ExecuteCreate_CreateShouldReturnBadRequestResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdRepository>();
            var dvdController = new DvdsController(dvdServiceMock.Object);

            NewDvdInputModel newDvd = null;
            // Act
            var resultado = dvdController.Create(newDvd) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }
    }
}
