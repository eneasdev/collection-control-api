﻿using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using collection_control_api.Models.InputModels.Cd;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.CdsTests
{
    public class CreateTests
    {

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
        public void NullIsPassed_ExecuteCreate_CreateShouldReturnBadRequestResult()
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
    }
}
