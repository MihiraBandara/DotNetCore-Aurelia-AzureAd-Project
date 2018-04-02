using System;
using System.Collections.Generic;
using System.Text;
using BookShop.Application.Dtos.AccountDetails;
using BookShop.Domain.AccountDetail;
using BookShop.Domain.Repositories;
using BookShop.Application.Mappers;

namespace BookShop.Application.Services
{
    /// <summary>
    /// AccountDetails application service implements application service logics.
    /// </summary>
    public class AccountDetailsApplicationService : IAccountDetailsApplicationService
    {
        private readonly IAccountDetailsRepository _accountDetailsRepository;

        public AccountDetailsApplicationService(IAccountDetailsRepository _accountDetailsRepository)
        {
            this._accountDetailsRepository = _accountDetailsRepository;
        }


        /// <summary>
        /// Get All AccountDetails.
        /// </summary>
        /// <returns>All account details</returns>
        public IList<AccountDetailsDto> GetAccountDetails()
        {
            IList<AccountDetails> accountDetails= _accountDetailsRepository.GetAccountDetails();
            if (accountDetails.Count ==0)
            {
                throw new NullReferenceException();
            }
            AccountDetailsMapper modelMapper = new AccountDetailsMapper();

            IList<AccountDetailsDto> accountDetailsDtos = new List<AccountDetailsDto>();
            foreach (AccountDetails accountDetail in accountDetails)
            {
                AccountDetailsDto accountDetaildto = modelMapper.DtoFrom(accountDetail);
                accountDetailsDtos.Add(accountDetaildto);
            }

            return accountDetailsDtos;
        }
    }
}
