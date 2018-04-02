using BookShop.Domain.AccountDetail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Data.DatabaseContext.EntityTypeConfiguration
{
    internal class AccountDetailsEntityConfiguration : EntityTypeConfiguration<AccountDetails>
    {
        public override void Map(EntityTypeBuilder<AccountDetails> builder)
        {
            builder.ToTable("AccountDetail");
            builder.HasKey(accountDetails => accountDetails.AccountId);
        }
    }
}
