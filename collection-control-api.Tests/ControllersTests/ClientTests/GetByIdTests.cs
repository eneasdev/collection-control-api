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
    public class GetByIdTests
    {
        [Fact]
        public void ValidIdIsPassed_ExecuteGetById_GetByIdShouldReturnAOkResult()
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            var clientController = new ClientsController(clientRepository.Object);

            var client = new Client("Eneas")
            {
                Id = 1
            };

            clientRepository.Setup(c => c.GetById(1)).Returns(client);

            // Act
            var resultado = clientController.GetById(1) as OkObjectResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void InvalidIdIsPassed_ExecuteGetById_GetByIdShouldReturnABadRequestResult()
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            var clientController = new ClientsController(clientRepository.Object);

            // Act
            var resultado = clientController.GetById(-1) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }

        [Fact]
        public void ValidIdIsPassed_ExecuteGetById_GetByIdShouldReturnNotFoundResult()
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            var clientController = new ClientsController(clientRepository.Object);

            Client client = null;

            clientRepository.Setup(c => c.GetById(1)).Returns(client);

            // Act
            var resultado = clientController.GetById(1) as NotFoundResult;

            // Assert
            Assert.True(resultado.StatusCode == 404);
        }
    }
}
