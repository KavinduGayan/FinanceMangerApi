using FinanceManagerApi.Models;
using FinanceManagerApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagerApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceManagerController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            TransactionService transactionService = new TransactionService();
            return Ok(transactionService.getTransactionList());
        }
        [HttpPost]
        public IActionResult SaveTransaction([FromBody] Transaction transaction)
        {
            TransactionService transactionService = new TransactionService();
            transactionService.SetTransaction(transaction);
            Console.WriteLine(transaction.ToString);
            return Ok(transaction);
        }
        [HttpDelete]
        [Route("{transactionId}")]
        public IActionResult DeleteTransaction(int transactionId)
        {
            return Ok(transactionId);
        }

        [HttpPatch]
        [Route("{transactionId}")]
        public IActionResult UpdateTransaction([FromBody] Transaction transaction, int transactionId)
        {
            Console.WriteLine(transaction.ToString);
            return Ok(transactionId);
        }
    }
}
