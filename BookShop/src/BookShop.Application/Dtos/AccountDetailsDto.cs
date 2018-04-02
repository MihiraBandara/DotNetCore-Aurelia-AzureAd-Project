using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Application.Dtos.AccountDetails
{
    /// <summary>
    /// Represents the defiition of the AccountDetailsDto entity
    /// </summary>
    public class AccountDetailsDto
    {
        /// <summary>
        /// Get or set id of the account.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Get or set  name of the account
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Get or set balance of the accounts.
        /// </summary>
        public double Balance { get; set; }
    }
}
