using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class BalanceCurrencyModel
    {
        public int Id { get; set; }
        public int BalanceId { get; set; }

        public int CurrencyId { get; set; }
        public Balance Balance { get; set; }
        public Currency Currency { get; set; }

        public decimal Amount { get; set; }
    }
}
