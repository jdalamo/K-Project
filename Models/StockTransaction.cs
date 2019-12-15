using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fa19projectgroup16.Models
{
    public class StockTransaction
    {
        public Int32 StockTransactionID { get; set; }

        public Int32 NumberOfShares { get; set; }

        public Decimal PurchasePrice { get; set; }

        public Decimal PurchaseFee { get; set; }

        public Stock Stock { get; set; }

        public StockPortfolio StockPortfolio { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
