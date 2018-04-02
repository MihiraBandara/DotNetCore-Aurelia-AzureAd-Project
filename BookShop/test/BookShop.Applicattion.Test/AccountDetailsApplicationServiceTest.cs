using BookShop.Application.Dtos.AccountDetails;
using BookShop.Application.Services;
using BookShop.Domain.AccountDetail;
using BookShop.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JonedellCorp.Applicattion.Test
{
    public class AccountDetailsApplicationServiceTest
    {
        /// <summary>
        /// Testing GetAccountDetails method for success scenario.
        /// </summary>
        [Fact]
        public void TestAccountDetails()
        {
            //Arrange
            Mock<IAccountDetailsRepository> mockAccountDetailsRepository =
                new Mock<IAccountDetailsRepository>();

            mockAccountDetailsRepository.Setup(service => service.GetAccountDetails())
                .Returns(new List<AccountDetails>() { new AccountDetails(), new AccountDetails() });
            IAccountDetailsApplicationService accountDetailsApplicationService = new AccountDetailsApplicationService(mockAccountDetailsRepository.Object);
            //Act
            IList<AccountDetailsDto> result = accountDetailsApplicationService.GetAccountDetails();

            //Assert
            Assert.IsAssignableFrom<IList<AccountDetailsDto>>(result);
        }

        /// <summary>
        /// Testing GetAccountDetails method for unsuccess scenario.
        /// </summary>
        [Fact]
        public void TestAccountDetailsNull()
        {
            //Arrange
            Mock<IAccountDetailsRepository> mockAccountDetailsRepository =
                new Mock<IAccountDetailsRepository>();

            mockAccountDetailsRepository.Setup(service => service.GetAccountDetails());
            IAccountDetailsApplicationService accountDetailsApplicationService = new AccountDetailsApplicationService(mockAccountDetailsRepository.Object);

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => accountDetailsApplicationService.GetAccountDetails());
        }
    }
}
