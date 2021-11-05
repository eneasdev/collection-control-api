using collection_control_api.Controllers;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.ItemsTests
{
    public class GetAllTests
    {
        [Fact]
        public void NoParameters_GetAllExecuted_ShouldGetAllReturnOkObjectResult()
        {
            // Arrange
            var itemServiceMock = new Mock<ILoanRepository>();
            var itemController = new LoanController(itemServiceMock.Object);

            // Act
            var result = itemController.GetAll() as OkObjectResult;

            // Assert
            Assert.True(result.StatusCode == 200);
        }
    }
}
