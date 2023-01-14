using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RagilHadiworoApp.Models
{
    public class Agunan
    {
        [Key, Display(Name = "Agunan ID"), Required, StringLength(10)]
        public string AgunanID { get; set; }

        [Required, StringLength(10)]
        public string IDCustomer { get; set; }

        [Required]
        public int Type { get; set; }

        [Required, Precision(18, 2)]
        public decimal Amount { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
