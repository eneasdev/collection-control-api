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
    public class UpdateTests
    {
        private UpdateCdValidator validator = new UpdateCdValidator();

        [Fact]
        public void ValidObjectIsPassed_ExecuteUpdate_UpdateShouldReturnANoContentResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);

            var id = 1;

            var updateCd = new UpdateCdInputModel();

            // Act
            var resultado = cdController.Update(id, updateCd) as NoContentResult;

            // Assert
            Assert.True(resultado.StatusCode == 204);
        }

        [Fact]
        public void NullIsPassed_ExecuteUpdate_UpdateShouldReturnBadRequestResult()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);

            var id = 1;

            UpdateCdInputModel updateCd = null;

            // Act
            var resultado = cdController.Update(id, updateCd) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void NullDescriptionIsPassed_ValidatorExecuted_ShouldHaveValidationErrorForDescription()
        {
            // Arrange
            var cdServiceMock = new Mock<ICdRepository>();
            var cdController = new CdsController(cdServiceMock.Object);

            var updateCd = new UpdateCdInputModel();
            updateCd.Description = null;

            // Act
            var result = validator.TestValidate(updateCd);

            // Assert
            result.ShouldHaveValidationErrorFor(updateCd => updateCd.Description);
        }
    }
}
