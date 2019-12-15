using System;
using System.ComponentModel.DataAnnotations;
namespace fa19projectgroup16.Models.ViewModels
{
    public class StockDetailsViewModel
    {
        public int StockID { get; set; }

        [Display(Name = "Company")]
        public string StockName { get; set; }

        [Display(Name = "Ticker Symbol")]
        public string StockTicker { get; set; }

        [Display(Name = "Purchase Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal PurchasePrice { get; set; }

        [Display(Name = "Current Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal CurrentPrice { get; set; }

        [Display(Name = "Stock Fee")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal StockFee { get; set; }

        [Display(Name = "Stock Type")]
        public StockType StockType { get; set; }

        [Display(Name = "Number of Shares")]
        public int NumberOfShares { get; set; }
    }
}
