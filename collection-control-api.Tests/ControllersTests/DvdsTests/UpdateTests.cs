using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.DvdsTests
{
    public class UpdateTests
    {
        [Fact]
        public void ValidDvdObjectIsPassed_ExecuteUpdate_UpdateShouldReturnANoContentResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdService>();
            var dvdController = new DvdsController(dvdServiceMock.Object);

            var updateDvd = new Dvd("Rei leão", "Simba");

            // Act
            var resultado = dvdController.Update(updateDvd) as NoContentResult;

            // Assert
            Assert.True(resultado.StatusCode == 204);
        }

        [Fact]
        public void NullIsPassed_ExecuteUpdate_UpdateShouldReturnBadRequestResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdService>();
            var dvdController = new DvdsController(dvdServiceMock.Object);

            Dvd updateDvd = null;

            // Act
            var resultado = dvdController.Update(updateDvd) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }
    }
}
