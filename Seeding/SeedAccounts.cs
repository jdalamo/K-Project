using fa19projectgroup16.Models;
using fa19projectgroup16.DAL;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace fa19projectgroup16.Seeding
{
	public static class SeedAccounts
	{
	private static AppUser GetAppUser(AppDbContext _context, string email){
		AppUser user = _context.Users
			.Where(a => a.Email == email)
			.FirstOrDefault();

		return user;
	}

		public static void SeedAllAccounts(IServiceProvider service)
		{
			AppDbContext db = service.GetRequiredService<AppDbContext>();
			List<Account> Accounts = new List<Account>();
            List<StockPortfolio> portfolios = new List<StockPortfolio>();
            List<IRAAccount> IRAAccounts = new List<IRAAccount>();

			StockPortfolio a1 = new StockPortfolio()
			{
				Balance = 0m,
				AccountName = "Shan's Stock",
				AccountType = AccountType.Stock,
				AccountNumber = 1000000000,
				AppUser = GetAppUser(db, "Dixon@aool.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a1);

			Account a2 = new Account()
			{
				Balance = 40035.5m,
				AccountName = "William's Savings",
				AccountType = AccountType.Savings,
				AccountNumber = 1000000001,
				AppUser = GetAppUser(db, "willsheff@email.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a2);

			Account a3 = new Account()
			{
				Balance = 39779.49m,
				AccountName = "Gregory's Checking",
				AccountType = AccountType.Checking,
				AccountNumber = 1000000002,
				AppUser = GetAppUser(db, "smartinmartin.Martin@aool.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a3);

			Account a4 = new Account()
			{
				Balance = 47277.33m,
				AccountName = "Allen's Checking",
				AccountType = AccountType.Checking,
				AccountNumber = 1000000003,
				AppUser = GetAppUser(db, "avelasco@yaho.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a4);

			Account a5 = new Account()
			{
				Balance = 70812.15m,
				AccountName = "Reagan's Checking",
				AccountType = AccountType.Checking,
				AccountNumber = 1000000004,
				AppUser = GetAppUser(db, "rwood@voyager.net"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a5);

			Account a6 = new Account()
			{
				Balance = 21901.97m,
				AccountName = "Kelly's Savings",
				AccountType = AccountType.Savings,
				AccountNumber = 1000000005,
				AppUser = GetAppUser(db, "nelson.Kelly@aool.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a6);

			Account a7 = new Account()
			{
				Balance = 70480.99m,
				AccountName = "Eryn's Checking",
				AccountType = AccountType.Checking,
				AccountNumber = 1000000006,
				AppUser = GetAppUser(db, "erynrice@aool.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a7);

			Account a8 = new Account()
			{
				Balance = 7916.4m,
				AccountName = "Jake's Savings",
				AccountType = AccountType.Savings,
				AccountNumber = 1000000007,
				AppUser = GetAppUser(db, "westj@pioneer.net"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a8);

			StockPortfolio a9 = new StockPortfolio()
			{
				Balance = 0m,
				AccountName = "Michelle's Stock",
				AccountType = AccountType.Stock,
				AccountNumber = 1000000008,
				AppUser = GetAppUser(db, "mb@aool.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a9);

			Account a10 = new Account()
			{
				Balance = 69576.83m,
				AccountName = "Jeffrey's Savings",
				AccountType = AccountType.Savings,
				AccountNumber = 1000000009,
				AppUser = GetAppUser(db, "jeff@ggmail.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a10);

			StockPortfolio a11 = new StockPortfolio()
			{
				Balance = 0m,
				AccountName = "Kelly's Stock",
				AccountType = AccountType.Stock,
				AccountNumber = 1000000010,
				AppUser = GetAppUser(db, "nelson.Kelly@aool.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a11);

			Account a12 = new Account()
			{
				Balance = 30279.33m,
				AccountName = "Eryn's Checking 2",
				AccountType = AccountType.Checking,
				AccountNumber = 1000000011,
				AppUser = GetAppUser(db, "erynrice@aool.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a12);

			IRAAccount a13 = new IRAAccount()
			{
				Balance = 5000m,
				AccountName = "Jennifer's IRA",
				AccountType = AccountType.IRA,
				AccountNumber = 1000000012,
				AppUser = GetAppUser(db, "mackcloud@pimpdaddy.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a13);

			Account a14 = new Account()
			{
				Balance = 11958.08m,
				AccountName = "Sarah's Savings",
				AccountType = AccountType.Savings,
				AccountNumber = 1000000013,
				AppUser = GetAppUser(db, "ss34@ggmail.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a14);

			Account a15 = new Account()
			{
				Balance = 72990.47m,
				AccountName = "Jeremy's Savings",
				AccountType = AccountType.Savings,
				AccountNumber = 1000000014,
				AppUser = GetAppUser(db, "tanner@ggmail.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a15);

			Account a16 = new Account()
			{
				Balance = 7417.2m,
				AccountName = "Elizabeth's Savings",
				AccountType = AccountType.Savings,
				AccountNumber = 1000000015,
				AppUser = GetAppUser(db, "liz@ggmail.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a16);

			IRAAccount a17 = new IRAAccount()
			{
				Balance = 5000m,
				AccountName = "Allen's IRA",
				AccountType = AccountType.IRA,
				AccountNumber = 1000000016,
				AppUser = GetAppUser(db, "ra@aoo.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a17);

			StockPortfolio a18 = new StockPortfolio()
			{
				Balance = 0m,
				AccountName = "John's Stock",
				AccountType = AccountType.Stock,
				AccountNumber = 1000000017,
				AppUser = GetAppUser(db, "johnsmith187@aool.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a18);

			Account a19 = new Account()
			{
				Balance = 1642.82m,
				AccountName = "Clarence's Savings",
				AccountType = AccountType.Savings,
				AccountNumber = 1000000018,
				AppUser = GetAppUser(db, "mclarence@aool.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a19);

			Account a20 = new Account()
			{
				Balance = 84421.45m,
				AccountName = "Sarah's Checking",
				AccountType = AccountType.Checking,
				AccountNumber = 1000000019,
				AppUser = GetAppUser(db, "ss34@ggmail.com"),
				Date = new DateTime(2016, 1, 1),
				Is_Active = true
			};
			Accounts.Add(a20);

			foreach (Account account in Accounts)
			{
				db.Add(account);
				db.SaveChanges();
			}
		}
	}
}