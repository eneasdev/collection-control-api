using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.ItemsTests
{
    public class LendTests
    {
        [Fact]
        public void ValidIdsArePassed_LendExecuted_ShouldLendReturnOkResult()
        {
            // Arrange
            var itemServiceMock = new Mock<ILoanRepository>();
            var itemController = new LoanController(itemServiceMock.Object);

            var loan = new NewLoanInputModel()
            {
                ClientId = 1,
                ItemId = 1
            };

            // Act
            var resultado = itemController.Lend(loan) as OkResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void ClientIdPassedIsInvalid_LendExecuted_ShouldLendReturnBadRequestResult()
        {
            // Arrange
            var itemServiceMock = new Mock<ILoanRepository>();
            var itemController = new LoanController(itemServiceMock.Object);

            var loan = new NewLoanInputModel()
            {
                ClientId = 0,
                ItemId = 1
            };

            // Act
            var resultado = itemController.Lend(loan) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void ItemIdPassedIsInvalid_LendExecuted_ShouldLendReturnBadRequestResult()
        {
            // Arrange
            var itemServiceMock = new Mock<ILoanRepository>();
            var itemController = new LoanController(itemServiceMock.Object);

            var loan = new NewLoanInputModel()
            {
                ClientId = 1,
                ItemId = 0
            };

            // Act
            var resultado = itemController.Lend(loan) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }
    }
}
