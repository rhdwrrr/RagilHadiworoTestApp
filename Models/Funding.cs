using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RagilHadiworoApp.Models
{
    public class Funding
    {
        [Key, Display(Name = "ID Funding"), Required, StringLength(10)]
        public string IDFunding { get; set; }

        [Required, StringLength(10), Display(Name = "ID Customer")]
        public string IDCustomer { get; set; }

        [Required, Precision(18, 2)]
        public decimal Balance { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
