using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.ClientTests
{
    public class CreateTests
    {
        [Fact]
        public void ValidStringIsPassed_ExecuteCreate_CreateShouldReturnAOkResult()
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            var clientController = new ClientsController(clientRepository.Object);

            clientRepository.Setup(c => c.Create("Eneas"));

            // Act
            var resultado = clientController.Create("Eneas") as OkResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void NullStringIsPassed_ExecuteCreate_CreateShouldReturnABadRequestResult()
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            var clientController = new ClientsController(clientRepository.Object);

            string newClientName = null;

            // Act
            var resultado = clientController.Create(newClientName) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void EmptyStringIsPassed_ExecuteCreate_CreateShouldReturnABadRequestResult()
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            var clientController = new ClientsController(clientRepository.Object);

            string newClientName = "";

            // Act
            var resultado = clientController.Create(newClientName) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }
    }
}
