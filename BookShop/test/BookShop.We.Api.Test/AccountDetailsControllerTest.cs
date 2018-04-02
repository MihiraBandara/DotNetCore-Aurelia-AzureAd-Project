using BookShop.Application.Dtos.AccountDetails;
using BookShop.Application.Services;
using BookShop.Web.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookShop.Web.Api.Test
{
    /// <summary>
    /// Test Class for AccountDetailsController.
    /// </summary>
    public class AccountDetailsControllerTest
    {
        /// <summary>
        /// Testing Get controller action for success scenario.
        /// </summary>
        [Fact]
        public void TestGet()
        {
            //Arrange

            Mock<IAccountDetailsApplicationService> mockAccountDetailsApplicationService =
                new Mock<IAccountDetailsApplicationService>();

            mockAccountDetailsApplicationService.Setup(service => service.GetAccountDetails())
                .Returns(new List<AccountDetailsDto>() { new AccountDetailsDto(), new AccountDetailsDto() });
            
            AccountDetailsController controller = new AccountDetailsController(mockAccountDetailsApplicationService.Object);
            //Act
            IActionResult actionResult = controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        /// <summary>
        /// Testing Get controller action for unsuccess scenario.
        /// </summary>
        [Fact]
        public void TestGetNull()
        {
            //Arrange
            Mock<IAccountDetailsApplicationService> mockAccountDetailsApplicationService =
                new Mock<IAccountDetailsApplicationService>();

            mockAccountDetailsApplicationService.Setup(service => service.GetAccountDetails())
                .Throws<InvalidOperationException>();
            AccountDetailsController controller = new AccountDetailsController(mockAccountDetailsApplicationService.Object);
            //Act
            IActionResult actionResult = controller.Get();

            //Assert
            Assert.IsType<NoContentResult>(actionResult);
        }
    }
}
