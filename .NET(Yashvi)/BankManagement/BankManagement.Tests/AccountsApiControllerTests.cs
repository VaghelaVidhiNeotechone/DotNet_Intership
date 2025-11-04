using Xunit;
using Moq;
using BankManagement.Repositories;
using BankManagement.Models;
using BankManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankManagement.Tests
{
    public class AccountsApiControllerTests
    {
        [Fact]
        public void GetAll_ReturnsAllAccounts()
        {
            var mockRepo = new Mock<IAccountRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Account>
            {
                //new Account { ID = 1, AccountHolder = "xyz" },
                new Account { ID = 2, AccountHolder = "abc" }
            });

            var controller = new AccountsApiController(mockRepo.Object);

            var result = controller.GetAll() as OkObjectResult;
            var accounts = result.Value as IEnumerable<Account>;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(accounts);
        }
    }
}
