using BookShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using BookShop.Domain.AccountDetail;
using BookShop.Data.DatabaseContext;
using System.Linq;

namespace BookShop.Data.Repositories
{
    /// <summary>
    /// Implementation of AccountDetails repository data access.
    /// </summary>
    public class AccountDetailsRepository : IAccountDetailsRepository
    {
        private readonly BookShopDatabaseontext _BookShopDatabaseontext;

        public AccountDetailsRepository(BookShopDatabaseontext _BookShopDatabaseontext)
        {
            this._BookShopDatabaseontext = _BookShopDatabaseontext;
        }
        /// <summary>
        /// Get all account details.
        /// </summary>
        /// <returns>all product list</returns>
        public IList<AccountDetails> GetAccountDetails()
        {
            IList<AccountDetails> accountDetails = _BookShopDatabaseontext.AccountDetail.ToList();
            return accountDetails;
        }
    }
}
