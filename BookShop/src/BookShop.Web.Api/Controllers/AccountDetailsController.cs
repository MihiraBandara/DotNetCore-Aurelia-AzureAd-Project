using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using BookShop.Application.Services;
using BookShop.Application.Dtos.AccountDetails;

namespace BookShop.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/AccountDetails")]
    public class AccountDetailsController : Controller
    {
        private readonly IAccountDetailsApplicationService _accountDetailsApplicationService;

        public AccountDetailsController(IAccountDetailsApplicationService _accountDetailsApplicationService)
        {
            this._accountDetailsApplicationService = _accountDetailsApplicationService;

        }

        /// <summary>
        /// Get all Account details list
        /// </summary>
        /// <returns>Account details list</returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(IList<AccountDetailsDto>), 200)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<AccountDetailsDto> accountDetails = new List<AccountDetailsDto>();

                accountDetails = _accountDetailsApplicationService.GetAccountDetails();

                return Ok(accountDetails);
            }
            catch (InvalidOperationException)
            {
                return NoContent();
            }

        }

    }
}