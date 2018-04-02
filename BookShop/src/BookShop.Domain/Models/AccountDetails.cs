using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Domain.AccountDetail
{
    /// <summary>
    /// Represents the defination of a account details object.
    /// </summary>
    public class AccountDetails
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
