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
    public class CreateTests
    {
        [Fact]
        public void ValidObjectIsPassed_ExecuteCreate_CreateShouldReturnAOkResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdService>();
            var dvdController = new DvdsController(dvdServiceMock.Object);

            var newDvd = new Dvd("Rei leão", "Simba");

            // Act
            var resultado = dvdController.Create(newDvd) as OkResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void NullIsPassed_ExecuteCreate_CreateShouldReturnBadRequestResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdService>();
            var dvdController = new DvdsController(dvdServiceMock.Object);

            Dvd newDvd = null;
            // Act
            var resultado = dvdController.Create(newDvd) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }
    }
}
