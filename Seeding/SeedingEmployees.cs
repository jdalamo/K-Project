using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;


namespace fa19projectgroup16.Seeding
{
	public static class SeedingEmployees
	{
		public static async Task AddEmployee(IServiceProvider serviceProvider)
		{
			AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
			UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
			RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


			if (await _roleManager.RoleExistsAsync("Employee") == false)
			{
				await _roleManager.CreateAsync(new IdentityRole("Employee"));
			}


			AppUser newUser1 = _db.Users.FirstOrDefault(u => u.Email == "t.jacobs@longhornbank.neet");
			if (newUser1 == null)
			{
				newUser1 = new AppUser();
				newUser1.UserName = "t.jacobs@longhornbank.neet";
				newUser1.Email = "t.jacobs@longhornbank.neet";
				newUser1.FirstName = "Todd";
				newUser1.LastName = "Jacobs";
				newUser1.MiddleInitial = 'L';
				newUser1.SSN = "222222222";
				newUser1.Street = "4564 Elm St.";
				newUser1.City = "Houston";
				newUser1.State = "TX";
				newUser1.Zip = "77003";
                newUser1.PhoneNumber = "8176593544";
				newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


				var result = await _userManager.CreateAsync(newUser1, "society");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - " + result.ToString());
				}

				_db.SaveChanges();
				newUser1 = _db.Users.FirstOrDefault(u => u.UserName == "t.jacobs@longhornbank.neet");
			}


			if (await _userManager.IsInRoleAsync(newUser1, "Employee") == false)
			{
				await _userManager.AddToRoleAsync(newUser1, "Employee");
			}

			_db.SaveChanges();



            AppUser newUser2 = _db.Users.FirstOrDefault(u => u.Email == "e.rice@longhornbank.neet");
            if (newUser2 == null)
            {
                newUser2 = new AppUser();
                newUser2.UserName = "e.rice@longhornbank.neet";
                newUser2.Email = "e.rice@longhornbank.neet";
                newUser2.FirstName = "Eryn";
                newUser2.LastName = "Rice";
                newUser2.MiddleInitial = 'M';
                newUser2.SSN = "111111111";
                newUser2.Street = "3405 Rio Grande";
                newUser2.City = "Dallas";
                newUser2.State = "TX";
                newUser2.Zip = "75261";
                newUser2.PhoneNumber = "2148475583";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser2, "ricearoni");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser2 = _db.Users.FirstOrDefault(u => u.UserName == "e.rice@longhornbank.neet");
            }


            if (await _userManager.IsInRoleAsync(newUser2, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(newUser2, "Employee");
            }


            _db.SaveChanges();



            AppUser newUser3 = _db.Users.FirstOrDefault(u => u.Email == "b.ingram@longhornbank.neet");
            if (newUser3 == null)
            {
                newUser3 = new AppUser();
                newUser3.UserName = "b.ingram@longhornbank.neet";
                newUser3.Email = "b.ingram@longhornbank.neet";
                newUser3.FirstName = "Brad";
                newUser3.LastName = "Ingram";
                newUser3.MiddleInitial = 'S';
                newUser3.SSN = "545454545";
                newUser3.Street = "6548 La Posada Ct.";
                newUser3.City = "Austin";
                newUser3.State = "TX";
                newUser3.Zip = "78705";
                newUser3.PhoneNumber = "5126978613";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser3, "ingram45");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser3 = _db.Users.FirstOrDefault(u => u.UserName == "b.ingram@longhornbank.neet");
            }


            if (await _userManager.IsInRoleAsync(newUser3, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(newUser3, "Employee");
            }


            _db.SaveChanges();



            AppUser newUser4 = _db.Users.FirstOrDefault(u => u.Email == "a.taylor@longhornbank.neet");
            if (newUser4 == null)
            {
                newUser4 = new AppUser();
                newUser4.UserName = "a.taylor@longhornbank.neet";
                newUser4.Email = "a.taylor@longhornbank.neet";
                newUser4.FirstName = "Allison";
                newUser4.LastName = "Taylor";
                newUser4.MiddleInitial = 'R';
                newUser4.SSN = "645889563";
                newUser4.Street = "467 Nueces St.";
                newUser4.City = "Dallas";
                newUser4.State = "TX";
                newUser4.Zip = "75237";
                newUser4.PhoneNumber = "2148965621";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser4, "nostalgic");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser4 = _db.Users.FirstOrDefault(u => u.UserName == "a.taylor@longhornbank.neet");
            }


