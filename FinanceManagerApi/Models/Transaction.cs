namespace FinanceManagerApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Double amount { get; set; }
        public String description { get; set; }
        public String transType { get; set; }
        public Boolean recurring { get; set; }

        public DateTime insertedDate { get; set; }

        public DateTime? transactionDate { get; set; }
    }
}
