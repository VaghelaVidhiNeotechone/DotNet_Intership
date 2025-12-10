using CRUD_Operations_with_the_Repository_Pattern.Data;
using CRUD_Operations_with_the_Repository_Pattern.Models;
using CRUD_Operations_with_the_Repository_Pattern.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRUD_Operations_with_the_Repository_Pattern.Tests.Tests
{
    public class DiRegistrationTests
    {
        [Fact]
        public void Services_ShouldResolve_RepositoryAndDbContext()
        {
            // Arrange
            var services = new ServiceCollection();

            // Mimic Program.cs registrations (use InMemory for test)
            services.AddDbContext<AppDbContext>(opts => opts.UseInMemoryDatabase("TestDb"));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            var provider = services.BuildServiceProvider();

            // Act
            //var repo = provider.GetService<IRepository<ProductApi.Models.Product>>();
            var repo = provider.GetService<IRepository<Product>>();
            var db = provider.GetService<AppDbContext>();

            // Assert
            repo.Should().NotBeNull();
            db.Should().NotBeNull();
        }
    }
}