            if (await _userManager.IsInRoleAsync(newUser4, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser4, "Manager");
            }

            _db.SaveChanges();



            AppUser newUser5 = _db.Users.FirstOrDefault(u => u.Email == "g.martinez@longhornbank.neet");
            if (newUser5 == null)
            {
                newUser5 = new AppUser();
                newUser5.UserName = "g.martinez@longhornbank.neet";
                newUser5.Email = "g.martinez@longhornbank.neet";
                newUser5.FirstName = "Gregory";
                newUser5.LastName = "Martinez";
                newUser5.MiddleInitial = 'R';
                newUser5.SSN = "574677829";
                newUser5.Street = "8295 Sunset Blvd.";
                newUser5.City = "San Antonio";
                newUser5.State = "TX";
                newUser5.Zip = "78239";
                newUser5.PhoneNumber = "2105788965";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser5, "fungus");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser5 = _db.Users.FirstOrDefault(u => u.UserName == "g.martinez@longhornbank.neet");
            }

            if (await _userManager.IsInRoleAsync(newUser5, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(newUser5, "Employee");
            }


            _db.SaveChanges();



            AppUser newUser6 = _db.Users.FirstOrDefault(u => u.Email == "m.sheffield@longhornbank.neet");
            if (newUser6 == null)
            {
                newUser6 = new AppUser();
                newUser6.UserName = "m.sheffield@longhornbank.neet";
                newUser6.Email = "m.sheffield@longhornbank.neet";
                newUser6.FirstName = "Martin";
                newUser6.LastName = "Sheffield";
                newUser6.MiddleInitial = 'J';
                newUser6.SSN = "334557278";
                newUser6.Street = "3886 Avenue A";
                newUser6.City = "Austin";
                newUser6.State = "TX";
                newUser6.Zip = "78736";
                newUser6.PhoneNumber = "5124678821";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser6, "longhorns");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser6 = _db.Users.FirstOrDefault(u => u.UserName == "m.sheffield@longhornbank.neet");
            }

            if (await _userManager.IsInRoleAsync(newUser6, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser6, "Manager");
            }

            _db.SaveChanges();



            AppUser newUser7 = _db.Users.FirstOrDefault(u => u.Email == "j.macleod@longhornbank.neet");
            if (newUser7 == null)
            {
                newUser7 = new AppUser();
                newUser7.UserName = "j.macleod@longhornbank.neet";
                newUser7.Email = "j.macleod@longhornbank.neet";
                newUser7.FirstName = "Jennifer";
                newUser7.LastName = "MacLeod";
                newUser7.MiddleInitial = 'D';
                newUser7.SSN = "886719249";
                newUser7.Street = "2504 Far West Blvd.";
                newUser7.City = "Austin";
                newUser7.State = "TX";
                newUser7.Zip = "78731";
                newUser7.PhoneNumber = "5124653365";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser7, "smitty");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser7 = _db.Users.FirstOrDefault(u => u.UserName == "j.macleod@longhornbank.neet");
            }


            if (await _userManager.IsInRoleAsync(newUser7, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser7, "Manager");
            }

            _db.SaveChanges();



            AppUser newUser8 = _db.Users.FirstOrDefault(u => u.Email == "j.tanner@longhornbank.neet");
            if (newUser8 == null)
            {
                newUser8 = new AppUser();
                newUser8.UserName = "j.tanner@longhornbank.neet";
                newUser8.Email = "j.tanner@longhornbank.neet";
                newUser8.FirstName = "Jeremy";
                newUser8.LastName = "Tanner";
                newUser8.MiddleInitial = 'S';
                newUser8.SSN = "888887878";
                newUser8.Street = "4347 Almstead";
                newUser8.City = "Austin";
                newUser8.State = "TX";
                newUser8.Zip = "78761";
                newUser8.PhoneNumber = "5129457399";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser8, "tanman");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser8 = _db.Users.FirstOrDefault(u => u.UserName == "j.tanner@longhornbank.neet");
            }


            if (await _userManager.IsInRoleAsync(newUser8, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(newUser8, "Employee");
            }

            _db.SaveChanges();



            AppUser newUser9 = _db.Users.FirstOrDefault(u => u.Email == "m.rhodes@longhornbank.neet");
            if (newUser9 == null)
            {
                newUser9 = new AppUser();
                newUser9.UserName = "m.rhodes@longhornbank.neet";
                newUser9.Email = "m.rhodes@longhornbank.neet";
                newUser9.FirstName = "Megan";
                newUser9.LastName = "Rhodes";
                newUser9.MiddleInitial = 'C';
                newUser9.SSN = "999990909";
                newUser9.Street = "4587 Enfield Rd.";
                newUser9.City = "San Antonio";
                newUser9.State = "TX";
                newUser9.Zip = "78293";
                newUser9.PhoneNumber = "2102449976";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser9, "countryrhodes");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser9 = _db.Users.FirstOrDefault(u => u.UserName == "m.rhodes@longhornbank.neet");
            }


            if (await _userManager.IsInRoleAsync(newUser9, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser9, "Manager");
            }

            _db.SaveChanges();



            AppUser newUser10 = _db.Users.FirstOrDefault(u => u.Email == "e.stuart@longhornbank.neet");
            if (newUser10 == null)
            {
                newUser10 = new AppUser();
                newUser10.UserName = "e.stuart@longhornbank.neet";
                newUser10.Email = "e.stuart@longhornbank.neet";
                newUser10.FirstName = "Eric";
                newUser10.LastName = "Stuart";
                newUser10.MiddleInitial = 'F';
                newUser10.SSN = "212121212";
                newUser10.Street = "5576 Toro Ring";
                newUser10.City = "San Antonio";
                newUser10.State = "TX";
                newUser10.Zip = "78279";
                newUser10.PhoneNumber = "2105344627";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser10, "stewboy");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser10 = _db.Users.FirstOrDefault(u => u.UserName == "e.stuart@longhornbank.neet");
            }

            if (await _userManager.IsInRoleAsync(newUser10, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser10, "Manager");
            }

            _db.SaveChanges();


            AppUser newUser11 = _db.Users.FirstOrDefault(u => u.Email == "l.chung@longhornbank.neet");
            if (newUser11 == null)
            {
                newUser11 = new AppUser();
                newUser11.UserName = "l.chung@longhornbank.neet";
                newUser11.Email = "l.chung@longhornbank.neet";
                newUser11.FirstName = "Lisa";
                newUser11.LastName = "Chung";
                newUser11.MiddleInitial = 'N';
                newUser11.SSN = "333333333";
                newUser11.Street = "234 RR 12";
                newUser11.City = "San Antonio";
                newUser11.State = "TX";
                newUser11.Zip = "78268";
                newUser11.PhoneNumber = "2106983548";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser11, "lisssa");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser11 = _db.Users.FirstOrDefault(u => u.UserName == "l.chung@longhornbank.neet");
            }

            if (await _userManager.IsInRoleAsync(newUser11, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(newUser11, "Employee");
            }

            _db.SaveChanges();



            AppUser newUser12 = _db.Users.FirstOrDefault(u => u.Email == "l.swanson@longhornbank.neet");
            if (newUser12 == null)
            {
                newUser12 = new AppUser();
                newUser12.UserName = "l.swanson@longhornbank.neet";
                newUser12.Email = "l.swanson@longhornbank.neet";
                newUser12.FirstName = "Leon";
                newUser12.LastName = "Swanson";
                newUser12.SSN = "444444444";
                newUser12.Street = "245 River Rd";
                newUser12.City = "Austin";
                newUser12.State = "TX";
                newUser12.Zip = "78731";
                newUser12.PhoneNumber = "5124748138";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser12, "swansong");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser12 = _db.Users.FirstOrDefault(u => u.UserName == "l.swanson@longhornbank.neet");
            }

            if (await _userManager.IsInRoleAsync(newUser12, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser12, "Manager");
            }


            _db.SaveChanges();



            AppUser newUser13 = _db.Users.FirstOrDefault(u => u.Email == "w.loter@longhornbank.neet");
            if (newUser13 == null)
            {
                newUser13 = new AppUser();
                newUser13.UserName = "w.loter@longhornbank.neet";
                newUser13.Email = "w.loter@longhornbank.neet";
                newUser13.FirstName = "Wanda";
                newUser13.LastName = "Loter";
                newUser13.MiddleInitial = 'K';
                newUser13.SSN = "555555555";
                newUser13.Street = "3453 RR 3235";
                newUser13.City = "Austin";
                newUser13.State = "TX";
                newUser13.Zip = "78732";
                newUser13.PhoneNumber = "5124579845";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser13, "lottery");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser13 = _db.Users.FirstOrDefault(u => u.UserName == "w.loter@longhornbank.neet");
            }


            if (await _userManager.IsInRoleAsync(newUser13, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(newUser13, "Employee");
            }

            _db.SaveChanges();



            AppUser newUser14 = _db.Users.FirstOrDefault(u => u.Email == "j.white@longhornbank.neet");
            if (newUser14 == null)
            {
                newUser14 = new AppUser();
                newUser14.UserName = "j.white@longhornbank.neet";
                newUser14.Email = "j.white@longhornbank.neet";
                newUser14.FirstName = "Jason";
                newUser14.LastName = "White";
                newUser14.MiddleInitial = 'M';
                newUser14.SSN = "666666666";
                newUser14.Street = "12 Valley View";
                newUser14.City = "Houston";
                newUser14.State = "TX";
                newUser14.Zip = "77045";
                newUser14.PhoneNumber = "8174955201";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser14, "evanescent");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser14 = _db.Users.FirstOrDefault(u => u.UserName == "j.white@longhornbank.neet");
            }

            if (await _userManager.IsInRoleAsync(newUser14, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser14, "Manager");
            }

            _db.SaveChanges();



            AppUser newUser15 = _db.Users.FirstOrDefault(u => u.Email == "w.montgomery@longhornbank.neet");
            if (newUser15 == null)
            {
                newUser15 = new AppUser();
                newUser15.UserName = "w.montgomery@longhornbank.neet";
                newUser15.Email = "w.montgomery@longhornbank.neet";
                newUser15.FirstName = "Wilda";
                newUser15.LastName = "Montgomery";
                newUser15.MiddleInitial = 'K';
                newUser15.SSN = "676767676";
                newUser15.Street = "210 Blanco Dr";
                newUser15.City = "Houston";
                newUser15.State = "TX";
                newUser15.Zip = "77030";
                newUser15.PhoneNumber = "8178746718";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser15, "monty3");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser15 = _db.Users.FirstOrDefault(u => u.UserName == "w.montgomery@longhornbank.neet");
            }

            if (await _userManager.IsInRoleAsync(newUser15, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser15, "Manager");
            }

            _db.SaveChanges();



            AppUser newUser16 = _db.Users.FirstOrDefault(u => u.Email == "h.morales@longhornbank.neet");
            if (newUser16 == null)
            {
                newUser16 = new AppUser();
                newUser16.UserName = "h.morales@longhornbank.neet";
                newUser16.Email = "h.morales@longhornbank.neet";
                newUser16.FirstName = "Hector";
                newUser16.LastName = "Morales";
                newUser16.MiddleInitial = 'N';
                newUser16.SSN = "898989898";
                newUser16.Street = "4501 RR 140";
                newUser16.City = "Houston";
                newUser16.State = "TX";
                newUser16.Zip = "77031";
                newUser16.PhoneNumber = "8177458615";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser16, "hecktour");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser16 = _db.Users.FirstOrDefault(u => u.UserName == "h.morales@longhornbank.neet");
            }


            if (await _userManager.IsInRoleAsync(newUser16, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(newUser16, "Employee");
            }

            _db.SaveChanges();



            AppUser newUser17 = _db.Users.FirstOrDefault(u => u.Email == "m.rankin@longhornbank.neet");
            if (newUser17 == null)
            {
                newUser17 = new AppUser();
                newUser17.UserName = "m.rankin@longhornbank.neet";
                newUser17.Email = "m.rankin@longhornbank.neet";
                newUser17.FirstName = "Mary";
                newUser17.LastName = "Rankin";
                newUser17.MiddleInitial = 'T';
                newUser17.SSN = "999888777";
                newUser17.Street = "340 Second St";
                newUser17.City = "Austin";
                newUser17.State = "TX";
                newUser17.Zip = "78703";
                newUser17.PhoneNumber = "5122926966";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser17, "rankmary");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser17 = _db.Users.FirstOrDefault(u => u.UserName == "m.rankin@longhornbank.neet");
            }

            if (await _userManager.IsInRoleAsync(newUser17, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(newUser17, "Employee");
            }

            _db.SaveChanges();



            AppUser newUser18 = _db.Users.FirstOrDefault(u => u.Email == "l.walker@longhornbank.neet");
            if (newUser18 == null)
            {
                newUser18 = new AppUser();
                newUser18.UserName = "l.walker@longhornbank.neet";
                newUser18.Email = "l.walker@longhornbank.neet";
                newUser18.FirstName = "Larry";
                newUser18.LastName = "Walker";
                newUser18.MiddleInitial = 'G';
                newUser18.SSN = "323232323";
                newUser18.Street = "9 Bison Circle";
                newUser18.City = "Dallas";
                newUser18.State = "TX";
                newUser18.Zip = "75238";
                newUser18.PhoneNumber = "2143125897";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser18, "walkamile");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser18 = _db.Users.FirstOrDefault(u => u.UserName == "l.walker@longhornbank.neet");
            }

            if (await _userManager.IsInRoleAsync(newUser18, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser18, "Manager");
            }

            _db.SaveChanges();



            AppUser newUser19 = _db.Users.FirstOrDefault(u => u.Email == "g.chang@longhornbank.neet");
            if (newUser19 == null)
            {
                newUser19 = new AppUser();
                newUser19.UserName = "g.chang@longhornbank.neet";
                newUser19.Email = "g.chang@longhornbank.neet";
                newUser19.FirstName = "George";
                newUser19.LastName = "Chang";
                newUser19.MiddleInitial = 'M';
                newUser19.SSN = "111222233";
                newUser19.Street = "9003 Joshua St";
                newUser19.City = "San Antonio";
                newUser19.State = "TX";
                newUser19.Zip = "78260";
                newUser19.PhoneNumber = "2103450925";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser19, "changalang");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser19 = _db.Users.FirstOrDefault(u => u.UserName == "g.chang@longhornbank.neet");
            }


            if (await _userManager.IsInRoleAsync(newUser19, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(newUser19, "Manager");
            }

            _db.SaveChanges();



            AppUser newUser20 = _db.Users.FirstOrDefault(u => u.Email == "g.gonzalez@longhornbank.neet");
            if (newUser20 == null)
            {
                newUser20 = new AppUser();
                newUser20.UserName = "g.gonzalez@longhornbank.neet";
                newUser20.Email = "g.gonzalez@longhornbank.neet";
                newUser20.FirstName = "Gwen";
                newUser20.LastName = "Gonzalez";
                newUser20.MiddleInitial = 'J';
                newUser20.SSN = "499551454";
                newUser20.Street = "103 Manor Rd";
                newUser20.City = "Dallas";
                newUser20.State = "TX";
                newUser20.Zip = "75260";
                newUser20.PhoneNumber = "2142345566";
                newUser1.Is_Employed = true;
                newUser1.Is_enabled = true;


                var result = await _userManager.CreateAsync(newUser20, "offbeat");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }

                _db.SaveChanges();
                newUser20 = _db.Users.FirstOrDefault(u => u.UserName == "g.gonzalez@longhornbank.neet");
            }


            if (await _userManager.IsInRoleAsync(newUser20, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(newUser20, "Employee");
            }

            _db.SaveChanges();



        }
	}
}