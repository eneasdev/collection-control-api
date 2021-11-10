using collection_control_api.Controllers;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.ItemsTests
{
    public class GetItemSearchTests
    {
        [Fact]
        public void ValidaStringPassed_GetItemSearchExecuted_ShouldGetItemSearchReturnOkObjectResult()
        {
            // Arrange
            var itemRepositoryMock = new Mock<IItemRepository>();
            var itemController = new ItemsController(itemRepositoryMock.Object);

            var searchString = "Foo";

            // Act
            var result = itemController.GetItemSearch(searchString) as OkObjectResult;

            // Assert
            Assert.True(result.StatusCode == 200);
        }

        [Fact]
        public void WhiteSpaceStringPassed_GetItemSearchExecuted_ShouldGetItemSearchReturnNotFoundResult()
        {
            // Arrange
            var itemRepositoryMock = new Mock<IItemRepository>();
            var itemController = new ItemsController(itemRepositoryMock.Object);

            var searchString = "";

            // Act
            var result = itemController.GetItemSearch(searchString) as NotFoundResult;

            // Assert
            Assert.True(result.StatusCode == 404);
        }

        [Fact]
        public void NullStringPassed_GetItemSearchExecuted_ShouldGetItemSearchReturnNotFoundResult()
        {
            // Arrange
            var itemRepositoryMock = new Mock<IItemRepository>();
            var itemController = new ItemsController(itemRepositoryMock.Object);

            string searchString = null;

            // Act
            var result = itemController.GetItemSearch(searchString) as NotFoundResult;

            // Assert
            Assert.True(result.StatusCode == 404);
        }
    }
}
