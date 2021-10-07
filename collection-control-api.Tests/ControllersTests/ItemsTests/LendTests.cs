using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.ItemsTests
{
    public class LendTests
    {
        [Fact]
        public void ValidObjectsArePassed_LendExecuted_ShouldLendReturnOkResult()
        {
            // Arrange
            var itemServiceMock = new Mock<IItemService>();
            var itemController = new ItemsController(itemServiceMock.Object);

            var cd = new Cd("Foo Fighters", "David");
            var client = new Client("Joao");

            // Act
            var resultado = itemController.Lend(cd, client) as OkResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void FirstObjectPassedIsInvalid_LendExecuted_ShouldLendReturnBadRequestResult()
        {
            // Arrange
            var itemServiceMock = new Mock<IItemService>();
            var itemController = new ItemsController(itemServiceMock.Object);

            Cd cd = null;
            var client = new Client("Joao");

            // Act
            var resultado = itemController.Lend(cd, client) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void SecondObjectPassedIsInvalid_LendExecuted_ShouldLendReturnBadRequestResult()
        {
            // Arrange
            var itemServiceMock = new Mock<IItemService>();
            var itemController = new ItemsController(itemServiceMock.Object);

            var cd = new Cd("Foo Fighters", "David");
            Client client = null;

            // Act
            var resultado = itemController.Lend(cd, client) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }
    }
}
