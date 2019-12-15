using fa19projectgroup16.Models;
using fa19projectgroup16.DAL;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace fa19projectgroup16.Seeding
{
	public static class SeedPayees
	{
		public static void SeedAllPayees(IServiceProvider service)
		{
            AppDbContext db = service.GetRequiredService<AppDbContext>();

            List<Payee> Payees = new List<Payee>();

			Payee p1 = new Payee()
			{
				PayeeName = "City of Austin Water",
				PhoneNumber = "5126645558",
				PayeeType = PayeeType.Utilities,
				Street = "113 South Congress Ave.",
				City = "Austin",
				State = "TX",
				Zip = "78710",
			};
			Payees.Add(p1);

			Payee p2 = new Payee()
			{
				PayeeName = "Reliant Energy",
				PhoneNumber = "7135546697",
				PayeeType = PayeeType.Utilities,
				Street = "3500 E. Interstate 10",
				City = "Houston",
				State = "TX",
				Zip = "77099",
			};
			Payees.Add(p2);

			Payee p3 = new Payee()
			{
				PayeeName = "Lee Properties",
				PhoneNumber = "5124453312",
				PayeeType = PayeeType.Rent,
				Street = "2500 Salado",
				City = "Austin",
				State = "TX",
				Zip = "78705",
			};
			Payees.Add(p3);

			Payee p4 = new Payee()
			{
				PayeeName = "Capital One",
				PhoneNumber = "5302215542",
				PayeeType = PayeeType.Credit_Card,
				Street = "1299 Fargo Blvd.",
				City = "Cheyenne",
				State = "WY",
				Zip = "82001",
			};
			Payees.Add(p4);

			Payee p5 = new Payee()
			{
				PayeeName = "Vanguard Title",
				PhoneNumber = "5128654951",
				PayeeType = PayeeType.Mortgage,
				Street = "10976 Interstate 35 South",
				City = "Austin",
				State = "TX",
				Zip = "78745",
			};
			Payees.Add(p5);

			Payee p6 = new Payee()
			{
				PayeeName = "Lawn Care of Texas",
				PhoneNumber = "5123365247",
				PayeeType = PayeeType.Other,
				Street = "4473 W. 3rd Street",
				City = "Austin",
				State = "TX",
				Zip = "78712",
			};
			Payees.Add(p6);

			foreach (Payee payee in Payees)
			{
				db.Payees.Add(payee);
				db.SaveChanges();
			}
		}
	}
}