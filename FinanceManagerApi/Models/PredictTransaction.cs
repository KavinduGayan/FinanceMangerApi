namespace FinanceManagerApi.Models
{
    public class PredictTransaction
    {
        public Double amount { get; set; }
        public String description { get; set; }
        public String transType { get; set; }

        public DateTime nextDate { get; set; }
    }
}
