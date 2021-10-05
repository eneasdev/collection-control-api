using collection_control_api.Controllers;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.DvdsTests
{
    public class GetByIdTests
    {
        [Fact]
        public void ValidIdIsPassed_GetByIdExecuted_GetByIdShouldReturnOkObjetcResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdService>();
            var dvdController = new DvdsController(dvdServiceMock.Object);
            var id = 1;
            // Act
            var resultado = dvdController.GetById(id) as OkObjectResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void InvalidIdIsPassed_GetByIdExecuted_GetByIdShouldReturnNotFoundResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdService>();
            var dvdController = new DvdsController(dvdServiceMock.Object);
            var id = -1;
            // Act
            var resultado = dvdController.GetById(id) as NotFoundResult;

            // Assert
            Assert.True(resultado.StatusCode == 404);
        }
    }
}
