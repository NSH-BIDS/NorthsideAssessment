using NorthsideAssessment.Server.Shared.Models;
namespace NorthsideAssessment.Server.Services;

    public class TransactionService
    {
        private static readonly List<Transaction> Transactions = new()
    {
        new Transaction { TransactionId = Guid.NewGuid(), Department = "HR", Amount = 1250.50m, Date = new DateTime(2024, 01, 15), Description = "Recruiting Expenses" },
        new Transaction { TransactionId = Guid.NewGuid(), Department = "IT", Amount = 899.99m, Date = new DateTime(2024, 02, 10), Description = "Cloud Services" },
        new Transaction { TransactionId = Guid.NewGuid(), Department = "Finance", Amount = 4520.00m, Date = new DateTime(2024, 03, 05), Description = "Consulting" },
    };

        public IEnumerable<Transaction> GetTransactions(string? department, DateTime? start, DateTime? end)
        {
            return Transactions
                .Where(t => (department == null || t.Department == department) &&
                            (!start.HasValue || t.Date >= start) &&
                            (!end.HasValue || t.Date <= end));
        }
   }

