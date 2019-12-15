using System;
using System.ComponentModel.DataAnnotations;

namespace fa19projectgroup16
{
    public enum Status { Submitted, Accepted, Rejected, Adjusted };

    public class Dispute
    {
        public int DisputeID { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string CustomerComment { get; set; }

        [Required]
        [Display(Name = "Correct Amount")]
        public Decimal CorrectAmount { get; set; }

        [Required]
        public Status Status { get; set; }

        [Display(Name = "Manager Comment")]
        public string ManagerComment { get; set; }

        [Display(Name = "Manager Email")]
        public string ManagerEmail { get; set; }

        public Transaction Transaction { get; set; }
    }
}