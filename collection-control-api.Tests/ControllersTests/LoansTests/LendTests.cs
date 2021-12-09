using collection_control_api.Application.Validators;
using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.LoansTests
{
    public class LendTests
    {
        private NewLoanValidator validator = new NewLoanValidator();

        [Fact]
        public void ValidIdsArePassed_LendExecuted_ShouldLendReturnOkResult()
        {
            // Arrange
            var loanRepositoryMock = new Mock<ILoanRepository>();
            var loanController = new LoanController(loanRepositoryMock.Object);

            var loan = new NewLoanInputModel()
            {
                ClientId = 1,
                ItemId = 1
            };

            // Act
            var resultado = loanController.Lend(loan) as OkResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void ObjectPassedIsNull_LendExecuted_ShouldLendReturnBadRequestResult()
        {
            // Arrange
            var loanRepositoryMock = new Mock<ILoanRepository>();
            var loanController = new LoanController(loanRepositoryMock.Object);

            NewLoanInputModel loan = null;

            // Act
            var resultado = loanController.Lend(loan) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void ClientIdPassedIsInvalid_ValidatorExecuted_ShouldHaveValidationErrorForLoan()
        {
            // Arrange
            var loan = new NewLoanInputModel()
            {
                ClientId = 0,
                ItemId = 1
            };

            // Act
            var result = validator.TestValidate(loan);

            // Assert
            result.ShouldHaveValidationErrorFor(loan => loan.ClientId);
        }

        [Fact]
        public void ItemIdPassedIsInvalid_ValidatorExecuted_ShouldHaveValidationErrorForLoan()
        {
            // Arrange
            var loan = new NewLoanInputModel()
            {
                ClientId = 1,
                ItemId = 0
            };

            // Act
            var result = validator.TestValidate(loan);

            // Assert
            result.ShouldHaveValidationErrorFor(loan => loan.ItemId);
        }
    }
}
