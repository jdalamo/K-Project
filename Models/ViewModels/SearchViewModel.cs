//Author: Shaan Davis
//Date: November 22, 2019

using System;
using System.ComponentModel.DataAnnotations;

namespace fa19projectgroup16.Models.ViewModels

{
    public enum Amount { AllAmounts, ZeroToHundred, HundredToTwoHundred, TwoHundredToThreeHundred, ThreeHundredPlus, Custom }

    public enum TransactionType { All, Withdrawal, Deposit, Transfer, Payment, Fee } 

    public enum DateSelectionType { AllAvailable, FifteenDays, ThirtyDays, SixtyDays, Custom }

    public class SearchViewModel
    {

        [Display(Name = "Search Description:")]
        public String SearchDescription { get; set; }

        [Display(Name = "Search Transaction Number:")]
        public String SelectedTransactionNumber { get; set; }

        [Display(Name = "Select a Type:")]
        public TransactionType SearchType { get; set; }

        [Display(Name = "For Custom Search Amounts Above: ")]
        public Decimal? SearchAmountAbove { get; set; }

        [Display(Name = "For Custom Search Amounts Below: ")]
        public Decimal? SearchAmountBelow { get; set; }

        //[Display(Name = "Sea:")]
        public Amount SearchAmount { get; set; }

        public DateSelectionType DateSelection { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateAfter { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateBefore { get; set; }

    }
}
