using System;
using System.Collections.Generic;
using fa19projectgroup16.Models;
using System.ComponentModel.DataAnnotations;

namespace fa19projectgroup16
{
    public enum StockType { Ordinary, Index_Fund, ETF, Mutual_Fund, Futures };

    public class Stock
    {
        public int StockID { get; set; }

        [Display(Name = "Company")]
        public string StockName { get; set; }

        [Display(Name = "Ticker Symbol")]
        public string StockTicker { get; set; }

        [Display(Name = "Stock Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal StockPrice { get; set; }

        [Display(Name = "Stock Fee")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal StockFee { get; set; }

        [Display(Name = "Stock Type")]
        public StockType StockType { get; set; }

        public List<StockTransaction> StockTransactions { get; set; }
    }

}