using collection_control_api.Application.Validators;
using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using collection_control_api.Models.InputModels.Cd;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.CdsTests
{
    public class CreateTests
    {
        private NewCdValidator validator = new NewCdValidator();

        [Fact]
        public void ValidCdObjectIsPassed_ExecuteCreate_CreateShouldReturnAOkResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);

            var newCd = new NewCdInputModel();

            // Act
            var resultado = cdController.Create(newCd) as OkResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void NullObjectIsPassed_ExecuteCreate_CreateShouldReturnBadRequestResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);

            NewCdInputModel newCd = null;
            // Act
            var resultado = cdController.Create(newCd) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void NullIsPassedInTitle_ValidatorExecuted_ShouldHaveValidationErrorForTitleAndNotHaveErrorForTheRestParameters()
        {
            // Arrange

            var newCd = CreateNewCd();
            newCd.Title = null;

            // Act
            var result = validator.TestValidate(newCd);

            // Assert
            result.ShouldHaveValidationErrorFor(newCd => newCd.Title);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Singer);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Description);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.SongsNumber);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.ReleasedYear);
        }

        [Fact]
        public void NullIsPassedInAuthor_ValidatorExecuted_ShouldHaveValidationErrorForAuthorAndNotHaveErrorForTheRestParameters()
        {
            // Arrange

            var newCd = CreateNewCd();
            newCd.Singer = null;

            // Act
            var result = validator.TestValidate(newCd);

            // Assert
            result.ShouldHaveValidationErrorFor(newCd => newCd.Singer);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Title);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Description);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.SongsNumber);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.ReleasedYear);
        }

        [Fact]
        public void NullIsPassedInDescription_ValidatorExecuted_ShouldHaveValidationErrorForDescriptionAndNotHaveErrorForTheRestParameters()
        {
            // Arrange

            var newCd = CreateNewCd();
            newCd.Description = null;

            // Act
            var result = validator.TestValidate(newCd);

            // Assert
            result.ShouldHaveValidationErrorFor(newCd => newCd.Description);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Title);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Singer);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.SongsNumber);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.ReleasedYear);
        }

        [Fact]
        public void ZeroPagesIsPassed_ValidatorExecuted_ShouldHaveValidationErrorForPagesNumberAndNotHaveErrorForTheRestParameters()
        {
            // Arrange

            var newCd = CreateNewCd();
            newCd.SongsNumber = 0;

            // Act
            var result = validator.TestValidate(newCd);

            // Assert
            result.ShouldHaveValidationErrorFor(newCd => newCd.SongsNumber);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Title);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Singer);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Description);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.ReleasedYear);
        }

        [Fact]
        public void InvalidYearIsPassed_ValidatorExecuted_ShouldHaveValidationErrorForReleasedYearAndNotHaveErrorForTheRestParameters()
        {
            // Arrange
            var newCd = CreateNewCd();
            newCd.ReleasedYear = 0;

            // Act
            var result = validator.TestValidate(newCd);

            // Assert
            result.ShouldHaveValidationErrorFor(newCd => newCd.ReleasedYear);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Title);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Singer);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.Description);
            result.ShouldNotHaveValidationErrorFor(newCd => newCd.SongsNumber);
        }

        public NewCdInputModel CreateNewCd()
        {
            return new NewCdInputModel()
            {
                Title = "Titulo Fake",
                Singer = "Nome Fake",
                Description = "Descrição Fake",
                SongsNumber = 12,
                ReleasedYear = 2021
            };
        }
    }
}
