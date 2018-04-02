using System;
using System.Collections.Generic;
using System.Text;
using BookShop.Domain.AccountDetail;

namespace BookShop.Domain.Repositories
{
    /// <summary>
    /// contolling the account details repository implementation.
    /// </summary>
    public interface IAccountDetailsRepository
    {
        /// <summary>
        /// Get all account details.
        /// </summary>
        /// <returns>all account details</returns>
       IList<AccountDetails> GetAccountDetails();

    }
}
