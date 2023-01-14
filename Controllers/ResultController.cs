using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RagilHadiworoApp.DTO;
using RagilHadiworoApp.Models;

namespace RagilHadiworoApp.Controllers
{
    public class ResultController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ResultController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cust = _context.Customers.ToArray();
            var lend = _context.Lendings;
            var fund = _context.Fundings;
            var agun = _context.Agunans;
            List<ResultDTO> results = cust.Select(i =>
            {
                return new ResultDTO
                {
                    IDCustomer = i.IDCustomer,
                    Name = i.Name,
                    Address = i.Address,
                    LendingBalance = lend.Where(x => x.IDCustomer == i.IDCustomer)?.Sum(x => x.Balance) ?? 0,
                    FundingBalance = fund.Where(x => x.IDCustomer == i.IDCustomer)?.Sum(x => x.Balance) ?? 0,
                    AgunanID = string.Join(", ", agun.Where(x => x.IDCustomer == i.IDCustomer).Select(x => x.AgunanID))
                };
            }).ToList();
            return View(results);
        }
    }
}
