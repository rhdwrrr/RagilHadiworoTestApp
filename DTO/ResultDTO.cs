using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RagilHadiworoApp.DTO
{
    public sealed class ResultDTO
    {
        [Display(Name = "ID Customer")]
        public string IDCustomer { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [Display(Name = "Lending Balance")]
        public decimal LendingBalance { get; set; }

        [Display(Name = "Funding Balance")]
        public decimal FundingBalance { get; set; }

        [Display(Name = "Agunan ID")]
        public string AgunanID { get; set; }
    }
}
