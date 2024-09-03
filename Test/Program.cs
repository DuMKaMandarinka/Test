// See https://aka.ms/new-console-template for more information
using ClassLibrary1;
using Test;

ApplicationContext db = new ApplicationContext();

DbHelper dbHelper = new DbHelper(db);

dbHelper.CreateFakeDataBase();

//var person1 = dbHelper.GetPerson(1);
  
//var person2 = dbHelper.GetPerson(2);

//Console.WriteLine("Информация о пользователях:");

//Console.WriteLine(person1.GetInformation());
//Console.WriteLine(person2.GetInformation());

//Console.WriteLine($"Пользователь {person1.Name} делает перевод. Пользователю {person2.Name} получает его.");

//dbHelper.CreateOperationMoney(1000, 1, 5, person1, person2);

//Console.WriteLine("Информация после перевода:");

//Console.WriteLine(person1.GetInformation());
//Console.WriteLine(person2.GetInformation());

//dbHelper.CreateOperationMoney(100, 1, null, person1, null);

//Console.WriteLine("Информация после покупки:");

//Console.WriteLine(person1.GetInformation());

//Console.Read();
