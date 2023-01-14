using System.ComponentModel.DataAnnotations;

namespace RagilHadiworoApp.Models
{
    public class Customer
    {
        [Key, Required, StringLength(10), Display(Name = "ID Customer")]
        public string IDCustomer { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(700)]
        public string Address { get; set; }

        [Required, Display(Name = "Account No"), StringLength(10)]
        public string AccountNo { get; set; }

        public virtual ICollection<Lending> Lendings { get; set; }
        public virtual ICollection<Funding> Fundings { get; set; }
        public virtual ICollection<Agunan> Agunans { get; set; }
    }
}
