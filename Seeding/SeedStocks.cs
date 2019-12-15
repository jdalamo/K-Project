using fa19projectgroup16.DAL;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace fa19projectgroup16.Seeding
{
	public static class SeedStocks
	{
		public static void SeedAllStocks(IServiceProvider service)
		{
            AppDbContext db = service.GetRequiredService<AppDbContext>();
            List<Stock> Stocks = new List<Stock>();

			Stock s1 = new Stock()
			{
				StockName = "Alphabet Inc.",
				StockTicker = "GOOGL",
				StockPrice = 1315.2m,
                StockFee = 25m,
				StockType = StockType.Ordinary,
			};
			Stocks.Add(s1);

			Stock s2 = new Stock()
			{
				StockName = "Apple Inc.",
				StockTicker = "AAPL",
				StockPrice = 266.095m,
                StockFee = 40m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s2);

			Stock s3 = new Stock()
			{
				StockName = "Amazon.com Inc.",
				StockTicker = "AMZN",
				StockPrice = 1755.03m,
                StockFee = 15m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s3);

			Stock s4 = new Stock()
			{
				StockName = "Southwest Airlines",
				StockTicker = "LUV",
				StockPrice = 57.695m,
                StockFee = 35m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s4);

			Stock s5 = new Stock()
			{
				StockName = "Texas Instruments",
				StockTicker = "TXN",
				StockPrice = 117.89m,
                StockFee = 15m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s5);

			Stock s6 = new Stock()
			{
				StockName = "The Hershey Company",
				StockTicker = "HSY",
				StockPrice = 146.42m,
                StockFee = 25m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s6);

			Stock s7 = new Stock()
			{
				StockName = "Visa Inc.",
				StockTicker = "V",
				StockPrice = 181.92m,
                StockFee = 10m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s7);

			Stock s8 = new Stock()
			{
				StockName = "Nike",
				StockTicker = "NKE",
				StockPrice = 93.44m,
                StockFee = 30m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s8);

			Stock s9 = new Stock()
			{
				StockName = "Vanguard Emerging Markets ETF",
				StockTicker = "VWO",
				StockPrice = 42.404m,
                StockFee = 20m,
                StockType = StockType.ETF,
			};
			Stocks.Add(s9);

			Stock s10 = new Stock()
			{
				StockName = "Ford Motor Company",
				StockTicker = "F",
				StockPrice = 8.925m,
                StockFee = 10m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s10);

			Stock s11 = new Stock()
			{
				StockName = "Bank of America Corporation",
				StockTicker = "BAC",
				StockPrice = 32.935m,
                StockFee = 10m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s11);

			Stock s12 = new Stock()
			{
				StockName = "Vanguard REIT ETF",
				StockTicker = "VNQ",
				StockPrice = 93.22m,
                StockFee = 15m,
                StockType = StockType.ETF,
			};
			Stocks.Add(s12);

			Stock s13 = new Stock()
			{
				StockName = "CarMax, Inc.",
				StockTicker = "KMX",
				StockPrice = 99.94m,
                StockFee = 15m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s13);

			Stock s14 = new Stock()
			{
				StockName = "Dow Jones Industrial Average Index Fund",
				StockTicker = "DJI",
				StockPrice = 279.27m,
                StockFee = 25m,
                StockType = StockType.Index_Fund,
			};
			Stocks.Add(s14);

			Stock s15 = new Stock()
			{
				StockName = "S&P 500 Index Fund",
				StockTicker = "VFINX",
				StockPrice = 311.95m,
                StockFee = 25m,
                StockType = StockType.Index_Fund,
			};
			Stocks.Add(s15);

			Stock s16 = new Stock()
			{
				StockName = "Franklin Resources, Inc.",
				StockTicker = "BEN",
				StockPrice = 27.84m,
                StockFee = 25m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s16);

			Stock s17 = new Stock()
			{
				StockName = "Pacific Advisors Small Cap Value Fund",
				StockTicker = "PASMX",
				StockPrice = 15.95m,
                StockFee = 15m,
                StockType = StockType.Mutual_Fund,
			};
			Stocks.Add(s17);

			Stock s18 = new Stock()
			{
				StockName = "Disney",
				StockTicker = "DIS",
				StockPrice = 148.98m,
                StockFee = 20m,
                StockType = StockType.Ordinary,
			};
			Stocks.Add(s18);

			Stock s19 = new Stock()
			{
				StockName = "USAA World Growth Fund",
				StockTicker = "USAWX",
				StockPrice = 34.49m,
                StockFee = 15m,
                StockType = StockType.Mutual_Fund,
			};
			Stocks.Add(s19);

			Stock s20 = new Stock()
			{
				StockName = "Capital Group Global Equity Fund",
				StockTicker = "CGLOX",
				StockPrice = 16.72m,
                StockFee = 25m,
                StockType = StockType.Mutual_Fund,
			};
			Stocks.Add(s20);

			foreach (Stock stock in Stocks)
			{
				db.Stocks.Add(stock);
				db.SaveChanges();
			}
		}
	}
}