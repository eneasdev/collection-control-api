using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.DvdsTests
{
    public class GetByIdTests
    {
        [Fact]
        public void ValidIdIsPassed_GetByIdExecuted_GetByIdShouldReturnOkObjetcResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdRepository>();
            var dvdController = new DvdsController(dvdServiceMock.Object);

            var id = 1;

            var dvd = new Dvd("Rambo", "Van Damme", 159);

            dvdServiceMock.Setup(d => d.GetById(id)).Returns(dvd);

            // Act
            var resultado = dvdController.GetById(id) as OkObjectResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void InvalidIdIsPassed_GetByIdExecuted_GetByIdShouldReturnBadRequestResult()
        {
            // Arrange
            var dvdServiceMock = new Mock<IDvdRepository>();
            var dvdController = new DvdsController(dvdServiceMock.Object);
            var id = -1;
            // Act
            var resultado = dvdController.GetById(id) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }
    }
}
