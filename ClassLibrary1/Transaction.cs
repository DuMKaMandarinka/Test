using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Transaction
    {
        public int Id { get; set; } 

        public string Type { get; set; }

        public decimal Amount { get; set; }

        public int SenderId { get; set; } 

        public Balance BalanceSender { get; set; } = null!; 

        public int? RecepientId { get; set; } 

        public Balance? BalanceRecepient { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
