using FinanceManagerApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        [HttpGet]
        [Route("/reports/weekly")]
        public IActionResult GetWeeklyReport()
        {
            ReportService reportService = new ReportService();
            return Ok(reportService.GetWeeklyReport());
        }
    }
}
