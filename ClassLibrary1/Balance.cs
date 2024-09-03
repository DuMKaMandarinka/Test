using Castle.Components.DictionaryAdapter;
using System.Reflection.Metadata;

namespace ClassLibrary1
{
    public class Balance
    {
        public int Id { get; set; }

        public int InfoPersonId { get; set; } 
        
        public InfoPerson InfoPerson { get; set; } = null!;

        public int CurrencyId { get; set; }

        public Currency Currency { get; set; } = null!;

        public decimal Amount { get; set; }

        public ICollection<Transaction> TransactionSenders { get; } = new List<Transaction>();

        public ICollection<Transaction> TransactionRecepients { get;} = new List<Transaction>();
    }
}