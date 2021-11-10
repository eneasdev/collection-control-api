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
    public class GetAllTests
    {
        [Fact]
        public void ExecuteGetAll_GetByIdShouldReturnOkResult()
        {
            // Arrange
            var clientRepository = new Mock<IClientRepository>();
            var clientController = new ClientsController(clientRepository.Object);

            List<Client> listClients = new List<Client>();

            clientRepository.Setup(c => c.GetAll()).Returns(listClients);

            // Act
            var resultado = clientController.GetAll() as OkObjectResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }
    }
}
