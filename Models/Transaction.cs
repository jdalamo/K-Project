using fa19projectgroup16.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fa19projectgroup16
{
    public enum TransactionType { Withdrawal, Deposit, Transfer, Payment, Fee };

    public enum TransactionStatus { Pending, Accepted };

    public class Transaction
    {
        public int TransactionID { get; set; }

        [Required]
        [Display(Name = "Transaction Amount")]
        [Range(0.0, Double.MaxValue)]
        public Decimal Amount { get; set; }

        [Required]
        [Display(Name = "Transaction Type")]
        public TransactionType TransactionType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public TransactionStatus TransactionStatus { get; set; }

        public Payee Payee { get; set; }

        public List<Dispute> Disputes { get; set; }

        public Account Account { get; set; }
    }
}