using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RagilHadiworoApp.Models
{
    public class Lending
    {
        [Key, Display(Name = "ID Lending"), Required, StringLength(10)]
        public string IDLending { get; set; }

        [Required, Display(Name = "ID Customer"), StringLength(10)]
        public string IDCustomer { get; set; }

        [Required, Precision(18, 2)]
        public decimal Balance { get; set; }

        [Required, Precision(18, 2)]
        public decimal Plafond { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
