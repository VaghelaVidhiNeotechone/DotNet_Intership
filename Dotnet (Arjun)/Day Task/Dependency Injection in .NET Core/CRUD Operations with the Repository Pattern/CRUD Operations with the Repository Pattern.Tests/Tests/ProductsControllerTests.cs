using AutoMapper;
using CRUD_Operations_with_the_Repository_Pattern.Controllers;
using CRUD_Operations_with_the_Repository_Pattern.Dtos;
using CRUD_Operations_with_the_Repository_Pattern.Models;
using CRUD_Operations_with_the_Repository_Pattern.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Operations_with_the_Repository_Pattern.Tests.Tests
{
    public class ProductsControllerTests
    {
        // Helper: create a mapper instance if your controller uses AutoMapper.
        private IMapper GetMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ProductCreateDto, Product>();
                cfg.CreateMap<ProductUpdateDto, Product>();
            });
            return config.CreateMapper();
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WithProducts()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Product>>();
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Pen", Price = 10 },
            new Product { Id = 2, Name = "Book", Price = 100 }
        };
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(products);

            var controller = new ProductsController(mockRepo.Object, GetMapper());

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            var returned = okResult!.Value as IEnumerable<ProductDto>;
            returned!.Count().Should().Be(2);
        }

        [Fact]
        public async Task Create_CallsAddAndSave_ReturnsCreatedProduct()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Product>>();
            // AddAsync should just return CompletedTask
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);
            mockRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

            var mapper = GetMapper();
            var controller = new ProductsController(mockRepo.Object, mapper);

            var createDto = new ProductCreateDto { Name = "Pencil", Price = 5 };

            // Act
            var actionResult = await controller.Create(createDto);

            // Assert
            var okResult = actionResult as OkObjectResult;
            okResult.Should().NotBeNull();
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
            mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);

            var returned = okResult!.Value as ProductDto;
            returned!.Name.Should().Be("Pencil");
        }

        [Fact]
        public async Task Delete_WhenNotFound_ReturnsNotFound()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Product>>();
            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Product?)null);

            var controller = new ProductsController(mockRepo.Object, GetMapper());

            // Act
            var result = await controller.Delete(1);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Delete_WhenFound_CallsRemoveAndSave_ReturnsNoContent()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Product>>();
            var product = new Product { Id = 1, Name = "Pen", Price = 10 };
            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);
            mockRepo.Setup(r => r.Remove(It.IsAny<Product>()));
            mockRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

            var controller = new ProductsController(mockRepo.Object, GetMapper());

            // Act
            var result = await controller.Delete(1);

            // Assert
            result.Should().BeOfType<NoContentResult>();
            mockRepo.Verify(r => r.Remove(product), Times.Once);
            mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
