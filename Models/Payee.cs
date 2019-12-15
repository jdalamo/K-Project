using fa19projectgroup16.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fa19projectgroup16
{
    public enum PayeeType { Credit_Card, Utilities, Rent, Mortgage, Other };

    public class Payee
    {
        public int PayeeID { get; set; }

        [Required(ErrorMessage = "Payee name is required.")]
        [Display(Name = "Payee Name")]
        public string PayeeName { get; set; }

        [Required(ErrorMessage = "Payee phone number is required.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Payee type is required.")]
        [Display(Name = "Payee Type")]
        public PayeeType PayeeType { get; set; }

        [Required(ErrorMessage = "Payee street address is required.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Payee city is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Payee state is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Payee zip code is required.")]
        public string Zip { get; set; }

        public List<Transaction> Transactions { get; set; }

    }
}