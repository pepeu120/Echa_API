using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using echa_backend_dotnet.Controllers;
using echa_backend_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace echa_backend_dotnet.Tests
{
    public class AuthenticationMethodControllerTests
    {
        private readonly Mock<DbSet<AuthenticationMethod>> _mockSet;
        private readonly Mock<EchaContext> _mockContext;
        private readonly AuthenticationMethodController _controller;

        public AuthenticationMethodControllerTests()
        {
            _mockSet = new Mock<DbSet<AuthenticationMethod>>();
            _mockContext = new Mock<EchaContext>();
            _controller = new AuthenticationMethodController(_mockContext.Object);
        }

        [Fact]
        public async Task GetAuthenticationMethods_ReturnsListOfAuthenticationMethods()
        {
            // Arrange
            var data = new List<AuthenticationMethod>
            {
                new AuthenticationMethod { Id = 1, Name = "Method1", Description = "Desc1", CreationDate = DateTime.Now },
                new AuthenticationMethod { Id = 2, Name = "Method2", Description = "Desc2", CreationDate = DateTime.Now }
            }.AsQueryable();

            _mockSet.As<IQueryable<AuthenticationMethod>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockSet.As<IQueryable<AuthenticationMethod>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockSet.As<IQueryable<AuthenticationMethod>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockSet.As<IQueryable<AuthenticationMethod>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext.Setup(c => c.AuthenticationMethods).Returns(_mockSet.Object);

            // Act
            var result = await _controller.GetAuthenticationMethods();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<AuthenticationMethod>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnMethods = Assert.IsType<List<AuthenticationMethod>>(okResult.Value);
            Assert.Equal(2, returnMethods.Count);
        }

        [Fact]
        public async Task GetAuthenticationMethod_ReturnsNotFound_WhenIdDoesNotExist()
        {
            // Arrange
            _mockContext.Setup(c => c.AuthenticationMethods.FindAsync(It.IsAny<int>())).ReturnsAsync((AuthenticationMethod)null);

            // Act
            var result = await _controller.GetAuthenticationMethod(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAuthenticationMethod_ReturnsAuthenticationMethod_WhenIdExists()
        {
            // Arrange
            var authenticationMethod = new AuthenticationMethod { Id = 1, Name = "Method1", Description = "Desc1", CreationDate = DateTime.Now };
            _mockContext.Setup(c => c.AuthenticationMethods.FindAsync(1)).ReturnsAsync(authenticationMethod);

            // Act
            var result = await _controller.GetAuthenticationMethod(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AuthenticationMethod>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnMethod = Assert.IsType<AuthenticationMethod>(okResult.Value);
            Assert.Equal(1, returnMethod.Id);
        }

        [Fact]
        public async Task PutAuthenticationMethod_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var authenticationMethod = new AuthenticationMethod { Id = 1, Name = "Method1", Description = "Desc1", CreationDate = DateTime.Now };

            // Act
            var result = await _controller.PutAuthenticationMethod(2, authenticationMethod);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PutAuthenticationMethod_ReturnsNotFound_WhenIdDoesNotExist()
        {
            // Arrange
            var authenticationMethod = new AuthenticationMethod { Id = 1, Name = "Method1", Description = "Desc1", CreationDate = DateTime.Now };
            _mockContext.Setup(c => c.AuthenticationMethods.FindAsync(1)).ReturnsAsync((AuthenticationMethod)null);

            // Act
            var result = await _controller.PutAuthenticationMethod(1, authenticationMethod);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutAuthenticationMethod_ReturnsNoContent_WhenUpdateIsSuccessful()
        {
            // Arrange
            var authenticationMethod = new AuthenticationMethod { Id = 1, Name = "Method1", Description = "Desc1", CreationDate = DateTime.Now };
            _mockContext.Setup(c => c.AuthenticationMethods.FindAsync(1)).ReturnsAsync(authenticationMethod);
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _controller.PutAuthenticationMethod(1, authenticationMethod);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task PostAuthenticationMethod_ReturnsCreatedAtAction_WhenPostIsSuccessful()
        {
            // Arrange
            var authenticationMethod = new AuthenticationMethod { Id = 1, Name = "Method1", Description = "Desc1", CreationDate = DateTime.Now };
            _mockContext.Setup(c => c.AuthenticationMethods.Add(authenticationMethod)).Verifiable();
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _controller.PostAuthenticationMethod(authenticationMethod);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal("GetAuthenticationMethod", actionResult.ActionName);
            Assert.Equal(1, actionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task DeleteAuthenticationMethod_ReturnsNotFound_WhenIdDoesNotExist()
        {
            // Arrange
            _mockContext.Setup(c => c.AuthenticationMethods.FindAsync(1)).ReturnsAsync((AuthenticationMethod)null);

            // Act
            var result = await _controller.DeleteAuthenticationMethod(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteAuthenticationMethod_ReturnsNoContent_WhenDeleteIsSuccessful()
        {
            // Arrange
            var authenticationMethod = new AuthenticationMethod { Id = 1, Name = "Method1", Description = "Desc1", CreationDate = DateTime.Now };
            _mockContext.Setup(c => c.AuthenticationMethods.FindAsync(1)).ReturnsAsync(authenticationMethod);
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _controller.DeleteAuthenticationMethod(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}