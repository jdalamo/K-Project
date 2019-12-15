using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using fa19projectgroup16.Models;

namespace fa19projectgroup16.Models
{
    public enum AccountType { Checking, Savings, IRA, Stock }
    public class Account
    {
        public Account()
        {
            if (Transactions == null)
            {
                Transactions = new List<Transaction>();
            }
        }

        [Required]
        public Int32 AccountID { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Balance { get; set; }

        [Required]
        [Display(Name = "Account Name")]
        public String AccountName { get; set; }

        [Display(Name = "Account Type")]
        public AccountType AccountType { get; set; }

        [Display(Name = "Account Number")]
        public int AccountNumber { get; internal set; }
        public int AccountNumberLastFour
        {
            get
            {
                string accountNum = AccountNumber.ToString();
                //return Convert.ToInt32(accountNum.Substring(6));
                return AccountNumber;
            }
            
        }
        public DateTime Date { get; internal set; }
        public AppUser AppUser { get; set; }
        public bool Is_Active { get; set; }

        public List<Transaction> Transactions { get; set; }

        public void Deposit(decimal depositAmount)
        {
            Balance += depositAmount;
        }

        public void Withdraw(decimal withdrawalAmount)
        {
            Balance -= withdrawalAmount;
        }
    }

    public class StandardAccount : Account
    {
    }

    public class IRAAccount : Account
    {
        public Decimal ContributionAmount { get; set; }
    }

    public class StockPortfolio : Account
    {
        public StockPortfolio()
        {
            if (StockTransactions == null)
            {
                StockTransactions = new List<StockTransaction>();
            }
        }
        public List<StockTransaction> StockTransactions { get; set; }
    }
}