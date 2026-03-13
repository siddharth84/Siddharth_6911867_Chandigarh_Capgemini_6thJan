using System.Collections.Generic;

namespace CashFlowMinimizer.Models
{
    public class Bank
    {
        public string Name { get; set; }

        public int NetAmount { get; set; }

        public HashSet<string> Types { get; set; } = new HashSet<string>();
    }
}