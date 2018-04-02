using BookShop.Application.Services;
using BookShop.Data.DatabaseContext;
using BookShop.Data.Repositories;
using BookShop.Web.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JonedellCorp.E2E.Test
{
    public class AccountDetailsTest
    {

        private readonly AccountDetailsController accountDetailsController;

        /// <summary>
        /// Setup dependancies for controller, application service, repository.
        /// </summary>
        public AccountDetailsTest()
        {
            DbContextOptions<BookShopDatabaseontext> options =
                new DbContextOptionsBuilder<BookShopDatabaseontext>()
                    .UseInMemoryDatabase(databaseName: "TestDB")
                    .Options;

            BookShopDatabaseontext dbContext =
                new BookShopDatabaseontext(options);

            AccountDetailsRepository accountDetailsRepository = new AccountDetailsRepository(dbContext);

            AccountDetailsApplicationService accountDetailsApplicationService =
                new AccountDetailsApplicationService(accountDetailsRepository);

            accountDetailsController = new AccountDetailsController(accountDetailsApplicationService);
        }

        /// <summary>
        ///Test for Get AccountDetails
        /// </summary>
        [Fact]
        public void PostNullCustomerTest()
        {
            IActionResult result = accountDetailsController.Get();
            Assert.IsType<OkObjectResult>(result);
        }

    }
}
