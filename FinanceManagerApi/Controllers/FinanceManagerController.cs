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
            return Ok(transactionService.GetTransactionList());
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
            TransactionService transactionService = new TransactionService();
            Transaction transaction = transactionService.FindByTransactionId(transactionId);
            if (transaction == null)
            {
                return NotFound();
            }
            transactionService.DeleteTransactionById(transactionId);
            return Ok();
        }

        [HttpPatch]
        [Route("{transactionId}")]
        public IActionResult UpdateTransaction([FromBody] Transaction transaction, int transactionId)
        {
            TransactionService transactionService = new TransactionService();
            Transaction transactionToUpdate = transactionService.FindByTransactionId(transactionId);
            if (transactionToUpdate == null)
            {
                return NotFound();
            }
            transactionService.UpdateTransaction(transaction, transactionId);
            return Ok(transaction);
        }
        [HttpGet]
        [Route("{transactionId}")]
        public IActionResult GetTransactionById(int transactionId)
        {
            TransactionService transactionService = new TransactionService();
            Transaction transaction = transactionService.FindByTransactionId(transactionId);
            return Ok(transaction);
        }

        [HttpGet]
        [Route("reports/weekly")]
        public IActionResult GetWeeklyReport()
        {
            ReportService reportService = new ReportService();
            return Ok(reportService.GetWeeklyReport());
        }

        [HttpGet]
        [Route("reports/prediction")]
        public IActionResult GetPredictionReport()
        {
            ReportService reportService = new ReportService();
            return Ok(reportService.GetPredictionReport());
        }
    }
}
