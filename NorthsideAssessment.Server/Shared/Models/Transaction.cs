namespace NorthsideAssessment.Server.Shared.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public string Department { get; set; } = "";
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = "";
    }
}
