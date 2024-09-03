using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DbHelper
    {
        private ApplicationContext db;

        public DbHelper(ApplicationContext context)
        {
            db = context;
        }

        public void CreateFakeDataBase()
        {

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            InfoPerson infoPerson1 = new InfoPerson { Name = "Игорь Иванович Крузенштерн", Age = 30, Gender = "Male" };
            InfoPerson infoPerson2 = new InfoPerson { Name = "Морозов Павлик Иванович", Age = 15, Gender = "Male" };
            InfoPerson infoPerson3 = new InfoPerson { Name = "Иванов Геннадий Павлович", Age = 20, Gender = "Male" };

            db.InfoPersons.AddRange(infoPerson1, infoPerson2, infoPerson3);

            Currency currency1 = new Currency { Name = "Доллар", Voluation = 5 };
            Currency currency2 = new Currency { Name = "Рубль", Voluation = 500 };
            Currency currency3 = new Currency { Name = "Евро", Voluation = 50 };
            Currency currency4 = new Currency { Name = "Юани", Voluation = 10 };

            db.Currencies.AddRange(currency1, currency2, currency3, currency4);

            Balance balance1 = new Balance { InfoPerson = infoPerson1, Currency = currency1, Amount = 100000 };
            Balance balance2 = new Balance { InfoPerson = infoPerson1, Currency = currency2, Amount = 200000 };
            Balance balance3 = new Balance { InfoPerson = infoPerson1, Currency = currency3, Amount = 200000 };
            Balance balance4 = new Balance { InfoPerson = infoPerson1, Currency = currency4, Amount = 500000 };
            Balance balance5 = new Balance { InfoPerson = infoPerson2, Currency = currency2, Amount = 2000 };
            Balance balance6 = new Balance { InfoPerson = infoPerson2, Currency = currency4, Amount = 200000 };
            Balance balance7 = new Balance { InfoPerson = infoPerson3, Currency = currency2, Amount = 300000 };

            db.Balances.AddRange(balance1, balance2, balance3, balance4, balance5, balance6, balance7);
            db.SaveChanges();
        }


        public void CreateOperationMoney(decimal amount, int senderId, int? recepientId, Person personSender, Person? personRecipient)
        {
                try
                {
                    if (recepientId != null)
                    {
                        var balanceSender = db.Balances.Where(x => x.Id == senderId).First();

                        if (checkBuy(balanceSender.Amount, amount))
                        {
                            var balanceRecipient = db.Balances.Where(x => x.Id == recepientId).First();

                            var currencieSender = db.Currencies.Where(x => x.Id == balanceSender.CurrencyId).First();

                            var currencieRecipient = db.Currencies.Where(x => x.Id == balanceRecipient.CurrencyId).First();

                            balanceRecipient.Amount += amount * (currencieSender.Voluation / currencieRecipient.Voluation);

                            balanceSender.Amount -= amount;

                            Transaction transaction = new Transaction { Type = "Transfer", Amount = amount, BalanceRecepient = balanceRecipient, BalanceSender = balanceSender };
                            db.Transactions.Add(transaction);

                            personSender.Moneys.Where(x => x.Currently == currencieSender.Name).First().Amount = balanceSender.Amount;

                            personRecipient.Moneys.Where(x => x.Currently == currencieRecipient.Name).First().Amount = balanceRecipient.Amount;
                        }
                    }
                    else
                    {
                        var balanceSender = db.Balances.Where(x => x.Id == senderId).First();

                        if (checkBuy(balanceSender.Amount, amount))
                        {
                            balanceSender.Amount -= amount;
                            Transaction transaction = new Transaction { Type = "Expenses", Amount = amount, BalanceSender = balanceSender };
                            db.Transactions.Add(transaction);
                        }

                        var currencieSender = db.Currencies.Where(x => x.Id == balanceSender.CurrencyId).First();

                        personSender.Moneys.Where(x => x.Currently == currencieSender.Name).First().Amount = balanceSender.Amount;
                    }

                    db.SaveChanges();
                }
                catch
                {
                    throw new ArgumentNullException("Не найден баланс для транзакции.");
                }

        }

        bool checkBuy(decimal amountMoney, decimal priceProduct)
        {
            if (amountMoney > priceProduct)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Person GetPerson(int id)
        {

            try
            {
                var person = from balance in db.Balances
                             join info in db.InfoPersons on balance.InfoPersonId equals info.Id
                             join currency in db.Currencies on balance.CurrencyId equals currency.Id
                             where info.Id == id
                             select new
                             {
                                 info.Name,
                                 info.Age,
                                 info.Gender,
                                 balance.Amount,
                                 CurrencyName = currency.Name
                             };

                List<Money> moneys = new List<Money>();

                foreach (var p in person)
                {
                    moneys.Add(new(p.CurrencyName, p.Amount));
                }

                return new Person(person.First().Name, person.First().Age, person.First().Gender, moneys);
            }
            catch
            {
                throw new ArgumentException("Пользователь не найден.");
            }

        }
    }
}
