using BookShop.Application.Dtos.AccountDetails;
using BookShop.Domain.AccountDetail;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Application.Mappers
{
    /// <summary>
    /// Mapping the AccountDetails object.
    /// </summary>
    public class AccountDetailsMapper : IModelMapper<AccountDetailsDto, AccountDetails>
    {
        /// <summary>
        /// Mapping AccountDetailsDto to sAccountDetails object
        /// </summary>
        /// <param name="domainEntity">AccountDetails type object</param>
        /// <returns></returns>
        public AccountDetailsDto DtoFrom(AccountDetails domainEntity)
        {
            return new AccountDetailsDto()
            {
                AccountId = domainEntity.AccountId,
                AccountName = domainEntity.AccountName,
                Balance = domainEntity.Balance,
            };
        }
    }
}
