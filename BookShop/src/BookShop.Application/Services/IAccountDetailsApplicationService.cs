using BookShop.Application.Dtos.AccountDetails;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Application.Services
{
    /// <summary>
    /// contolling the account details service implementation.
    /// </summary>
    public interface IAccountDetailsApplicationService
    {
        /// <summary>
        /// Get all account details.
        /// </summary>
        /// <returns>all account details</returns>
        IList<AccountDetailsDto> GetAccountDetails();
    }
}
