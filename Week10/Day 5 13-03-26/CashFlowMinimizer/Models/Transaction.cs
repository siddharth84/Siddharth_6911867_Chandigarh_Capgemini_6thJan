namespace CashFlowMinimizer.Models
{
    public class Transaction
    {
        public string Debtor { get; set; }

        public string Creditor { get; set; }

        public int Amount { get; set; }
    }
}