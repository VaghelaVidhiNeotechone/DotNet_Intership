using CRUD_Operations_with_the_Repository_Pattern.Dtos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Operations_with_the_Repository_Pattern.Tests.Tests
{
    public class ProductsApiEndToEndTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ProductsApiEndToEndTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task PostAndGet_ReturnsCreatedProduct()
        {
            var client = _factory.CreateClient();

            var createDto = new ProductCreateDto { Name = "Eraser", Price = 3.5M };

            var postResponse = await client.PostAsJsonAsync("/api/Products", createDto);
            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = await client.GetAsync("/api/Products");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var products = await getResponse.Content.ReadFromJsonAsync<ProductDto[]>();
            products.Should().Contain(p => p.Name == "Eraser");
        }
    }
}
