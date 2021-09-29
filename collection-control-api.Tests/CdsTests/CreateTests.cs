using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Models.InputModels;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace collection_control_api.Tests
{
    public class CreateTests
    {
        private readonly ICdService _cdService;
        public CreateTests(ICdService cdService)
        {
            _cdService = cdService;
        }

        [Fact]
        public void Create()
        {
            // Arrange
            var cdController = new CdsController(_cdService);

            var newCd = new NewCdInputModel()
            {
                Title = "Hello",
                Singer = "Adele",
                Description = "Single",
                ReleaseYear = "2005",
                SongsNumber = 7
            };

            

            // Act
            var resultado = cdController.Create(newCd) as ObjectResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }
    }
}
