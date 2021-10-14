using collection_control_api.Controllers;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.ItemsTests
{
    public class GetAllTests
    {
        [Fact]
        public void NoParameters_GetAllExecuted_ShouldGetAllReturnOkObjectResult()
        {
            // Arrange
            var itemServiceMock = new Mock<IItemService>();
            var itemController = new ItemsController(itemServiceMock.Object);

            // Act
            var result = itemController.GetAll() as OkObjectResult;

            // Assert
            Assert.True(result.StatusCode == 200);
        }
    }
}
