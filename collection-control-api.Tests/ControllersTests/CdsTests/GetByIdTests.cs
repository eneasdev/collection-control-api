using collection_control_api.Controllers;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.CdsTests
{
    public class GetByIdTests
    {
        [Fact]
        public void ValidIdIsPassed_GetByIdExecuted_GetByIdShouldReturnNoContentResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdService>();
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
            var cdServiceMock = new Mock<ICdService>();
            var cdController = new CdsController(cdServiceMock.Object);
            var id = -1;
            // Act
            var resultado = cdController.GetById(id) as NotFoundResult;

            // Assert
            Assert.True(resultado.StatusCode == 404);
        }
    }
}
