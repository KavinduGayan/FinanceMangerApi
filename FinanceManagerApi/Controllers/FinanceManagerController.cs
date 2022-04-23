using FinanceManagerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceManagerController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAllTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            Transaction trans = new Transaction();
            trans.amount = 10;
            trans.description = "test";
            transactions.Add(trans);
            return Ok(transactions);
        }
        /*[HttpPost]
        public IActionResult saveTransaction()
        {
            return Ok(trans);
        }*/
    }
}
