using BookShop.Data.DatabaseContext.EntityTypeConfiguration;
using BookShop.Domain.AccountDetail;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Data.DatabaseContext
{
    public class BookShopDatabaseontext:DbContext
    {
        public BookShopDatabaseontext(DbContextOptions<BookShopDatabaseontext> options)
        : base(options)
        {
            this.Database.EnsureCreated();
            ensureAccountDetailsSeeded();
        }

        public DbSet<AccountDetails> AccountDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new AccountDetailsEntityConfiguration());
        }

        /// <summary>
        /// Seed account details.
        /// </summary>
        private void ensureAccountDetailsSeeded()
        {
            if (!this.AccountDetail.Any())
            {
                AccountDetails[] accountDetails = new AccountDetails[]
                {
                    new AccountDetails()
                    {
                        AccountId= 1,
                        AccountName = "Research books",
                        Balance =30000
                    },
                    new AccountDetails()
                    {
                        AccountId= 2,
                        AccountName = "Science & Tech",
                        Balance =50000
                    },
                    new AccountDetails()
                    {
                        AccountId= 3,
                        AccountName = "Arts",
                        Balance =10000
                    },
                    new AccountDetails()
                    {
                        AccountId= 4,
                        AccountName = "Economics",
                        Balance =-6000
                    },
                      new AccountDetails()
                    {
                        AccountId= 5,
                        AccountName = "Novels",
                        Balance =20000
                    }
                };

                this.AccountDetail.AddRange(accountDetails);
                this.SaveChanges();
            }
        }
    }
}
