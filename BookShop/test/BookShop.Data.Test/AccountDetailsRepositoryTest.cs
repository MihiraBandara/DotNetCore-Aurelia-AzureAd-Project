using BookShop.Data.DatabaseContext;
using BookShop.Data.Repositories;
using BookShop.Domain.AccountDetail;
using BookShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace JonedellCorp.Data.Test
{
    /// <summary>
    /// Test Class for AccountDetailsRepository.
    /// </summary>
    public class AccountDetailsRepositoryTest
    {
        /// <summary>
        /// Testing GetAccountDetails method for success scenario.
        /// </summary>
        [Fact]
        public void GetAccountDetailsTest()
        {
            // Arrange
            DbContextOptions<BookShopDatabaseontext> options =
                new DbContextOptionsBuilder<BookShopDatabaseontext>()
                    .UseInMemoryDatabase(databaseName: "BookShopDatabase")
                    .Options;

            List<AccountDetails> result = new List<AccountDetails>();

            using (BookShopDatabaseontext dbContext = new BookShopDatabaseontext(options))
            {

                dbContext.AccountDetail.Add(new AccountDetails()
                {
                    AccountId = 6,
                    AccountName = "R&D",
                    Balance = 500,
                });
                dbContext.AccountDetail.Add(new AccountDetails()
                {
                    AccountId = 7,
                    AccountName = "Canteen",
                    Balance = 500,
                });
                dbContext.SaveChanges();

                //Act
                IAccountDetailsRepository accountDetailsRepository = new AccountDetailsRepository(dbContext);
                result = accountDetailsRepository.GetAccountDetails().ToList();

                //Assert
                Assert.Equal(7, result.Count);
                dbContext.Dispose();
            }
        }
    }
}
