using FinanceManagerApi.Models;
using System.Globalization;

namespace FinanceManagerApi.Service
{
    public class ReportService
    {
        //user $Password
        public List<WeeklyReport> GetWeeklyReport()
        {
            TransactionService transactionService = new TransactionService();
            List<Transaction> transList = transactionService.GetTransactionList();
            List<WeeklyReport> weekReportList = new List<WeeklyReport>();
            WeeklyReport weekReport;
            Transaction transaction;
            foreach (var trans in transList)
            {
                weekReport = new WeeklyReport();
                transaction = trans;
                int weekDay = GetIso8601WeekOfYear(transaction.transactionDate);
                weekReport.week = weekDay;
                weekReport.description = transaction.description;
                weekReport.transType = transaction.transType;
                weekReport.recurring = transaction.recurring;
                weekReport.amount = transaction.amount;
                weekReport.transactionDate = transaction.transactionDate;
                weekReportList.Add(weekReport);
            }
            return weekReportList;
        }

        private int GetIso8601WeekOfYear(DateTime? time)
        {
            if (time != null)
            {
                DateTime dateTime = time.Value;
                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);
                if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                {
                    dateTime = dateTime.AddDays(3);
                }

                return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            }
            return -1;

        }

        public List<PredictTransaction> GetPredictionReport()
        {
            TransactionService transactionService = new TransactionService();
            List<Transaction> transList = transactionService.GetTransactionList();
            List<PredictTransaction> predictTransList = new List<PredictTransaction>();
            PredictTransaction predictTrans = null;
            foreach (Transaction trans in transList)
            {
                if (trans.recurring == true && DateComparisonForPrediction(trans.transactionDate.Value))
                {
                    predictTrans = new PredictTransaction();
                    predictTrans.amount = trans.amount;
                    predictTrans.description = trans.description;
                    predictTrans.transType = trans.transType;
                    predictTrans.amount = trans.amount;
                    predictTrans.nextDate = trans.transactionDate.Value.AddMonths(1);

                    predictTransList.Add(predictTrans);
                }
            }
            return predictTransList;
        }

        private Boolean DateComparisonForPrediction(DateTime transDateTime)
        {
            return transDateTime > DateTime.Now.AddMonths(-1) && transDateTime < DateTime.Now;
        }

    }
}
