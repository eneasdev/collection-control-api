﻿using collection_control_api.Controllers;
using collection_control_api.Entities;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace collection_control_api.Tests.ControllersTests.BooksTests
{
    public class CreateTests
    {
        [Fact]
        public void ValidCdObjectIsPassed_ExecuteCreate_CreateShouldReturnAOkResult()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var bookController = new BooksController(bookServiceMock.Object);

            var newBook = new Book("Clean Code", "Tio Bob");

            // Act
            var resultado = bookController.Create(newBook) as OkResult;

            // Assert
            Assert.True(resultado.StatusCode == 200);
        }

        [Fact]
        public void NullIsPassed_ExecuteCreate_CreateShouldReturnBadRequestResult()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var bookController = new BooksController(bookServiceMock.Object);

            Book newBook = null;
            // Act
            var resultado = bookController.Create(newBook) as BadRequestResult;

            // Assert
            Assert.True(resultado.StatusCode == 400);
        }
    }
}