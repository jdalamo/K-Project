using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;


namespace fa19projectgroup16.Seeding
{
	public static class SeedingCustomers
	{
		public static async Task AddCustomer(IServiceProvider serviceProvider)
		{
			AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


			if (await _roleManager.RoleExistsAsync("Customer") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("Customer"));
			}


			AppUser newUser1 = _db.Users.FirstOrDefault(u => u.Email == "cbaker@freezing.co.uk");
			if (newUser1 == null)
			{
				newUser1 = new AppUser();
				newUser1.UserName = "cbaker@freezing.co.uk";
				newUser1.Email = "cbaker@freezing.co.uk";
				newUser1.FirstName = "Christopher";
				newUser1.LastName = "Baker";
				newUser1.MiddleInitial = 'L';
				newUser1.Street = "1245 Lake Austin Blvd.";
				newUser1.City = "Austin";
				newUser1.State = "TX";
				newUser1.Zip = "78733";
				newUser1.PhoneNumber = "5125571146";
				newUser1.Birthday = Convert.ToDateTime("1991-02-07 00:00:00");


				var result = await _userManager.CreateAsync(newUser1, "gazing");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString()); 
				}

				_db.SaveChanges();
				newUser1 = _db.Users.FirstOrDefault(u => u.UserName == "cbaker@freezing.co.uk");
			}


			if (await _userManager.IsInRoleAsync(newUser1, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser1, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser2 = _db.Users.FirstOrDefault(u => u.Email == "mb@aool.com");
			if (newUser2 == null)
			{
				newUser2 = new AppUser();
				newUser2.UserName = "mb@aool.com";
				newUser2.Email = "mb@aool.com";
				newUser2.FirstName = "Michelle";
				newUser2.LastName = "Banks";
				newUser2.Street = "1300 Tall Pine Lane";
				newUser2.City = "San Antonio";
				newUser2.State = "TX";
				newUser2.Zip = "78261";
				newUser2.PhoneNumber = "2102678873";
				newUser2.Birthday = Convert.ToDateTime("1990-06-23 00:00:00");


				var result = await _userManager.CreateAsync(newUser2, "banquet");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser2 = _db.Users.FirstOrDefault(u => u.UserName == "mb@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser2, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser2, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser3 = _db.Users.FirstOrDefault(u => u.Email == "fd@aool.com");
			if (newUser3 == null)
			{
				newUser3 = new AppUser();
				newUser3.UserName = "fd@aool.com";
				newUser3.Email = "fd@aool.com";
				newUser3.FirstName = "Franco";
				newUser3.LastName = "Broccolo";
				newUser3.MiddleInitial = 'V';
				newUser3.Street = "62 Browning Rd";
				newUser3.City = "Houston";
				newUser3.State = "TX";
				newUser3.Zip = "77019";
				newUser3.PhoneNumber = "8175659699";
				newUser3.Birthday = Convert.ToDateTime("1986-05-06 00:00:00");


				var result = await _userManager.CreateAsync(newUser3, "666666");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser3 = _db.Users.FirstOrDefault(u => u.UserName == "fd@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser3, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser3, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser4 = _db.Users.FirstOrDefault(u => u.Email == "wendy@ggmail.com");
			if (newUser4 == null)
			{
				newUser4 = new AppUser();
				newUser4.UserName = "wendy@ggmail.com";
				newUser4.Email = "wendy@ggmail.com";
				newUser4.FirstName = "Wendy";
				newUser4.LastName = "Chang";
				newUser4.MiddleInitial = 'L';
				newUser4.Street = "202 Bellmont Hall";
				newUser4.City = "Austin";
				newUser4.State = "TX";
				newUser4.Zip = "78713";
				newUser4.PhoneNumber = "5125943222";
				newUser4.Birthday = Convert.ToDateTime("1964-12-21 00:00:00");


				var result = await _userManager.CreateAsync(newUser4, "clover");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser4 = _db.Users.FirstOrDefault(u => u.UserName == "wendy@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser4, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser4, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser5 = _db.Users.FirstOrDefault(u => u.Email == "limchou@yaho.com");
			if (newUser5 == null)
			{
				newUser5 = new AppUser();
				newUser5.UserName = "limchou@yaho.com";
				newUser5.Email = "limchou@yaho.com";
				newUser5.FirstName = "Lim";
				newUser5.LastName = "Chou";
				newUser5.Street = "1600 Teresa Lane";
				newUser5.City = "San Antonio";
				newUser5.State = "TX";
				newUser5.Zip = "78266";
				newUser5.PhoneNumber = "2107724599";
				newUser5.Birthday = Convert.ToDateTime("1950-06-14 00:00:00");


				var result = await _userManager.CreateAsync(newUser5, "austin");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser5 = _db.Users.FirstOrDefault(u => u.UserName == "limchou@yaho.com");
			}


			if (await _userManager.IsInRoleAsync(newUser5, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser5, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser6 = _db.Users.FirstOrDefault(u => u.Email == "Dixon@aool.com");
			if (newUser6 == null)
			{
				newUser6 = new AppUser();
				newUser6.UserName = "Dixon@aool.com";
				newUser6.Email = "Dixon@aool.com";
				newUser6.FirstName = "Shan";
				newUser6.LastName = "Dixon";
				newUser6.MiddleInitial = 'D';
				newUser6.Street = "234 Holston Circle";
				newUser6.City = "Dallas";
				newUser6.State = "TX";
				newUser6.Zip = "75208";
				newUser6.PhoneNumber = "2142643255";
				newUser6.Birthday = Convert.ToDateTime("1930-05-09 00:00:00");


				var result = await _userManager.CreateAsync(newUser6, "mailbox");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser6 = _db.Users.FirstOrDefault(u => u.UserName == "Dixon@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser6, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser6, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser7 = _db.Users.FirstOrDefault(u => u.Email == "louann@ggmail.com");
			if (newUser7 == null)
			{
				newUser7 = new AppUser();
				newUser7.UserName = "louann@ggmail.com";
				newUser7.Email = "louann@ggmail.com";
				newUser7.FirstName = "Lou Ann";
				newUser7.LastName = "Feeley";
				newUser7.MiddleInitial = 'K';
				newUser7.Street = "600 S 8th Street W";
				newUser7.City = "Houston";
				newUser7.State = "TX";
				newUser7.Zip = "77010";
				newUser7.PhoneNumber = "8172556749";
				newUser7.Birthday = Convert.ToDateTime("1930-02-24 00:00:00");


				var result = await _userManager.CreateAsync(newUser7, "aggies");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser7 = _db.Users.FirstOrDefault(u => u.UserName == "louann@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser7, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser7, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser8 = _db.Users.FirstOrDefault(u => u.Email == "tfreeley@minntonka.ci.state.mn.us");
			if (newUser8 == null)
			{
				newUser8 = new AppUser();
				newUser8.UserName = "tfreeley@minntonka.ci.state.mn.us";
				newUser8.Email = "tfreeley@minntonka.ci.state.mn.us";
				newUser8.FirstName = "Tesa";
				newUser8.LastName = "Freeley";
				newUser8.MiddleInitial = 'P';
				newUser8.Street = "4448 Fairview Ave.";
				newUser8.City = "Houston";
				newUser8.State = "TX";
				newUser8.Zip = "77009";
				newUser8.PhoneNumber = "8173255687";
				newUser8.Birthday = Convert.ToDateTime("1935-09-01 00:00:00");


				var result = await _userManager.CreateAsync(newUser8, "raiders");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser8 = _db.Users.FirstOrDefault(u => u.UserName == "tfreeley@minntonka.ci.state.mn.us");
			}


			if (await _userManager.IsInRoleAsync(newUser8, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser8, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser9 = _db.Users.FirstOrDefault(u => u.Email == "mgar@aool.com");
			if (newUser9 == null)
			{
				newUser9 = new AppUser();
				newUser9.UserName = "mgar@aool.com";
				newUser9.Email = "mgar@aool.com";
				newUser9.FirstName = "Margaret";
				newUser9.LastName = "Garcia";
				newUser9.MiddleInitial = 'L';
				newUser9.Street = "594 Longview";
				newUser9.City = "Houston";
				newUser9.State = "TX";
				newUser9.Zip = "77003";
				newUser9.PhoneNumber = "8176593544";
				newUser9.Birthday = Convert.ToDateTime("1990-07-03 00:00:00");


				var result = await _userManager.CreateAsync(newUser9, "mustangs");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser9 = _db.Users.FirstOrDefault(u => u.UserName == "mgar@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser9, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser9, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser10 = _db.Users.FirstOrDefault(u => u.Email == "chaley@thug.com");
			if (newUser10 == null)
			{
				newUser10 = new AppUser();
				newUser10.UserName = "chaley@thug.com";
				newUser10.Email = "chaley@thug.com";
				newUser10.FirstName = "Charles";
				newUser10.LastName = "Haley";
				newUser10.MiddleInitial = 'E';
				newUser10.Street = "One Cowboy Pkwy";
				newUser10.City = "Dallas";
				newUser10.State = "TX";
				newUser10.Zip = "75261";
				newUser10.PhoneNumber = "2148475583";
				newUser10.Birthday = Convert.ToDateTime("1985-09-17 00:00:00");


				var result = await _userManager.CreateAsync(newUser10, "region");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser10 = _db.Users.FirstOrDefault(u => u.UserName == "chaley@thug.com");
			}


			if (await _userManager.IsInRoleAsync(newUser10, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser10, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser11 = _db.Users.FirstOrDefault(u => u.Email == "jeff@ggmail.com");
			if (newUser11 == null)
			{
				newUser11 = new AppUser();
				newUser11.UserName = "jeff@ggmail.com";
				newUser11.Email = "jeff@ggmail.com";
				newUser11.FirstName = "Jeffrey";
				newUser11.LastName = "Hampton";
				newUser11.MiddleInitial = 'T';
				newUser11.Street = "337 38th St.";
				newUser11.City = "Austin";
				newUser11.State = "TX";
				newUser11.Zip = "78705";
				newUser11.PhoneNumber = "5126978613";
				newUser11.Birthday = Convert.ToDateTime("1995-01-23 00:00:00");


				var result = await _userManager.CreateAsync(newUser11, "hungry");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser11 = _db.Users.FirstOrDefault(u => u.UserName == "jeff@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser11, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser11, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser12 = _db.Users.FirstOrDefault(u => u.Email == "wjhearniii@umch.edu");
			if (newUser12 == null)
			{
				newUser12 = new AppUser();
				newUser12.UserName = "wjhearniii@umch.edu";
				newUser12.Email = "wjhearniii@umch.edu";
				newUser12.FirstName = "John";
				newUser12.LastName = "Hearn";
				newUser12.MiddleInitial = 'B';
				newUser12.Street = "4225 North First";
				newUser12.City = "Dallas";
				newUser12.State = "TX";
				newUser12.Zip = "75237";
				newUser12.PhoneNumber = "2148965621";
				newUser12.Birthday = Convert.ToDateTime("1994-01-08 00:00:00");


				var result = await _userManager.CreateAsync(newUser12, "logicon");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser12 = _db.Users.FirstOrDefault(u => u.UserName == "wjhearniii@umch.edu");
			}


			if (await _userManager.IsInRoleAsync(newUser12, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser12, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser13 = _db.Users.FirstOrDefault(u => u.Email == "hicks43@ggmail.com");
			if (newUser13 == null)
			{
				newUser13 = new AppUser();
				newUser13.UserName = "hicks43@ggmail.com";
				newUser13.Email = "hicks43@ggmail.com";
				newUser13.FirstName = "Anthony";
				newUser13.LastName = "Hicks";
				newUser13.MiddleInitial = 'J';
				newUser13.Street = "32 NE Garden Ln., Ste 910";
				newUser13.City = "San Antonio";
				newUser13.State = "TX";
				newUser13.Zip = "78239";
				newUser13.PhoneNumber = "2105788965";
				newUser13.Birthday = Convert.ToDateTime("1990-10-06 00:00:00");


				var result = await _userManager.CreateAsync(newUser13, "doofus");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser13 = _db.Users.FirstOrDefault(u => u.UserName == "hicks43@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser13, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser13, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser14 = _db.Users.FirstOrDefault(u => u.Email == "bradsingram@mall.utexas.edu");
			if (newUser14 == null)
			{
				newUser14 = new AppUser();
				newUser14.UserName = "bradsingram@mall.utexas.edu";
				newUser14.Email = "bradsingram@mall.utexas.edu";
				newUser14.FirstName = "Brad";
				newUser14.LastName = "Ingram";
				newUser14.MiddleInitial = 'S';
				newUser14.Street = "6548 La Posada Ct.";
				newUser14.City = "Austin";
				newUser14.State = "TX";
				newUser14.Zip = "78736";
				newUser14.PhoneNumber = "5124678821";
				newUser14.Birthday = Convert.ToDateTime("1984-04-12 00:00:00");


				var result = await _userManager.CreateAsync(newUser14, "mother");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser14 = _db.Users.FirstOrDefault(u => u.UserName == "bradsingram@mall.utexas.edu");
			}


			if (await _userManager.IsInRoleAsync(newUser14, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser14, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser15 = _db.Users.FirstOrDefault(u => u.Email == "mother.Ingram@aool.com");
			if (newUser15 == null)
			{
				newUser15 = new AppUser();
				newUser15.UserName = "mother.Ingram@aool.com";
				newUser15.Email = "mother.Ingram@aool.com";
				newUser15.FirstName = "Todd";
				newUser15.LastName = "Jacobs";
				newUser15.MiddleInitial = 'L';
				newUser15.Street = "4564 Elm St.";
				newUser15.City = "Austin";
				newUser15.State = "TX";
				newUser15.Zip = "78731";
				newUser15.PhoneNumber = "5124653365";
				newUser15.Birthday = Convert.ToDateTime("1983-04-04 00:00:00");


				var result = await _userManager.CreateAsync(newUser15, "whimsical");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser15 = _db.Users.FirstOrDefault(u => u.UserName == "mother.Ingram@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser15, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser15, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser16 = _db.Users.FirstOrDefault(u => u.Email == "victoria@aool.com");
			if (newUser16 == null)
			{
				newUser16 = new AppUser();
				newUser16.UserName = "victoria@aool.com";
				newUser16.Email = "victoria@aool.com";
				newUser16.FirstName = "Victoria";
				newUser16.LastName = "Lawrence";
				newUser16.MiddleInitial = 'M';
				newUser16.Street = "6639 Butterfly Ln.";
				newUser16.City = "Austin";
				newUser16.State = "TX";
				newUser16.Zip = "78761";
				newUser16.PhoneNumber = "5129457399";
				newUser16.Birthday = Convert.ToDateTime("1961-02-03 00:00:00");


				var result = await _userManager.CreateAsync(newUser16, "nothing");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser16 = _db.Users.FirstOrDefault(u => u.UserName == "victoria@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser16, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser16, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser17 = _db.Users.FirstOrDefault(u => u.Email == "lineback@flush.net");
			if (newUser17 == null)
			{
				newUser17 = new AppUser();
				newUser17.UserName = "lineback@flush.net";
				newUser17.Email = "lineback@flush.net";
				newUser17.FirstName = "Erik";
				newUser17.LastName = "Lineback";
				newUser17.MiddleInitial = 'W';
				newUser17.Street = "1300 Netherland St";
				newUser17.City = "San Antonio";
				newUser17.State = "TX";
				newUser17.Zip = "78293";
				newUser17.PhoneNumber = "2102449976";
				newUser17.Birthday = Convert.ToDateTime("1946-09-03 00:00:00");


				var result = await _userManager.CreateAsync(newUser17, "GoodFellow");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser17 = _db.Users.FirstOrDefault(u => u.UserName == "lineback@flush.net");
			}


			if (await _userManager.IsInRoleAsync(newUser17, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser17, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser18 = _db.Users.FirstOrDefault(u => u.Email == "elowe@netscrape.net");
			if (newUser18 == null)
			{
				newUser18 = new AppUser();
				newUser18.UserName = "elowe@netscrape.net";
				newUser18.Email = "elowe@netscrape.net";
				newUser18.FirstName = "Ernest";
				newUser18.LastName = "Lowe";
				newUser18.MiddleInitial = 'S';
				newUser18.Street = "3201 Pine Drive";
				newUser18.City = "San Antonio";
				newUser18.State = "TX";
				newUser18.Zip = "78279";
				newUser18.PhoneNumber = "2105344627";
				newUser18.Birthday = Convert.ToDateTime("1992-02-07 00:00:00");


				var result = await _userManager.CreateAsync(newUser18, "impede");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser18 = _db.Users.FirstOrDefault(u => u.UserName == "elowe@netscrape.net");
			}


			if (await _userManager.IsInRoleAsync(newUser18, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser18, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser19 = _db.Users.FirstOrDefault(u => u.Email == "luce_chuck@ggmail.com");
			if (newUser19 == null)
			{
				newUser19 = new AppUser();
				newUser19.UserName = "luce_chuck@ggmail.com";
				newUser19.Email = "luce_chuck@ggmail.com";
				newUser19.FirstName = "Chuck";
				newUser19.LastName = "Luce";
				newUser19.MiddleInitial = 'B';
				newUser19.Street = "2345 Rolling Clouds";
				newUser19.City = "San Antonio";
				newUser19.State = "TX";
				newUser19.Zip = "78268";
				newUser19.PhoneNumber = "2106983548";
				newUser19.Birthday = Convert.ToDateTime("1942-10-25 00:00:00");


				var result = await _userManager.CreateAsync(newUser19, "LuceyDucey");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser19 = _db.Users.FirstOrDefault(u => u.UserName == "luce_chuck@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser19, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser19, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser20 = _db.Users.FirstOrDefault(u => u.Email == "mackcloud@pimpdaddy.com");
			if (newUser20 == null)
			{
				newUser20 = new AppUser();
				newUser20.UserName = "mackcloud@pimpdaddy.com";
				newUser20.Email = "mackcloud@pimpdaddy.com";
				newUser20.FirstName = "Jennifer";
				newUser20.LastName = "MacLeod";
				newUser20.MiddleInitial = 'D';
				newUser20.Street = "2504 Far West Blvd.";
				newUser20.City = "Austin";
				newUser20.State = "TX";
				newUser20.Zip = "78731";
				newUser20.PhoneNumber = "5124748138";
				newUser20.Birthday = Convert.ToDateTime("1965-08-06 00:00:00");


				var result = await _userManager.CreateAsync(newUser20, "cloudyday");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser20 = _db.Users.FirstOrDefault(u => u.UserName == "mackcloud@pimpdaddy.com");
			}


			if (await _userManager.IsInRoleAsync(newUser20, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser20, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser21 = _db.Users.FirstOrDefault(u => u.Email == "liz@ggmail.com");
			if (newUser21 == null)
			{
				newUser21 = new AppUser();
				newUser21.UserName = "liz@ggmail.com";
				newUser21.Email = "liz@ggmail.com";
				newUser21.FirstName = "Elizabeth";
				newUser21.LastName = "Markham";
				newUser21.MiddleInitial = 'P';
				newUser21.Street = "7861 Chevy Chase";
				newUser21.City = "Austin";
				newUser21.State = "TX";
				newUser21.Zip = "78732";
				newUser21.PhoneNumber = "5124579845";
				newUser21.Birthday = Convert.ToDateTime("1959-04-13 00:00:00");


				var result = await _userManager.CreateAsync(newUser21, "emarkbark");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser21 = _db.Users.FirstOrDefault(u => u.UserName == "liz@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser21, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser21, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser22 = _db.Users.FirstOrDefault(u => u.Email == "mclarence@aool.com");
			if (newUser22 == null)
			{
				newUser22 = new AppUser();
				newUser22.UserName = "mclarence@aool.com";
				newUser22.Email = "mclarence@aool.com";
				newUser22.FirstName = "Clarence";
				newUser22.LastName = "Martin";
				newUser22.MiddleInitial = 'A';
				newUser22.Street = "87 Alcedo St.";
				newUser22.City = "Houston";
				newUser22.State = "TX";
				newUser22.Zip = "77045";
				newUser22.PhoneNumber = "8174955201";
				newUser22.Birthday = Convert.ToDateTime("1990-01-06 00:00:00");


				var result = await _userManager.CreateAsync(newUser22, "smartinmartin");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser22 = _db.Users.FirstOrDefault(u => u.UserName == "mclarence@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser22, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser22, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser23 = _db.Users.FirstOrDefault(u => u.Email == "smartinmartin.Martin@aool.com");
			if (newUser23 == null)
			{
				newUser23 = new AppUser();
				newUser23.UserName = "smartinmartin.Martin@aool.com";
				newUser23.Email = "smartinmartin.Martin@aool.com";
				newUser23.FirstName = "Gregory";
				newUser23.LastName = "Martinez";
				newUser23.MiddleInitial = 'R';
				newUser23.Street = "8295 Sunset Blvd.";
				newUser23.City = "Houston";
				newUser23.State = "TX";
				newUser23.Zip = "77030";
				newUser23.PhoneNumber = "8178746718";
				newUser23.Birthday = Convert.ToDateTime("1987-10-09 00:00:00");


				var result = await _userManager.CreateAsync(newUser23, "looter");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser23 = _db.Users.FirstOrDefault(u => u.UserName == "smartinmartin.Martin@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser23, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser23, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser24 = _db.Users.FirstOrDefault(u => u.Email == "cmiller@mapster.com");
			if (newUser24 == null)
			{
				newUser24 = new AppUser();
				newUser24.UserName = "cmiller@mapster.com";
				newUser24.Email = "cmiller@mapster.com";
				newUser24.FirstName = "Charles";
				newUser24.LastName = "Miller";
				newUser24.MiddleInitial = 'R';
				newUser24.Street = "8962 Main St.";
				newUser24.City = "Houston";
				newUser24.State = "TX";
				newUser24.Zip = "77031";
				newUser24.PhoneNumber = "8177458615";
				newUser24.Birthday = Convert.ToDateTime("1984-07-21 00:00:00");


				var result = await _userManager.CreateAsync(newUser24, "chucky33");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser24 = _db.Users.FirstOrDefault(u => u.UserName == "cmiller@mapster.com");
			}


			if (await _userManager.IsInRoleAsync(newUser24, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser24, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser25 = _db.Users.FirstOrDefault(u => u.Email == "nelson.Kelly@aool.com");
			if (newUser25 == null)
			{
				newUser25 = new AppUser();
				newUser25.UserName = "nelson.Kelly@aool.com";
				newUser25.Email = "nelson.Kelly@aool.com";
				newUser25.FirstName = "Kelly";
				newUser25.LastName = "Nelson";
				newUser25.MiddleInitial = 'T';
				newUser25.Street = "2601 Red River";
				newUser25.City = "Austin";
				newUser25.State = "TX";
				newUser25.Zip = "78703";
				newUser25.PhoneNumber = "5122926966";
				newUser25.Birthday = Convert.ToDateTime("1956-07-04 00:00:00");


				var result = await _userManager.CreateAsync(newUser25, "orange");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser25 = _db.Users.FirstOrDefault(u => u.UserName == "nelson.Kelly@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser25, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser25, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser26 = _db.Users.FirstOrDefault(u => u.Email == "jojoe@ggmail.com");
			if (newUser26 == null)
			{
				newUser26 = new AppUser();
				newUser26.UserName = "jojoe@ggmail.com";
				newUser26.Email = "jojoe@ggmail.com";
				newUser26.FirstName = "Joe";
				newUser26.LastName = "Nguyen";
				newUser26.MiddleInitial = 'C';
				newUser26.Street = "1249 4th SW St.";
				newUser26.City = "Dallas";
				newUser26.State = "TX";
				newUser26.Zip = "75238";
				newUser26.PhoneNumber = "2143125897";
				newUser26.Birthday = Convert.ToDateTime("1963-01-29 00:00:00");


				var result = await _userManager.CreateAsync(newUser26, "victorious");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser26 = _db.Users.FirstOrDefault(u => u.UserName == "jojoe@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser26, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser26, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser27 = _db.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com");
			if (newUser27 == null)
			{
				newUser27 = new AppUser();
				newUser27.UserName = "orielly@foxnets.com";
				newUser27.Email = "orielly@foxnets.com";
				newUser27.FirstName = "Bill";
				newUser27.LastName = "O'Reilly";
				newUser27.MiddleInitial = 'T';
				newUser27.Street = "8800 Gringo Drive";
				newUser27.City = "San Antonio";
				newUser27.State = "TX";
				newUser27.Zip = "78260";
				newUser27.PhoneNumber = "2103450925";
				newUser27.Birthday = Convert.ToDateTime("1983-01-07 00:00:00");


				var result = await _userManager.CreateAsync(newUser27, "billyboy");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser27 = _db.Users.FirstOrDefault(u => u.UserName == "orielly@foxnets.com");
			}


			if (await _userManager.IsInRoleAsync(newUser27, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser27, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser28 = _db.Users.FirstOrDefault(u => u.Email == "or@aool.com");
			if (newUser28 == null)
			{
				newUser28 = new AppUser();
				newUser28.UserName = "or@aool.com";
				newUser28.Email = "or@aool.com";
				newUser28.FirstName = "Anka";
				newUser28.LastName = "Radkovich";
				newUser28.MiddleInitial = 'L';
				newUser28.Street = "1300 Elliott Pl";
				newUser28.City = "Dallas";
				newUser28.State = "TX";
				newUser28.Zip = "75260";
				newUser28.PhoneNumber = "2142345566";
				newUser28.Birthday = Convert.ToDateTime("1980-03-31 00:00:00");


				var result = await _userManager.CreateAsync(newUser28, "radicalone");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser28 = _db.Users.FirstOrDefault(u => u.UserName == "or@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser28, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser28, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser29 = _db.Users.FirstOrDefault(u => u.Email == "megrhodes@freezing.co.uk");
			if (newUser29 == null)
			{
				newUser29 = new AppUser();
				newUser29.UserName = "megrhodes@freezing.co.uk";
				newUser29.Email = "megrhodes@freezing.co.uk";
				newUser29.FirstName = "Megan";
				newUser29.LastName = "Rhodes";
				newUser29.MiddleInitial = 'C';
				newUser29.Street = "4587 Enfield Rd.";
				newUser29.City = "Austin";
				newUser29.State = "TX";
				newUser29.Zip = "78707";
				newUser29.PhoneNumber = "5123744746";
				newUser29.Birthday = Convert.ToDateTime("1944-08-12 00:00:00");


				var result = await _userManager.CreateAsync(newUser29, "gohorns");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser29 = _db.Users.FirstOrDefault(u => u.UserName == "megrhodes@freezing.co.uk");
			}


			if (await _userManager.IsInRoleAsync(newUser29, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser29, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser30 = _db.Users.FirstOrDefault(u => u.Email == "erynrice@aool.com");
			if (newUser30 == null)
			{
				newUser30 = new AppUser();
				newUser30.UserName = "erynrice@aool.com";
				newUser30.Email = "erynrice@aool.com";
				newUser30.FirstName = "Eryn";
				newUser30.LastName = "Rice";
				newUser30.MiddleInitial = 'M';
				newUser30.Street = "3405 Rio Grande";
				newUser30.City = "Austin";
				newUser30.State = "TX";
				newUser30.Zip = "78705";
				newUser30.PhoneNumber = "5123876657";
				newUser30.Birthday = Convert.ToDateTime("1934-08-02 00:00:00");


				var result = await _userManager.CreateAsync(newUser30, "iloveme");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser30 = _db.Users.FirstOrDefault(u => u.UserName == "erynrice@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser30, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser30, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser31 = _db.Users.FirstOrDefault(u => u.Email == "jorge@hootmail.com");
			if (newUser31 == null)
			{
				newUser31 = new AppUser();
				newUser31.UserName = "jorge@hootmail.com";
				newUser31.Email = "jorge@hootmail.com";
				newUser31.FirstName = "Jorge";
				newUser31.LastName = "Rodriguez";
				newUser31.Street = "6788 Cotter Street";
				newUser31.City = "Houston";
				newUser31.State = "TX";
				newUser31.Zip = "77057";
				newUser31.PhoneNumber = "8178904374";
				newUser31.Birthday = Convert.ToDateTime("1989-08-11 00:00:00");


				var result = await _userManager.CreateAsync(newUser31, "greedy");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser31 = _db.Users.FirstOrDefault(u => u.UserName == "jorge@hootmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser31, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser31, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser32 = _db.Users.FirstOrDefault(u => u.Email == "ra@aoo.com");
			if (newUser32 == null)
			{
				newUser32 = new AppUser();
				newUser32.UserName = "ra@aoo.com";
				newUser32.Email = "ra@aoo.com";
				newUser32.FirstName = "Allen";
				newUser32.LastName = "Rogers";
				newUser32.MiddleInitial = 'B';
				newUser32.Street = "4965 Oak Hill";
				newUser32.City = "Austin";
				newUser32.State = "TX";
				newUser32.Zip = "78732";
				newUser32.PhoneNumber = "5128752943";
				newUser32.Birthday = Convert.ToDateTime("1967-08-27 00:00:00");


				var result = await _userManager.CreateAsync(newUser32, "familiar");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser32 = _db.Users.FirstOrDefault(u => u.UserName == "ra@aoo.com");
			}


			if (await _userManager.IsInRoleAsync(newUser32, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser32, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser33 = _db.Users.FirstOrDefault(u => u.Email == "st-jean@home.com");
			if (newUser33 == null)
			{
				newUser33 = new AppUser();
				newUser33.UserName = "st-jean@home.com";
				newUser33.Email = "st-jean@home.com";
				newUser33.FirstName = "Olivier";
				newUser33.LastName = "Saint-Jean";
				newUser33.MiddleInitial = 'M';
				newUser33.Street = "255 Toncray Dr.";
				newUser33.City = "San Antonio";
				newUser33.State = "TX";
				newUser33.Zip = "78292";
				newUser33.PhoneNumber = "2104145678";
				newUser33.Birthday = Convert.ToDateTime("1950-07-08 00:00:00");


				var result = await _userManager.CreateAsync(newUser33, "historical");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser33 = _db.Users.FirstOrDefault(u => u.UserName == "st-jean@home.com");
			}


			if (await _userManager.IsInRoleAsync(newUser33, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser33, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser34 = _db.Users.FirstOrDefault(u => u.Email == "ss34@ggmail.com");
			if (newUser34 == null)
			{
				newUser34 = new AppUser();
				newUser34.UserName = "ss34@ggmail.com";
				newUser34.Email = "ss34@ggmail.com";
				newUser34.FirstName = "Sarah";
				newUser34.LastName = "Saunders";
				newUser34.MiddleInitial = 'J';
				newUser34.Street = "332 Avenue C";
				newUser34.City = "Austin";
				newUser34.State = "TX";
				newUser34.Zip = "78705";
				newUser34.PhoneNumber = "5123497810";
				newUser34.Birthday = Convert.ToDateTime("1977-10-29 00:00:00");


				var result = await _userManager.CreateAsync(newUser34, "guiltless");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser34 = _db.Users.FirstOrDefault(u => u.UserName == "ss34@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser34, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser34, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser35 = _db.Users.FirstOrDefault(u => u.Email == "willsheff@email.com");
			if (newUser35 == null)
			{
				newUser35 = new AppUser();
				newUser35.UserName = "willsheff@email.com";
				newUser35.Email = "willsheff@email.com";
				newUser35.FirstName = "William";
				newUser35.LastName = "Sewell";
				newUser35.MiddleInitial = 'T';
				newUser35.Street = "2365 51st St.";
				newUser35.City = "Austin";
				newUser35.State = "TX";
				newUser35.Zip = "78709";
				newUser35.PhoneNumber = "5124510084";
				newUser35.Birthday = Convert.ToDateTime("1941-04-21 00:00:00");


				var result = await _userManager.CreateAsync(newUser35, "frequent");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser35 = _db.Users.FirstOrDefault(u => u.UserName == "willsheff@email.com");
			}


			if (await _userManager.IsInRoleAsync(newUser35, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser35, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser36 = _db.Users.FirstOrDefault(u => u.Email == "sheff44@ggmail.com");
			if (newUser36 == null)
			{
				newUser36 = new AppUser();
				newUser36.UserName = "sheff44@ggmail.com";
				newUser36.Email = "sheff44@ggmail.com";
				newUser36.FirstName = "Martin";
				newUser36.LastName = "Sheffield";
				newUser36.MiddleInitial = 'J';
				newUser36.Street = "3886 Avenue A";
				newUser36.City = "Austin";
				newUser36.State = "TX";
				newUser36.Zip = "78705";
				newUser36.PhoneNumber = "5125479167";
				newUser36.Birthday = Convert.ToDateTime("1937-11-10 00:00:00");


				var result = await _userManager.CreateAsync(newUser36, "history");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser36 = _db.Users.FirstOrDefault(u => u.UserName == "sheff44@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser36, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser36, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser37 = _db.Users.FirstOrDefault(u => u.Email == "johnsmith187@aool.com");
			if (newUser37 == null)
			{
				newUser37 = new AppUser();
				newUser37.UserName = "johnsmith187@aool.com";
				newUser37.Email = "johnsmith187@aool.com";
				newUser37.FirstName = "John";
				newUser37.LastName = "Smith";
				newUser37.MiddleInitial = 'A';
				newUser37.Street = "23 Hidden Forge Dr.";
				newUser37.City = "San Antonio";
				newUser37.State = "TX";
				newUser37.Zip = "78280";
				newUser37.PhoneNumber = "2108321888";
				newUser37.Birthday = Convert.ToDateTime("1954-10-26 00:00:00");


				var result = await _userManager.CreateAsync(newUser37, "squirrel");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser37 = _db.Users.FirstOrDefault(u => u.UserName == "johnsmith187@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser37, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser37, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser38 = _db.Users.FirstOrDefault(u => u.Email == "dustroud@mail.com");
			if (newUser38 == null)
			{
				newUser38 = new AppUser();
				newUser38.UserName = "dustroud@mail.com";
				newUser38.Email = "dustroud@mail.com";
				newUser38.FirstName = "Dustin";
				newUser38.LastName = "Stroud";
				newUser38.MiddleInitial = 'P';
				newUser38.Street = "1212 Rita Rd";
				newUser38.City = "Dallas";
				newUser38.State = "TX";
				newUser38.Zip = "75221";
				newUser38.PhoneNumber = "2142346667";
				newUser38.Birthday = Convert.ToDateTime("1932-09-01 00:00:00");


				var result = await _userManager.CreateAsync(newUser38, "snakes");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser38 = _db.Users.FirstOrDefault(u => u.UserName == "dustroud@mail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser38, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser38, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser39 = _db.Users.FirstOrDefault(u => u.Email == "ericstuart@aool.com");
			if (newUser39 == null)
			{
				newUser39 = new AppUser();
				newUser39.UserName = "ericstuart@aool.com";
				newUser39.Email = "ericstuart@aool.com";
				newUser39.FirstName = "Eric";
				newUser39.LastName = "Stuart";
				newUser39.MiddleInitial = 'D';
				newUser39.Street = "5576 Toro Ring";
				newUser39.City = "Austin";
				newUser39.State = "TX";
				newUser39.Zip = "78746";
				newUser39.PhoneNumber = "5128178335";
				newUser39.Birthday = Convert.ToDateTime("1930-12-28 00:00:00");


				var result = await _userManager.CreateAsync(newUser39, "landus");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser39 = _db.Users.FirstOrDefault(u => u.UserName == "ericstuart@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser39, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser39, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser40 = _db.Users.FirstOrDefault(u => u.Email == "peterstump@hootmail.com");
			if (newUser40 == null)
			{
				newUser40 = new AppUser();
				newUser40.UserName = "peterstump@hootmail.com";
				newUser40.Email = "peterstump@hootmail.com";
				newUser40.FirstName = "Peter";
				newUser40.LastName = "Stump";
				newUser40.MiddleInitial = 'L';
				newUser40.Street = "1300 Kellen Circle";
				newUser40.City = "Houston";
				newUser40.State = "TX";
				newUser40.Zip = "77018";
				newUser40.PhoneNumber = "8174560903";
				newUser40.Birthday = Convert.ToDateTime("1989-08-13 00:00:00");


				var result = await _userManager.CreateAsync(newUser40, "rhythm");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser40 = _db.Users.FirstOrDefault(u => u.UserName == "peterstump@hootmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser40, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser40, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser41 = _db.Users.FirstOrDefault(u => u.Email == "tanner@ggmail.com");
			if (newUser41 == null)
			{
				newUser41 = new AppUser();
				newUser41.UserName = "tanner@ggmail.com";
				newUser41.Email = "tanner@ggmail.com";
				newUser41.FirstName = "Jeremy";
				newUser41.LastName = "Tanner";
				newUser41.MiddleInitial = 'S';
				newUser41.Street = "4347 Almstead";
				newUser41.City = "Houston";
				newUser41.State = "TX";
				newUser41.Zip = "77044";
				newUser41.PhoneNumber = "8174590929";
				newUser41.Birthday = Convert.ToDateTime("1982-05-21 00:00:00");


				var result = await _userManager.CreateAsync(newUser41, "kindly");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser41 = _db.Users.FirstOrDefault(u => u.UserName == "tanner@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser41, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser41, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser42 = _db.Users.FirstOrDefault(u => u.Email == "taylordjay@aool.com");
			if (newUser42 == null)
			{
				newUser42 = new AppUser();
				newUser42.UserName = "taylordjay@aool.com";
				newUser42.Email = "taylordjay@aool.com";
				newUser42.FirstName = "Allison";
				newUser42.LastName = "Taylor";
				newUser42.MiddleInitial = 'R';
				newUser42.Street = "467 Nueces St.";
				newUser42.City = "Austin";
				newUser42.State = "TX";
				newUser42.Zip = "78705";
				newUser42.PhoneNumber = "5124748452";
				newUser42.Birthday = Convert.ToDateTime("1960-01-08 00:00:00");


				var result = await _userManager.CreateAsync(newUser42, "instrument");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser42 = _db.Users.FirstOrDefault(u => u.UserName == "taylordjay@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser42, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser42, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser43 = _db.Users.FirstOrDefault(u => u.Email == "TayTaylor@aool.com");
			if (newUser43 == null)
			{
				newUser43 = new AppUser();
				newUser43.UserName = "TayTaylor@aool.com";
				newUser43.Email = "TayTaylor@aool.com";
				newUser43.FirstName = "Rachel";
				newUser43.LastName = "Taylor";
				newUser43.MiddleInitial = 'K';
				newUser43.Street = "345 Longview Dr.";
				newUser43.City = "Austin";
				newUser43.State = "TX";
				newUser43.Zip = "78705";
				newUser43.PhoneNumber = "5124512631";
				newUser43.Birthday = Convert.ToDateTime("1975-07-27 00:00:00");


				var result = await _userManager.CreateAsync(newUser43, "arched");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser43 = _db.Users.FirstOrDefault(u => u.UserName == "TayTaylor@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser43, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser43, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser44 = _db.Users.FirstOrDefault(u => u.Email == "teefrank@hootmail.com");
			if (newUser44 == null)
			{
				newUser44 = new AppUser();
				newUser44.UserName = "teefrank@hootmail.com";
				newUser44.Email = "teefrank@hootmail.com";
				newUser44.FirstName = "Frank";
				newUser44.LastName = "Tee";
				newUser44.MiddleInitial = 'J';
				newUser44.Street = "5590 Lavell Dr";
				newUser44.City = "Houston";
				newUser44.State = "TX";
				newUser44.Zip = "77004";
				newUser44.PhoneNumber = "8178765543";
				newUser44.Birthday = Convert.ToDateTime("1968-04-06 00:00:00");


				var result = await _userManager.CreateAsync(newUser44, "median");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser44 = _db.Users.FirstOrDefault(u => u.UserName == "teefrank@hootmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser44, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser44, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser45 = _db.Users.FirstOrDefault(u => u.Email == "tuck33@ggmail.com");
			if (newUser45 == null)
			{
				newUser45 = new AppUser();
				newUser45.UserName = "tuck33@ggmail.com";
				newUser45.Email = "tuck33@ggmail.com";
				newUser45.FirstName = "Clent";
				newUser45.LastName = "Tucker";
				newUser45.MiddleInitial = 'J';
				newUser45.Street = "312 Main St.";
				newUser45.City = "Dallas";
				newUser45.State = "TX";
				newUser45.Zip = "75315";
				newUser45.PhoneNumber = "2148471154";
				newUser45.Birthday = Convert.ToDateTime("1978-05-19 00:00:00");


				var result = await _userManager.CreateAsync(newUser45, "approval");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser45 = _db.Users.FirstOrDefault(u => u.UserName == "tuck33@ggmail.com");
			}


			if (await _userManager.IsInRoleAsync(newUser45, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser45, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser46 = _db.Users.FirstOrDefault(u => u.Email == "avelasco@yaho.com");
			if (newUser46 == null)
			{
				newUser46 = new AppUser();
				newUser46.UserName = "avelasco@yaho.com";
				newUser46.Email = "avelasco@yaho.com";
				newUser46.FirstName = "Allen";
				newUser46.LastName = "Velasco";
				newUser46.MiddleInitial = 'G';
				newUser46.Street = "679 W. 4th";
				newUser46.City = "Dallas";
				newUser46.State = "TX";
				newUser46.Zip = "75207";
				newUser46.PhoneNumber = "2143985638";
				newUser46.Birthday = Convert.ToDateTime("1963-10-06 00:00:00");


				var result = await _userManager.CreateAsync(newUser46, "decorate");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser46 = _db.Users.FirstOrDefault(u => u.UserName == "avelasco@yaho.com");
			}


			if (await _userManager.IsInRoleAsync(newUser46, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser46, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser47 = _db.Users.FirstOrDefault(u => u.Email == "westj@pioneer.net");
			if (newUser47 == null)
			{
				newUser47 = new AppUser();
				newUser47.UserName = "westj@pioneer.net";
				newUser47.Email = "westj@pioneer.net";
				newUser47.FirstName = "Jake";
				newUser47.LastName = "West";
				newUser47.MiddleInitial = 'T';
				newUser47.Street = "RR 3287";
				newUser47.City = "Dallas";
				newUser47.State = "TX";
				newUser47.Zip = "75323";
				newUser47.PhoneNumber = "2148475244";
				newUser47.Birthday = Convert.ToDateTime("1993-10-14 00:00:00");


				var result = await _userManager.CreateAsync(newUser47, "grover");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser47 = _db.Users.FirstOrDefault(u => u.UserName == "westj@pioneer.net");
			}


			if (await _userManager.IsInRoleAsync(newUser47, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser47, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser48 = _db.Users.FirstOrDefault(u => u.Email == "louielouie@aool.com");
			if (newUser48 == null)
			{
				newUser48 = new AppUser();
				newUser48.UserName = "louielouie@aool.com";
				newUser48.Email = "louielouie@aool.com";
				newUser48.FirstName = "Louis";
				newUser48.LastName = "Winthorpe";
				newUser48.MiddleInitial = 'L';
				newUser48.Street = "2500 Padre Blvd";
				newUser48.City = "Dallas";
				newUser48.State = "TX";
				newUser48.Zip = "75220";
				newUser48.PhoneNumber = "2145650098";
				newUser48.Birthday = Convert.ToDateTime("1952-05-31 00:00:00");


				var result = await _userManager.CreateAsync(newUser48, "sturdy");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser48 = _db.Users.FirstOrDefault(u => u.UserName == "louielouie@aool.com");
			}


			if (await _userManager.IsInRoleAsync(newUser48, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser48, "Customer");
			}

			_db.SaveChanges();



			AppUser newUser49 = _db.Users.FirstOrDefault(u => u.Email == "rwood@voyager.net");
			if (newUser49 == null)
			{
				newUser49 = new AppUser();
				newUser49.UserName = "rwood@voyager.net";
				newUser49.Email = "rwood@voyager.net";
				newUser49.FirstName = "Reagan";
				newUser49.LastName = "Wood";
				newUser49.MiddleInitial = 'B';
				newUser49.Street = "447 Westlake Dr.";
				newUser49.City = "Austin";
				newUser49.State = "TX";
				newUser49.Zip = "78746";
				newUser49.PhoneNumber = "5124545242";
				newUser49.Birthday = Convert.ToDateTime("1992-04-24 00:00:00");


				var result = await _userManager.CreateAsync(newUser49, "decorous");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser49 = _db.Users.FirstOrDefault(u => u.UserName == "rwood@voyager.net");
			}


			if (await _userManager.IsInRoleAsync(newUser49, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser49, "Customer");
			}

			_db.SaveChanges();



		}
	}
}