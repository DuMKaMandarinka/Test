using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Currency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Voluation { get; set; }

        public ICollection<Balance> Balances { get; } = new List<Balance>();
    }
}
