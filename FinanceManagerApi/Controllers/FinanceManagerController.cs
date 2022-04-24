using FinanceManagerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagerApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceManagerController : ControllerBase
    {
        private static List<Transaction> transactionsList = new List<Transaction>();
        [HttpGet]
        public IActionResult getAllTransactions()
        {
            return Ok(transactionsList);
        }
        [HttpPost]
        public IActionResult saveTransaction([FromBody] Transaction transaction)
        {
            transactionsList.Add(transaction);
            return Ok(transactionsList);
        }
    }
}
